using LifeRecoder.Application.Dto;
using LifeRecoder.Application.IServices;
using LifeRecoder.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace LifeRecoder.Application.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _repository;

        public AccountServices(IAccountRepository repository)
        {
            _repository = repository;

        }

        public List<string> GetAllNickName(Guid gId)
        {
            return _repository.Entities.Where(u => u.TeamId == gId).Select(u => u.NickName).ToList();
        }

        public UserDto Login(LoginUserDto loginUserDto)
        {
            var user = _repository.Entities.FirstOrDefault(u => u.UserName == loginUserDto.UserName && u.PassWord == loginUserDto.PassWord);
            if (user != null)
            { 
                return Mapper.Map<UserDto>(user);
            }
            return null;
        }
    }
}
