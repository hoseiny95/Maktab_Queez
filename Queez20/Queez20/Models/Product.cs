﻿namespace Queez20.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string ManufactureDate { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
