﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using MailService;
using ZTP.Scheduler.Models;

namespace ZTP.Scheduler
{
    public class OrderService
    {
        private SmtpService smtpService;
        public OrderService()
        {
            var smtpSection = ConfigurationManager.GetSection("system.net / mailSettings / smtp");
            //smtpService = new SmtpService();
        }

        /// <summary>
        /// Sends orders by  given collection.
        /// </summary>
        /// <param name="orders"></param>
        /// <returns>Orders sent.</returns>
        public async Task<ICollection<Order>> SendOrders(IEnumerable<Order> orders)
        {
            try
            {
                var ordersSent = new ConcurrentBag<Order>();
                var tasks = new ConcurrentBag<Task>();

                foreach (var order in orders)
                {
                    var message = CreateOrderMessage(order);
                    tasks.Add(this.SendAsync(message).ContinueWith((t) =>
                    {
                        if (t.Result)
                        {
                            Console.WriteLine($"Wysłano {order}");
                            ordersSent.Add(order); 
                        }
                    }));
                }

                Task.WaitAll(tasks.ToArray());
                return ordersSent.ToArray();
            }
            catch (Exception ex)
            {
                //logger
                throw;
            }
        }

        private static MimeMessage CreateOrderMessage(Order order)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Encoding.UTF8,"Sender Name", "sender@gmail.com" ));
            message.To.Add(new MailboxAddress("Recipient Name","recipient@gmail.com"));
            message.Subject = "New order";
            BodyBuilder body = new BodyBuilder();
            body.TextBody = $@"You have one new order
{order}";
            body.HtmlBody = $@"<h1><b>You have one new order</b></h1>
<p>Order ID: {order.NrZamowienia}</p>
<p>{order.Imie}</p>
<p>{order.Nazwisko}</p>
<p>{order.NumerPaczki}</p>
<p>{order.Cena}</p>";
            message.Body = body.ToMessageBody();
            return message;
        }
    }
}
