using Microsoft.IdentityModel.Tokens;
using SecondApiExam.Data;
using SecondApiExam.Interfaces;
using SecondApiExam.Models;

namespace SecondApiExam.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationContext _db;

        public TokenRepository(ApplicationContext db)
        {
            _db = db;
        }
        public bool Add(Token token)
        {
            _db.Add(token);
            return Save();
        }

        public bool DeleteAll()
        {
            _db.Tokens.RemoveRange(_db.Tokens);
            return Save();
        }

        public string Get()
        {
            var token = _db.Tokens.FirstOrDefault();
            return token.Value;
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
