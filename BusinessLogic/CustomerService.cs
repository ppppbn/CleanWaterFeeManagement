using System.Collections.Generic;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.BusinessLogic
{
    public class CustomerService
    {
        public static bool AddCustomer(string name, string phoneNumber, string waterMeterCode, int createdBy)
        {
            Customer customer = new Customer
            {
                Name = name,
                PhoneNumber = phoneNumber,
                WaterMeterCode = waterMeterCode,
                CreatedBy = createdBy
            };
            return CustomerDAO.AddCustomer(customer);
        }

        public static bool EditCustomer(int id, string name, string phoneNumber, string waterMeterCode)
        {
            Customer customer = new Customer
            {
                Id = id,
                Name = name,
                PhoneNumber = phoneNumber,
                WaterMeterCode = waterMeterCode
            };
            return CustomerDAO.UpdateCustomer(customer);
        }

        public static bool RemoveCustomer(int id)
        {
            return CustomerDAO.DeleteCustomer(id);
        }

        public static List<Customer> GetCustomers()
        {
            return CustomerDAO.GetAllCustomers();
        }
    }
}
