using SecondApiExam.Data;
using SecondApiExam.Interfaces;
using SecondApiExam.Models;

namespace SecondApiExam.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _db;

        public UserRepository(ApplicationContext db)
        {
            _db = db;
        }
        public bool Add(User user)
        {
            _db.Add(user);
            return Save();
        }

        public User Get(User user)
        {
            var u = _db.Users.FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);
            return u;
        }
        public User GetOr(User user)
        {
            var u = _db.Users.FirstOrDefault(x => x.Login == user.Login);
            return u;
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public User GetByLoginAndPass(string login, string Pass)
        {
            return _db.Users.FirstOrDefault(x => x.Login == login && x.Password == Pass);
        }
    }
}
