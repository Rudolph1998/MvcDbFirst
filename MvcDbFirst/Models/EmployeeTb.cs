using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Keyless]
    [Table("EmployeeTb")]
    public partial class EmployeeTb
    {
        public int EmpId { get; set; }
        [StringLength(20)]
        public string EmpFirstName { get; set; }
        [StringLength(20)]
        public string EmpLastName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(15)]
        public string MobNo { get; set; }
        [StringLength(10)]
        public string Pincode { get; set; }
        public string Email { get; set; }
    }
}
