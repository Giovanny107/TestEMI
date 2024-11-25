namespace TestEMI.Core.Models
{
    public class PositionHistory
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int PositionId { get; set; } = default!;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Employee Employee { get; set; } = default!;

        public virtual Position Position { get; set; } = default!;
    }
}
