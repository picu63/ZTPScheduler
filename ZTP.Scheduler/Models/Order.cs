﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace ZTP.Scheduler.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int NrZamowienia { get; set; }
        public decimal Cena { get; set; }
        public decimal Ilosc { get; set; }
        [Name("Adres przyjmującego zlecenie")]
        public int AdresZamowienia { get; set; }
    }
}
