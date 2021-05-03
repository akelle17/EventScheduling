using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Models
{
    public record GetEmployeeDetailsReponse
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Department { get; init; }
        public decimal Salary { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
    }
}
