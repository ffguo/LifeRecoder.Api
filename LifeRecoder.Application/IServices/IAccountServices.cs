using LifeRecoder.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.Application.IServices
{
    public interface IAccountServices
    {
        UserDto Login(LoginUserDto loginUserDto);
        List<string> GetAllNickName(Guid gId);
    }
}
