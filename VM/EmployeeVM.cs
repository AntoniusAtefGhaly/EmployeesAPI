using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.VM
{
    public class EmployeeVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }
        public float NetSalary { get; set; }
    }
}
