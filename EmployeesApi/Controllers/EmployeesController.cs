using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        // GET /
        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            return Ok();
        }

        // GET/{id}

        // POST /
    }
}
