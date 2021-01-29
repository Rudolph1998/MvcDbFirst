using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("tblCity")]
    public partial class TblCity
    {
        public TblCity()
        {
            UsersDetails = new HashSet<UsersDetail>();
        }

        [Key]
        public int Cityid { get; set; }
        [StringLength(20)]
        public string Cityname { get; set; }
        public int? Sid { get; set; }

        [InverseProperty(nameof(UsersDetail.City))]
        public virtual ICollection<UsersDetail> UsersDetails { get; set; }
    }
}
