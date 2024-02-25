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
    "mondayStart": null,
    "mondayEnd": null,
    "tuesdayStart": null,
    "tuesdayEnd": null,
    "wednesdayStart": null,
    "wednesdayEnd": null,
    "thursdayStart": null,
    "thursdayEnd": null,
    "fridayStart": null,
    "fridayEnd": null,
    "saturdayStart": null,
    "saturdayEnd": null,
    "sundayStart": null,
    "sundayEnd": null
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
    /*
    * HTTP: GET
    * URL: /api/employees
    */
    [HttpGet]
    public IActionResult GetAllEmployee()
    {
        // Retrieve all employees
        var employees = _dbContext.Employee.ToList();

        if (employees == null || employees.Count == 0)
        {
            // Return a 404 Not Found if no employees are found
            return NotFound();
        }

        // Return the list of employees with a 200 OK status
        return Ok(employees);
    }

    /*
    * HTTP: DELETE
    * URL: /api/employees/{id}
    */
    [HttpDelete("{id}")]
    public IActionResult RemoveEmployee(int id)
    {
        // Retrieve the employee by id
        var employee = _dbContext.Employee.Find(id);

        if (employee == null)
        {
            // Return a 404 Not Found if the employee is not found
            return NotFound();
        }


        // Remove the employee from the database
        _dbContext.Employee.Remove(employee);
        _dbContext.SaveChanges();  // Save changes to persist the removal

        // Return a 200 OK status
        return Ok();
    }
}
