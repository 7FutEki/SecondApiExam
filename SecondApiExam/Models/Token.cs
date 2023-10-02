using System.ComponentModel.DataAnnotations;

namespace SecondApiExam.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
