namespace CleanWaterFeeManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerCode { get; set; }
        public string WaterMeterCode { get; set; }
        public int CreatedBy { get; set; }
    }
}
