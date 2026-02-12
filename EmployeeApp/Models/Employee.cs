using System.ComponentModel.DataAnnotations;

namespace EmployeeMiniApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string ? Name { get; set; }

        public string ? Email { get; set; }

        public string ? Department { get; set; }

        public decimal Salary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
