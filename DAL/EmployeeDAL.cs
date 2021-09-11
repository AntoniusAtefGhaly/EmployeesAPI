using EmployeesAPI.Data;
using EmployeesAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.DAL
{
    public static class EmployeeDAL
    {

        //get all employee
        public static List<Employee> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Employees.ToList();
            }            
        }
        //dget employee by id
        public static Employee Get(Guid id)
        {
            using (var db = new DBContext())
            {
                return db.Employees.FirstOrDefault(e=>e.Id==id);
            }
        }
        //add employee
        public static bool Add(Employee employee)
        {
            using (var db = new DBContext())
            {
                try
                {
                    employee.Id = Guid.NewGuid();
                    db.Employees.Add(employee);
                    employee.Id = Guid.NewGuid();
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    EmployeeTaxs employeeTaxs = new EmployeeTaxs
                    {
                        Id = Guid.NewGuid(),
                        EmployeeId = employee.Id,
                        Tax =employee.Salary * 0.1f,
                        NetSalary=employee.Salary*0.9f
                    };
                    db.EmployeeTaxs.Add(employeeTaxs);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //update employee
        public static bool Update(Guid id, Employee editEmployee)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var employee = db.Employees.FirstOrDefault(e => e.Id == id);
                    EmployeeTaxs employeeTaxs = db.EmployeeTaxs.FirstOrDefault(e => e.EmployeeId == id);
                    if (employee == null)
                        return false;
                    employee.Mobile = editEmployee.Mobile;
                    employee.Name = editEmployee.Name;
                    employee.Email = editEmployee.Email;
                    employee.Salary = editEmployee.Salary;
                    if (employeeTaxs == null)
                    {
                        employeeTaxs = new EmployeeTaxs
                        {
                            Id = Guid.NewGuid(),
                            EmployeeId = employee.Id,
                            Tax = employee.Salary * 0.1f,
                            NetSalary = employee.Salary * 0.9f
                        };
                        db.EmployeeTaxs.Add(employeeTaxs);
                        db.SaveChanges();
                    }
                    else
                    {
                        employeeTaxs.EmployeeId = employee.Id;
                        employeeTaxs.Tax = employee.Salary * 0.1f;
                        employeeTaxs.NetSalary = employee.Salary * 0.9f;
                        };
                    db.EmployeeTaxs.Update(employeeTaxs);
                    db.Employees.Update(employee);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Delete employee
        public static bool Delete(Guid id)
        {
            using (var db = new DBContext())
            {
                var employee = db.Employees.FirstOrDefault(e=>e.Id==id);
                if (employee == null)
                    return false;
                try
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}