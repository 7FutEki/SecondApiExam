using SecondApiExam.Models;

namespace SecondApiExam.Interfaces
{
    public interface IUserRepository
    {
        bool Add(User user);
        bool Save();
        User Get(User user);
        User GetByLoginAndPass(string login, string Pass);
        User GetOr(User user);
    }
}
