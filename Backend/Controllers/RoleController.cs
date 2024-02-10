using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Context;



namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*
        * HTTP: GET
        * URL: /api/role
        */
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            // Retrieve all roles
            var roles = _dbContext.Role.ToList();

            if (roles == null || roles.Count == 0)
            {
                // Return a 404 Not Found if no roles are found
                return NotFound();
            }

            // Return the list of roles with a 200 OK status
            return Ok(roles);
        }





    }
}