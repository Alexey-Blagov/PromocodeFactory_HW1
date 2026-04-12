using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Exceptions;
using PromocodeFactory.Models;
using PromocodeFactory.Repositories;

namespace PromocodeFactory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
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

            var response = _mapper.Map<EmployeeResponse>(employee);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> Create(EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _mapper.Map<Employee>(request);
            var createdEmployee = await _repository.Add(employee);
            if (createdEmployee == null)
            {
                return BadRequest("Role not found.");
            }

            var response = _mapper.Map<EmployeeResponse>(createdEmployee);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeResponse>> Update(int id, EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _mapper.Map<Employee>(request);
            employee.Id = id;

            try
            {
                var updatedEmployee = await _repository.Update(employee);
                if (updatedEmployee == null)
                {
                    return BadRequest("Role not found.");
                }

                var response = _mapper.Map<EmployeeResponse>(updatedEmployee);
                return Ok(response);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
