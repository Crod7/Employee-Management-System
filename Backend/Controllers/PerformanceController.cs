using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PerformanceController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public PerformanceController(ApplicationDbContext context)
    {
      _context = context;
    }

    /*
     * HTTP: GET
     * URL: /api/Performance
     */
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Performance>>> GetPerformances()
    {
      return await _context.Performance.ToListAsync();
    }

    /*
     * HTTP: GET
     * URL: /api/Performance/{id}
     */
    [HttpGet("{id}")]
    public async Task<ActionResult<Performance>> GetPerformance(int id)
    {
      var performance = await _context.Performance.FindAsync(id);

      if (performance == null)
      {
        return NotFound();
      }

      return performance;
    }
    /*
     * Initial Performance Data
     * HTTP: POST
     * URL: /api/Performance
     * BODY: 
      {
        "Sales": 0.00,
        "Date": "2024-01-26T08:00:00Z",
        "EmployeeId": 3 // Must be the emp's ID linked to this performance reveiw.
      }
     */
    [HttpPost]
    public async Task<ActionResult<Performance>>PostPerformance(Performance performance)
    {
      try
      {
        // Ensure the associated employee exists
        var existingEmployee = await _context.Employee.FindAsync(performance.EmployeeId);
        if (existingEmployee == null)
        {
          return BadRequest("Employee not found");
        }

        _context.Performance.Add(performance);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPerformance), new { id = performance.PerformanceId }, performance);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal Server Error: {ex.Message}");
      }
    }

    /*
     * HTTP: PUT
     * URL: /api/Performance/{id}
     * BODY:
     {   
      "PerformanceId": {id},
      "Sales": 0.00,
      "TimeOffDate": "2024-01-26T08:00:00Z",
      "EmployeeId": {emp's original id} // Don't change
      }
     */
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPerformance(int id, Performance performance)
    {
      if (id != performance.PerformanceId)
      {
        return BadRequest("Invalid request: ID mismatch");
      }

      // Validate the model
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        // Check if the Performance with the given ID exists
        var existingRequest = await _context.Performance.FindAsync(id);
        if (existingRequest == null)
        {
          return NotFound("Performance not found");
        }

        // Update the existing request with the values from performance
        _context.Entry(existingRequest).CurrentValues.SetValues(performance);

        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal Server Error: {ex.Message}");
      }

      return NoContent();
    }


    /*
     * HTTP: DELETE
     * URL: /api/Performance/{id}
     */
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerformance(int id)
    {
      var performance = await _context.Performance.FindAsync(id);
      if (performance == null)
      {
        return NotFound();
      }

      _context.Performance.Remove(performance);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool PerformanceExists(int id)
    {
      return _context.Performance.Any(e => e.PerformanceId == id);
    }
  }
}
