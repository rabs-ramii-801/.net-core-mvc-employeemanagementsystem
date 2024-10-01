using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employees
    {
        [Key, Required]
        [Column("id", TypeName = "int")]
        public int EmployeeId { get; set; }

        [Required]
        [Column("FirstName", TypeName = "varchar(100)")]  // Fixed closing parenthesis
        public string EmployeeFirstName { get; set; } = string.Empty;

        [Required]
        [Column("LastName", TypeName = "varchar(100)")]  // Fixed closing parenthesis
        public string EmployeeLastName { get; set; } = string.Empty;

        [Required]
        [Column("Email", TypeName = "varchar(30)")]
        public string EmployeeEmail { get; set; } = string.Empty;

        [Required]
        [Column("Phone", TypeName = "varchar(100)")]
        public string EmployeePhone { get; set; } = string.Empty;

        [Required]
        [Column("Salary", TypeName = "int")]
        public int EmployeeSalary { get; set; }

        [Required]
        [Column("Address", TypeName = "varchar(100)")]
        public string EmployeeAddress { get; set; } = string.Empty;
    }
}
