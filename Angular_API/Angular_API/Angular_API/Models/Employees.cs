using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_API.Models
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public DateTime HireDate { get; set; }
        public string JobID { get; set; }
        public string Salary { get; set; }
        public string ManagerID { get; set; }
        public string DepartmentID { get; set; }
    }
}
