using System.Collections.Generic;
using System.Data;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.BusinessLogic
{
    public class InvoiceService
    {
        public static DataTable GetInvoiceData(int? customerId = null, int? month = null, int? year = null)
        {
            return InvoiceDAO.GetInvoiceData(customerId, month, year);
        }

        public static void SaveInvoiceChanges(DataTable updatedTable)
        {
            InvoiceDAO.SaveInvoiceChanges(updatedTable);
        }

        public static bool CreateInvoice(int customerId, int collectMonth, int collectYear, decimal unitPrice, int createdBy)
        {
            return InvoiceDAO.GenerateInvoice(customerId, collectMonth, collectYear, unitPrice, createdBy);
        }

        public static bool UpdateInvoiceStatus(int id, string status)
        {
            return InvoiceDAO.UpdateInvoice(id, status);
        }

        public static bool RemoveInvoice(int id)
        {
            return InvoiceDAO.DeleteInvoice(id);
        }

        public static List<Invoice> GetInvoices()
        {
            return InvoiceDAO.GetAllInvoices();
        }
    }
}
