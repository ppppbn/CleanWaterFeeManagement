using System.Collections.Generic;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.BusinessLogic
{
    public class EmployeeService
    {
        public static bool RegisterEmployee(string name, string username, string password, string role)
        {
            Employee employee = new Employee
            {
                Name = name,
                Username = username,
                Password = password,
                Role = role
            };
            return EmployeeDAO.AddEmployee(employee);
        }

        public static bool EditEmployee(int id, string name, string username, string password, string role)
        {
            Employee employee = new Employee
            {
                Id = id,
                Name = name,
                Username = username,
                Password = password,
                Role = role
            };
            return EmployeeDAO.UpdateEmployee(employee);
        }

        public static bool RemoveEmployee(int id)
        {
            return EmployeeDAO.DeleteEmployee(id);
        }

        public static List<Employee> GetEmployees()
        {
            return EmployeeDAO.GetAllEmployees();
        }
    }
}
