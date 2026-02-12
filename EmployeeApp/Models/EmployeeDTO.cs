
namespace EmployeeApp.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required, MaxLength(100)]
        public string? Email { get; set; }
        [Required, MaxLength(100)]
        public string? Department { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
