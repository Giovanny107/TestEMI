namespace TestEMI.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int PositionId { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
        
        public IEnumerable<PositionHistory> PositionHistory { get; set; } = default!;

        public Position Position { get; set; } = default!;

        public Department Department { get; set; } = default!;

        public ICollection<Project> Projects { get; set; } = default!;
    }
}
