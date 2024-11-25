using TestEMI.Core.Models;

namespace TestEMI.Infrastructure.Data
{
    public class SeedDb
    {
        private readonly EmployeeContext _context;

        public SeedDb(EmployeeContext context)
        {
            _context = context;
        }

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPositionsAsync();
            await CheckDepartmentsAsync();
        }

        private async Task CheckPositionsAsync()
        {
            if (!_context.Positions.Any())
            {
                _context.Positions.AddRange(new List<Position>
                {
                    new()
                    {
                        Name="Regular"
                    },
                    new() 
                    {
                        Name="Manager"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDepartmentsAsync()
        {
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(new List<Department>
                {
                    new() {
                        Name="Compras"
                    },
                    new() {
                        Name="Ventas"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
