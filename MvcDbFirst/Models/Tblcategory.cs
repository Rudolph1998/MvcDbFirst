using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("tblcategory")]
    public partial class Tblcategory
    {
        public Tblcategory()
        {
            Products = new HashSet<Product>();
            TblProducts = new HashSet<TblProduct>();
        }

        [Key]
        [Column("Category id")]
        public int CategoryId { get; set; }
        [Column("Category Name")]
        [StringLength(20)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty(nameof(TblProduct.Category))]
        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
