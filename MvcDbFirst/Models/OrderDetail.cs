using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    public partial class OrderDetail
    {
        [Key]
        public int Orderid { get; set; }
        public int? ProductId { get; set; }
        [Column("Product Name")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("Product Color")]
        [StringLength(50)]
        public string ProductColor { get; set; }
        [Column("Product Price", TypeName = "decimal(18, 2)")]
        public decimal? ProductPrice { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        public int? Quantity { get; set; }
        [StringLength(50)]
        public string Size { get; set; }
    }
}
