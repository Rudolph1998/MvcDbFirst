using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("EmployeesDB")]
    public partial class EmployeesDb
    {
        [Key]
        public int Empid { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string Addresses { get; set; }
        [StringLength(15)]
        public string Mobno { get; set; }
        [StringLength(10)]
        public string Pincode { get; set; }
        public string Email { get; set; }
        public int? Did { get; set; }

        [ForeignKey(nameof(Did))]
        [InverseProperty(nameof(Tbldept.EmployeesDbs))]
        public virtual Tbldept DidNavigation { get; set; }
    }
}
