using HandleExcel.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleExcel.Services.Interfaces
{
    public interface IUserService
    {
        void IsValidTz(string name,string tz,int age);
        List<UserDTO> GetValidTzList();
    }
}
