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
        private readonly IMapper _mapper; // <-- ќбъ€вл€ем поле дл€ IMapper
        private readonly Models.IEmployeeRepository _repository;

        // IMapper будет передан автоматически через конструктор
        public EmployeesController(Models.IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> GetById(int id)
        {
            var employee = await _repository.GetById(id);
            if (employee == null)
                return NotFound();

            // »спользуем IMapper дл€ преобразовани€ Employee в EmployeeResponse
            var response = _mapper.Map<EmployeeResponse>(employee);
            return Ok(response);
        }
    }
}
