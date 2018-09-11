using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeRecoder.Api.AuthHelper;
using LifeRecoder.Application.Dto;
using LifeRecoder.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeRecoder.Api.Controllers
{
    /// <summary>
    /// 账户相关接口
    /// </summary>
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        private IAccountServices _services;

        public AccountController(IAccountServices services)
        {
            _services = services;
        }

        /// <summary>
        /// 获取当前用户所在团队所有成员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "Client")]
        [Route("NickNames")]
        public IActionResult GetNickNames()
        {
            return Ok(_services.GetAllNickName(JwtHelper.GetPayload(Request).Gid));
        }

        /// <summary>
        /// 登录获取Token接口
        /// </summary>
        /// <param name="loginUserDto">用户信息</param>
        /// <returns>Token和用户昵称</returns>
        [HttpPost]
        [Route("Token")]
        public IActionResult Login([FromBody] LoginUserDto loginUserDto)
        {
            if (loginUserDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = _services.Login(loginUserDto);
            if (userDto != null)
                return GetJWTStr(userDto.Id, userDto.TeamId, userDto.NickName);
            return BadRequest("用户名或密码错误");
        }

        /// <summary>
        /// 获取JWT的重写方法，推荐这种，注意在文件夹OverWrite下
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sub">角色</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token2", Name = "Token2")]
        public JsonResult GetJWTStr(Guid id, Guid gId, string nickName = "匿名", string sub = "Client")
        {
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            TokenModelJWT tokenModel = new TokenModelJWT();
            tokenModel.Uid = id;
            tokenModel.Gid = gId;
            tokenModel.Role = sub;

            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            return Json(new
            {
                Username = nickName,
                Token = jwtStr
            });
        }
    }
}