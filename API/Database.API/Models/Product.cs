﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Database.API.Models
{
    public partial class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double? ProductAmount { get; set; }
        public string ProductDetail { get; set; }
        public double? ProductPrice { get; set; }
        public string ProductReference { get; set; }
        public string TypeId { get; set; }

        public virtual TypeProduct Type { get; set; }
    }
}