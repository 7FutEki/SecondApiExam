namespace SecondApiExam.Models
{
    public class UserTokenDate
    {
        public User Account { get; set; }
        public string token { get; set; }
        public DateOnly Date { get; set; }
    }
}
