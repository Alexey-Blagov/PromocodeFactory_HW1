using PromocodeFactory.Exceptions;
using PromocodeFactory.Models;

namespace PromocodeFactory.Repositories
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        private readonly List<Role> _roles;

        public InMemoryEmployeeRepository()
        {
            _roles = new List<Role>
            {
                new Role { Id = 1, Name = "Разработчик" },
                new Role { Id = 2, Name = "Тестировщик" },
                new Role { Id = 3, Name = "Тимлид" }
            };

            _employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Иван", LastName = "Иванов", RoleId = 1, Position = "Разработчик" },
                new Employee { Id = 2, FirstName = "Петр", LastName = "Петров", RoleId = 2, Position = "Тестировщик" },
                new Employee { Id = 3, FirstName = "Сергей", LastName = "Сергеев", RoleId = 3, Position = "Тимлид" }
            };
        }

        public Task<Employee?> GetById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(employee);
        }

        public Task<Employee?> Add(Employee employee)
        {
            var role = _roles.FirstOrDefault(r => r.Id == employee.RoleId);
            if (role == null)
            {
                return Task.FromResult<Employee?>(null);
            }

            employee.Id = _employees.Count == 0 ? 1 : _employees.Max(e => e.Id) + 1;
            employee.Position = role.Name;
            _employees.Add(employee);

            return Task.FromResult<Employee?>(employee);
        }

        public Task<Employee?> Update(Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee == null)
            {
                throw new EntityNotFoundException($"Сотрудник с id {employee.Id} не найден.");
            }

            var role = _roles.FirstOrDefault(r => r.Id == employee.RoleId);
            if (role == null)
            {
                return Task.FromResult<Employee?>(null);
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.RoleId = employee.RoleId;
            existingEmployee.Position = role.Name;

            return Task.FromResult<Employee?>(existingEmployee);
        }

        public Task Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new EntityNotFoundException($"Сотрудник с таким id {id} не найден");
            }

            _employees.Remove(employee);

            return Task.CompletedTask;
        }
    }
}
