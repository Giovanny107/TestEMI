using TestEMI.Application.IServices;

namespace TestEMI.Application.DTO_s
{
    public class EmployeeDto
    {        
        public string Name { get; set; } = default!;

        public int CurrentPosition { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public IBonusCalculator BonusCalculator = default!;

        public decimal CalculateYearlyBonus()
        {
            return BonusCalculator.CalculateBonus(Salary);
        }
    }
}
