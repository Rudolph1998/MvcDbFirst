using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MvcDbFirst.Models
{
    [Table("tbldept")]
    public partial class Tbldept
    {
        public Tbldept()
        {
            EmployeesDbs = new HashSet<EmployeesDb>();
        }

        [Key]
        public int Did { get; set; }
        [StringLength(50)]
        public string Dname { get; set; }

        [InverseProperty(nameof(EmployeesDb.DidNavigation))]
        public virtual ICollection<EmployeesDb> EmployeesDbs { get; set; }
    }
}
