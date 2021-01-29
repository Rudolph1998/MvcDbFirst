using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("tblstate")]
    public partial class Tblstate
    {
        public Tblstate()
        {
            UsersDetails = new HashSet<UsersDetail>();
        }

        [Key]
        public int Sid { get; set; }
        [StringLength(20)]
        public string Sname { get; set; }
        public int? Cid { get; set; }

        [InverseProperty(nameof(UsersDetail.SidNavigation))]
        public virtual ICollection<UsersDetail> UsersDetails { get; set; }
    }
}
