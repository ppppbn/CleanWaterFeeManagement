using System.Collections.Generic;
using System.Data;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.BusinessLogic
{
    public class EmployeeService
    {
        public static DataTable GetEmployeeData()
        {
            return EmployeeDAO.GetEmployeeData();
        }

        public static void InitializeDataAdapter()
        {
            EmployeeDAO.InitializeDataAdapter(); // ✅ Calls DAO method to reinitialize data adapter
        }


        public static void SaveEmployeeChanges(DataTable updatedTable)
        {
            EmployeeDAO.SaveEmployeeChanges(updatedTable);
        }

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
            List<Employee> employees = EmployeeDAO.GetAllEmployees();
            return employees;
        }


        public static Employee AuthenticateUser(string username, string password)
        {
            return EmployeeDAO.AuthenticateUser(username, password);
        }

    }
}
