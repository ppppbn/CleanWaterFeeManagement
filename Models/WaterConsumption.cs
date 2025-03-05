namespace CleanWaterFeeManagement.Models
{
    public class WaterConsumption
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RecordedMonth { get; set; }
        public int RecordedYear { get; set; }
        public decimal Value { get; set; }
        public int RecordedBy { get; set; }
    }
}
