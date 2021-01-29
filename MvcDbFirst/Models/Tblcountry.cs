using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("tblcountry")]
    public partial class Tblcountry
    {
        public Tblcountry()
        {
            UsersDetails = new HashSet<UsersDetail>();
        }

        [Key]
        public int Cid { get; set; }
        [StringLength(20)]
        public string Cname { get; set; }

        [InverseProperty(nameof(UsersDetail.CidNavigation))]
        public virtual ICollection<UsersDetail> UsersDetails { get; set; }
    }
}
