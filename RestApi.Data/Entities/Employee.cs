using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Data.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(20)]
        public string EmployeeCode { get; set; }
        [Required]
        [MaxLength(255)]
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("Department")]
 
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
    }
}
