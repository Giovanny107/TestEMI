using TestEMI.Application.IServices;

namespace TestEMI.Application.Services
{
    public class ManagerBonusCalculator : IBonusCalculator
    {
        public decimal CalculateBonus(decimal salary)
        {
            return salary * 0.20m;
        }
    }
}
