using PromocodeFactory.Models;

namespace PromocodeFactory.Repositories
{
    public class InMemoryEmployeeRepository: Models.IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public InMemoryEmployeeRepository()
        {
            // Тестовые данные вводим в базу  
            _employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Иван", LastName = "Иванов", Position = "Разработчик" },
                new Employee { Id = 2, FirstName = "Петр", LastName = "Петров", Position = "Тестировщик" },
                new Employee { Id = 3, FirstName = "Сергей", LastName = "Сергеев", Position = "Тимлид" }
            };
        }

        public Task<Employee> GetById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(employee);
        }
    }
}

