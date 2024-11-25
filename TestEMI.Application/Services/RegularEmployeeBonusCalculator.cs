using TestEMI.Application.IServices;

namespace TestEMI.Application.Services
{
    public class RegularEmployeeBonusCalculator : IBonusCalculator
    {
        public decimal CalculateBonus(decimal salary)
        {
            return salary * 0.10m;
        }
    }
}
