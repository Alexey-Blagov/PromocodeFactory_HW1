using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Models;
using PromocodeFactory.Repositories;

namespace PromocodeFactory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        //Создаем поля инкапсулированные в контроллер паттерн "репозиторий"
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> GetById(int id)
        {
            var employee = await _repository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            //Испльзуем маппер для получения запроса в случаее найденного результата
            var response = _mapper.Map<EmployeeResponse>(employee);
            return Ok(response);
        }

    }
}
