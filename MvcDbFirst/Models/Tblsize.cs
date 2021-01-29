using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("tblsize")]
    public partial class Tblsize
    {
        public Tblsize()
        {
            Products = new HashSet<Product>();
            TblProducts = new HashSet<TblProduct>();
        }

        [Key]
        [Column("Size id")]
        public int SizeId { get; set; }
        [Column("Size Name")]
        [StringLength(20)]
        public string SizeName { get; set; }

        [InverseProperty(nameof(Product.Size))]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty(nameof(TblProduct.Size))]
        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
