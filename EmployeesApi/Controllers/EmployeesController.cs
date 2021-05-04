using EmployeesApi.Data;
using EmployeesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDataContext _context;

        public EmployeesController(EmployeeDataContext context)
        {
            _context = context;
        }

        [HttpHead("{id:int}")]
        public async Task<ActionResult> CheckForEmployee(int id)
        {
            var any = await _context.Employees.Where(e => e.Id == id && e.IsActive).AnyAsync();

            return any ? Ok() : NotFound();
        }

        [HttpHead("emails/{emailAddress}")]
        public async Task<ActionResult> CheckForEmailAddres(string emailAddress)
        {
            var any = await _context.Employees.Where(e => e.IsActive && e.Email == emailAddress).AnyAsync();

            return any ? Ok() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<GetEmployeesResponse>> GetAllEmployees()
        {

            var employees = await _context.Employees
                .Where(e => e.IsActive)
                .Select(e => new GetEmployeesSummaryResponse
                {
                    Id = e.Id,
                    Department = e.Department,
                    FirstName = e.FirstName,
                    LastName = e.LastName
                }).ToListAsync();


            var response = new GetEmployeesResponse();
            response.Data = employees;
            return Ok(response);
        }
        // GET /{id}

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAnEmployee(int id)
        {
            var response = await _context.Employees
                .Where(e => e.Id == id && e.IsActive)
                .Select(e => new GetEmployeeDetailsReponse
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Department = e.Department,
                    Email = e.Email,
                    Phone = e.Phone

                }).SingleOrDefaultAsync();

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }



        }
        // POST /
    }
}
