using System;
using System.Collections.Generic;

namespace WebApplication.Models2
{
    public partial class Order
    {
        public long Id { get; set; }
        public string? Flash { get; set; }
        public string? Customer { get; set; }
        public string? Ord { get; set; }
        public string? Steel { get; set; }
        public string? Surface { get; set; }
        public double? Thickness { get; set; }
        public int? Qty { get; set; }
        public string? Bending { get; set; }
        public double? Dimension1 { get; set; }
        public double? Dimension2 { get; set; }
        public string? Note { get; set; }
        public string? Manager { get; set; }
        public string? Operator { get; set; }
        public DateTime? Modified { get; set; }
    }
}
