using AutoMapper;
using HandleExcel.Common.DTOs;
using HandleExcel.Repositories;
using HandleExcel.Repositories.Interfaces;
using HandleExcel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleExcel.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userTzRepository)
        {
            _userRepository = userTzRepository;
        }

        public List<UserDTO> GetValidTzList()
        {
            return _mapper.Map<List<UserDTO>>(_userRepository.GetValidTz());
        }

        public void IsValidTz(string name,string tz,int age)
        {
            string id = tz.Trim();
            if (id.Length > 9 || id.Length < 5)
            {
                _userRepository.AddInvalidTz(name, tz, age);
                return;
            }
            for (int i = 0; i < id.Length; i++)
            {
                if (!char.IsDigit(id[i]))
                {
                    _userRepository.AddInvalidTz(name, tz, age);
                    return;
                }

            }

            // Pad string with zeros up to 9 digits
            id = id.Length < 9 ? ("00000000" + id).Substring(-9) : id;
            _userRepository.AddValidTz(name, tz, age);
            //return Array
            //      .from(id, Number)
            //        .reduce((counter, digit, i) => {
            //            const step = digit * ((i % 2) + 1);
            //            return counter + (step > 9 ? step - 9 : step);
            //        }) % 10 === 0;
        }

    }
}
