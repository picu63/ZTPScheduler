﻿using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using OrderService.Models;

namespace OrderService
{
    public interface IOrdersCsvProvider
    {
        IEnumerable<Order> GetOrdersFromCsv(IReader reader);
        IAsyncEnumerable<Order> GetOrdersFromCsvAsync(IReader reader);
    }
}
