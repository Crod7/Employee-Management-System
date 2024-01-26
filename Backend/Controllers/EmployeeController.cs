using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Context;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
  private readonly ApplicationDbContext _dbContext;

  public EmployeesController(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  /*
   * Initial Employee Data
   * HTTP: POST
   * URL: /api/employees
   * BODY: 
{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "phone": "123-456-7890",
  "address": "123 Main St",
  "city": "Anytown",
  "state": "CA",
  "postalCode": "12345",
  "roleId": 1,
  "payGradeId": 1,
  "personalInfo": {
    "ssn": null,
    "routingNumber": null,
    "accountNumber": null,
    "birthdate": null,
    "hireDate": null
  },
  "schedule": {
    "mondayStart": "2024-01-26T08:00:00Z",
    "mondayEnd": "2024-01-26T17:00:00Z",
    "tuesdayStart": "2024-01-26T08:00:00Z",
    "tuesdayEnd": "2024-01-26T17:00:00Z",
    "wednesdayStart": "2024-01-26T08:00:00Z",
    "wednesdayEnd": "2024-01-26T17:00:00Z",
    "thursdayStart": "2024-01-26T08:00:00Z",
    "thursdayEnd": "2024-01-26T17:00:00Z",
    "fridayStart": "2024-01-26T08:00:00Z",
    "fridayEnd": "2024-01-26T17:00:00Z",
    "saturdayStart": "2024-01-26T08:00:00Z",
    "saturdayEnd": "2024-01-26T12:00:00Z",
    "sundayStart": "2024-01-26T08:00:00Z",
    "sundayEnd": "2024-01-26T12:00:00Z"
  }
}
 */
  [HttpPost]
  public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
  {
    if (ModelState.IsValid)
    {
      // Add the employee to the database
      _dbContext.Employee.Add(employee);
      await _dbContext.SaveChangesAsync();

      // Return the created employee with a 201 Created status
      return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
    }

    // Return a 400 Bad Request with validation errors if the model is not valid
    return BadRequest(ModelState);
  }


  /*
   * HTTP: GET
   * URL: /api/employees/{id}
   */
  [HttpGet("{id}")]
  public IActionResult GetEmployee(int id)
  {
    // Retrieve the employee by id
    var employee = _dbContext.Employee.Find(id);

    if (employee == null)
    {
      // Return a 404 Not Found if the employee is not found
      return NotFound();
    }

    // Return the employee with a 200 OK status
    return Ok(employee);
  }
}
