using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Angular_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Angular_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    GetEmployees();
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpGet]
        public IEnumerable<Employees> GetEmployees()
        {
            List<Employees> employeeList = new List<Employees>();
            string CS = configuration.GetConnectionString("EmployeeDatabase");//ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM employees", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var employee = new Employees();
                    employee.EmployeeId = Convert.ToInt32(rdr["employee_id"]);
                    employee.FirstName = rdr["first_name"].ToString();
                    employee.LastName = rdr["first_name"].ToString();
                    employee.Email = rdr["email"].ToString();
                    employee.PhoneNumber = rdr["phone_number"].ToString();
                    employee.JobID = rdr["job_id"].ToString();
                    employee.Salary = rdr["salary"].ToString();
                    employee.ManagerID = rdr["manager_id"].ToString();
                    employee.DepartmentID = rdr["department_id"].ToString();
                    employeeList.Add(employee);
                }
            }
            return employeeList.ToArray();
        }
    }
}
