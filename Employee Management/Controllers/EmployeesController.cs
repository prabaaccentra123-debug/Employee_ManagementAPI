using EmployeeManagement.Dto;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepositary _employeeRepositary;    
    
    public EmployeesController(IEmployeeRepositary employeeRepositary)
    {
        _employeeRepositary = employeeRepositary;     
               
    }

    // GET: api/Employee
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
    {
       
        return Ok(await _employeeRepositary.GetEmployees(cancellationToken));
    }

    // GET: api/Employee/5
    [Authorize]
    [HttpGet("{employeeid}")]
    public async Task<IActionResult> GetEmployee(int employeeid,CancellationToken cancellationToken)
    {
        // Employee ID validation
        if (employeeid == 0) return BadRequest("Employee ID should not be empty or 0");
        var employee = await _employeeRepositary.GetEmployee(employeeid, cancellationToken);

        if (employee == null)
        {
            return NotFound("Employee not found");
        }

        return Ok(employee);
    }

    // POST: api/Employee
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee(EmployeeCreateDto employeeCreateDto, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            EmployeeName = employeeCreateDto.EmployeeName,
            Email = employeeCreateDto.Email,
            Department = employeeCreateDto.Department,
            DateOfJoining = employeeCreateDto.DateOfJoining
        };

        await _employeeRepositary.AddEmployee(employee,cancellationToken);

        return Ok(employee);
    }

    // PUT: api/Employee/5
     [Authorize]
    [HttpPut("{employeeid}")]
    public async Task<IActionResult> PutEmployee(int employeeid, EmployeeUpdateDto employeeUpdateDto, CancellationToken cancellationToken)
    {
        // Header and request body validation
        if (employeeid != employeeUpdateDto.EmployeeId)
        {
            return BadRequest("Id does not match");
        }

        var employee = await _employeeRepositary.GetEmployee(employeeid, cancellationToken);

        if (employee == null)
        {
            return NotFound("Employee not found");
        }

        // Create entity from Dto
        employee.EmployeeName = employeeUpdateDto.EmployeeName;
        employee.Email = employeeUpdateDto.Email;
        employee.Department = employeeUpdateDto.Department;
        employee.DateOfJoining = employeeUpdateDto.DateOfJoining;

        await _employeeRepositary.UpdateEmployee(employee, cancellationToken);

        return Ok(employee);

    }

    // DELETE: api/Employee/5
    [Authorize]
    [HttpDelete("{employeeid}")]
    public async Task<IActionResult> DeleteEmployee(int employeeid, CancellationToken cancellationToken)
    {
        //To find employee
        var employee = await GetEmployee(employeeid, cancellationToken);
        if (employee == null)
        {
            return NotFound("Employee not found");
        }

        await _employeeRepositary.DeleteEmployee(employeeid, cancellationToken);

        return Ok("Employee deleted successfully");
    }
    [AllowAnonymous]
    [HttpGet("token")]
    public IActionResult GetToken(IConfiguration _configuration)
    {
        
        // key
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }


}
