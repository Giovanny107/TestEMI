namespace TestEMI.Core.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public ICollection<Employee> Employees { get; set; } = default!;
    }
}
