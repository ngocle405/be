using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Data.Entities
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(255)]
        public string DepartmemtName { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
        //nếu employee chưa có thì có ds rỗng
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
