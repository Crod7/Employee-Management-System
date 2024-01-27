using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Context;

namespace Backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TimeOffRequestsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public TimeOffRequestsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: api/TimeOffRequests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TimeOffRequest>>> GetTimeOffRequests()
    {
      return await _context.TimeOffRequest.ToListAsync();
    }

    // GET: api/TimeOffRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TimeOffRequest>> GetTimeOffRequest(int id)
    {
      var timeOffRequest = await _context.TimeOffRequest.FindAsync(id);

      if (timeOffRequest == null)
      {
        return NotFound();
      }

      return timeOffRequest;
    }
    /*
     * Initial Employee Data
     * HTTP: POST
     * URL: /api/TimeOffRequests
     * BODY: 
      {
        "Description": "Why are you taking off? String",
        "TimeOffDate": "2024-01-26T08:00:00Z",
        "EmployeeId": 3 // Must be the emp's ID requesting the time off.
      }
     */
    [HttpPost]
    public async Task<ActionResult<TimeOffRequest>> PostTimeOffRequest(TimeOffRequest timeOffRequest)
    {
      try
      {
        // Ensure the associated employee exists
        var existingEmployee = await _context.Employee.FindAsync(timeOffRequest.EmployeeId);
        if (existingEmployee == null)
        {
          return BadRequest("Employee not found");
        }

        _context.TimeOffRequest.Add(timeOffRequest);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTimeOffRequest), new { id = timeOffRequest.TimeOffRequestId }, timeOffRequest);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal Server Error: {ex.Message}");
      }
    }

    // PUT: api/TimeOffRequests/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTimeOffRequest(int id, TimeOffRequest timeOffRequest)
    {
      if (id != timeOffRequest.TimeOffRequestId)
      {
        return BadRequest("Invalid request");
      }

      _context.Entry(timeOffRequest).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TimeOffRequestExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/TimeOffRequests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTimeOffRequest(int id)
    {
      var timeOffRequest = await _context.TimeOffRequest.FindAsync(id);
      if (timeOffRequest == null)
      {
        return NotFound();
      }

      _context.TimeOffRequest.Remove(timeOffRequest);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TimeOffRequestExists(int id)
    {
      return _context.TimeOffRequest.Any(e => e.TimeOffRequestId == id);
    }
  }
}
