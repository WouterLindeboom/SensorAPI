namespace SensorAPI.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime Date { get; set; }

        public int CityId { get; set; }

    }
}
