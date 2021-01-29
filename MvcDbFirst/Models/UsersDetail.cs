using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Index(nameof(Emailid), Name = "UQ_Table_Email", IsUnique = true)]
    [Index(nameof(Username), Name = "UQ_usersdetails_Username", IsUnique = true)]
    public partial class UsersDetail
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Emailid { get; set; }
        public string Address { get; set; }
        public int? Pincode { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Gender { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        public int? Usertype { get; set; }
        public int? Cid { get; set; }
        public int? Sid { get; set; }
        public int? Cityid { get; set; }

        [ForeignKey(nameof(Cid))]
        [InverseProperty(nameof(Tblcountry.UsersDetails))]
        public virtual Tblcountry CidNavigation { get; set; }
        [ForeignKey(nameof(Cityid))]
        [InverseProperty(nameof(TblCity.UsersDetails))]
        public virtual TblCity City { get; set; }
        [ForeignKey(nameof(Sid))]
        [InverseProperty(nameof(Tblstate.UsersDetails))]
        public virtual Tblstate SidNavigation { get; set; }
    }
}
