using HandleExcel.Repositories.Entities;
using HandleExcel.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleExcel.Repositories.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IContext _context;
        public void AddInvalidTz(string fullName,string tz,int age)
        {
            var newUser = new User() { Name=fullName,Tz=tz,Age=age};
            _context.ValidTzs.Add(newUser);
        }

        public void AddValidTz(string fullName, string tz, int age)
        {
            var newUser = new User() { Name = fullName, Tz = tz, Age = age };
            _context.InvalidTzs.Add(newUser);
        }

        public List<User> GetValidTz()
        {
            return _context.ValidTzs;
        }
    }
}
