namespace SecondApiExam.Models
{
    public class Weather
    {
        public int idCity { get; set; }
        public DateOnly Date { get; set; }
        public int Temperature { get; set; }
        public string Description { get; set; }
    }
}
