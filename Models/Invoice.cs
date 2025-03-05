namespace CleanWaterFeeManagement.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CollectMonth { get; set; }
        public int CollectYear { get; set; }
        public decimal ConsumptionAmount { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
    }
}
