using SecondApiExam.Models;

namespace SecondApiExam.Interfaces
{
    public interface ITokenRepository
    {
        bool Add(Token token);
        string Get();
        bool DeleteAll();
        bool Save();
    }
}
