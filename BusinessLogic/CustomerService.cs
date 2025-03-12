using System.Collections.Generic;
using System.Data;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.BusinessLogic
{
    public class CustomerService
    {
        public static DataTable GetCustomerData(string filter = null)
        {
            return CustomerDAO.GetCustomerData(filter);
        }

        public static void InitializeDataAdapter()
        {
            CustomerDAO.InitializeDataAdapter(); // ✅ Calls DAO method to reinitialize data adapter
        }


        public static void SaveCustomerChanges(DataTable updatedTable)
        {
            CustomerDAO.SaveCustomerChanges(updatedTable);
        }

        public static bool AddCustomer(string name, string phoneNumber, string waterMeterCode, string customerCode, int createdBy)
        {
            Customer customer = new Customer
            {
                Name = name,
                PhoneNumber = phoneNumber,
                CustomerCode = customerCode,
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
