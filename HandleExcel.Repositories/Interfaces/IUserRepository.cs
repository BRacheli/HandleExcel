using HandleExcel.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleExcel.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public void AddValidTz(string fullName, string tz, int age);
        public void AddInvalidTz(string fullName, string tz, int age);
        public List<User> GetValidTz();

    }
}
