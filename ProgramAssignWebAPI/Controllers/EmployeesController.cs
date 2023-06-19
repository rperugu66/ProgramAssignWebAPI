
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Controllers;
using ProgramAssignWebAPI.Models.Domain;

namespace LoginInfo.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly LoginInfoDbContext _fullStackDbContext;

        public int VAMID { get; private set; }

        public EmployeesController(LoginInfoDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullStackDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employees employeeRequest)
        {
            //employeeRequest.VAMID;
            await _fullStackDbContext.Employees.AddAsync(employeeRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }


        [HttpGet]
        [Route("{VAMID}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int VAMID)
        {
            var employee = await _fullStackDbContext.Employees.FirstOrDefaultAsync(x => x.VAMID == VAMID);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int Id, Employees UpdateEmployeeRequest)
        {
            var employee = await _fullStackDbContext.Employees.FindAsync(Id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.VAMID = UpdateEmployeeRequest.VAMID;
            employee.Name = UpdateEmployeeRequest.Name;
            employee.Email = UpdateEmployeeRequest.Email;
            employee.Password = UpdateEmployeeRequest.Password;
            employee.Role = UpdateEmployeeRequest.Role;
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee);
        }


        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> DeleteEmployee([FromRoute] int Id)
        {
            var employee = await _fullStackDbContext.Employees.FindAsync(Id);
            if (employee == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Employees.Remove(employee);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee);
        }
    [HttpGet]
    [Route("{Email}/{Password}")]
    public async Task<IActionResult> GetEmployeeByEmail([FromRoute] string Email, string Password)
    {
      var employee = await _fullStackDbContext.Employees.FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password);



      if (employee == null)
      {
        return NotFound();
      }
      return Ok(employee);
    }
  }
}
