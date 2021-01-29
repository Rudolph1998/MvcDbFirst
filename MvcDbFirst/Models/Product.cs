using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column("Category id")]
        public int? CategoryId { get; set; }
        [Column("Size id")]
        public int? SizeId { get; set; }
        [Column("Product Name")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column("Product Colour")]
        [StringLength(20)]
        public string ProductColour { get; set; }
        [Column("Product Price", TypeName = "decimal(18, 4)")]
        public decimal? ProductPrice { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public bool? Status { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Tblcategory.Products))]
        public virtual Tblcategory Category { get; set; }
        [ForeignKey(nameof(SizeId))]
        [InverseProperty(nameof(Tblsize.Products))]
        public virtual Tblsize Size { get; set; }
    }
}
