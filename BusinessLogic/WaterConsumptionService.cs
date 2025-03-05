using System.Collections.Generic;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.BusinessLogic
{
    public class WaterConsumptionService
    {
        public static bool RecordWaterConsumption(int customerId, int recordedMonth, int recordedYear, decimal value, int recordedBy)
        {
            WaterConsumption consumption = new WaterConsumption
            {
                CustomerId = customerId,
                RecordedMonth = recordedMonth,
                RecordedYear = recordedYear,
                Value = value,
                RecordedBy = recordedBy
            };
            return WaterConsumptionDAO.AddWaterConsumption(consumption);
        }

        public static bool EditWaterConsumption(int id, int customerId, int recordedMonth, int recordedYear, decimal value, int recordedBy)
        {
            WaterConsumption consumption = new WaterConsumption
            {
                Id = id,
                CustomerId = customerId,
                RecordedMonth = recordedMonth,
                RecordedYear = recordedYear,
                Value = value,
                RecordedBy = recordedBy
            };
            return WaterConsumptionDAO.UpdateWaterConsumption(consumption);
        }

        public static bool RemoveWaterConsumption(int id)
        {
            return WaterConsumptionDAO.DeleteWaterConsumption(id);
        }

        public static List<WaterConsumption> GetWaterConsumptions()
        {
            return WaterConsumptionDAO.GetAllWaterConsumptions();
        }
    }
}
