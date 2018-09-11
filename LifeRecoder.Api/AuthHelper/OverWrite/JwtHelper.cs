using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LifeRecoder.Api.AuthHelper
{
    public class JwtHelper
    {
        public static string secretKey { get; set; } = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";
        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModelJWT tokenModel)
        {
            var dateTime = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),//Id
                new Claim("Group", tokenModel.Gid.ToString()),//角色
                new Claim("Role", tokenModel.Role),//角色
                new Claim(JwtRegisteredClaimNames.Iat,dateTime.ToString(),ClaimValueTypes.Integer64)
            };
            //秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtHelper.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "LifeRecoder",
                claims: claims, //声明集合
                expires: dateTime.AddHours(2),
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJWT SerializeJWT(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role = new object();
            object group = new object();
            try
            {
                jwtToken.Payload.TryGetValue("Role", out role);
                jwtToken.Payload.TryGetValue("Group", out group);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModelJWT
            {
                Uid = Guid.Parse(jwtToken.Id),
                Gid = Guid.Parse(group.ToString()),
                Role = role.ToString(),
            };
            return tm;
        }

        /// <summary>
        /// 获得JWT Payload
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static TokenModelJWT GetPayload(HttpRequest request)
        {
            //检测是否包含'Authorization'请求头
            if (!request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }
            var tokenHeader = request.Headers["Authorization"].ToString();
            return SerializeJWT(tokenHeader);
        }
    }

    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModelJWT
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// 用户所属组Id
        /// </summary>
        public Guid Gid { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

    }
}
