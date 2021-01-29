using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("tblProducts")]
    public partial class TblProduct
    {
        [Key]
        public int Productid { get; set; }
        [Column("Category id")]
        public int? CategoryId { get; set; }
        [Column("Size id")]
        public int? SizeId { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string ProductColour { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? ProductPrice { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public string ImagePath { get; set; }
        [StringLength(50)]
        public string Username { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Tblcategory.TblProducts))]
        public virtual Tblcategory Category { get; set; }
        [ForeignKey(nameof(SizeId))]
        [InverseProperty(nameof(Tblsize.TblProducts))]
        public virtual Tblsize Size { get; set; }
    }
}
