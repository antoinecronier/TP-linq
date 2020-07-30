namespace TP_linq.Entities
{
    public class Car
    {
        public long? Id { get; set; }
        public CarType Type { get; set; }
        public string Registration { get; set; }
        public double? Mileage { get; set; }
    }
}