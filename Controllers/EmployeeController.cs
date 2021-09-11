using EmployeesAPI.DAL;
using EmployeesAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return EmployeeDAL.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(Guid id)
        {
            return EmployeeDAL.Get(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public bool add([FromBody] Employee employee)
        {
return            EmployeeDAL.Add(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public bool update(Guid id, [FromBody] Employee employee)
        {
            return EmployeeDAL.Update(id,employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return EmployeeDAL.Delete(id);
        }
    }
}