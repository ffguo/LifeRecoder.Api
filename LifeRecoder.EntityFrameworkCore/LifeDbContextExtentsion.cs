using LifeRecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LifeRecoder.Utility;

namespace LifeRecoder.EntityFrameworkCore
{
    public static class LifeDbContextExtentsion
    {
        public static void EnsureSendData(this LifeDbContext context)
        {
            if (context.Teams.Any() || context.Users.Any())
            {
                return;   // 已经初始化过数据，直接返回
            }
            Guid teamId = Guid.NewGuid();
            context.Teams.Add(new Team
            {
                Id = teamId,
                TeamName = "603",
                TotalMoney = 100,
            });
            List<User> users = new List<User>
                {
                    new User
                    {
                        Id = new Guid(),
                        UserName = "lyx",
                        PassWord = EncryptionMD5.Get32MD5One("123456"),
                        NickName = "柳一雄",
                        TeamId = teamId
                    },
                    new User
                    {
                        Id = new Guid(),
                        UserName = "hqy",
                        PassWord = EncryptionMD5.Get32MD5One("123456"),
                        NickName = "胡秋彦",
                        TeamId = teamId
                    },
                    new User
                    {
                        Id = new Guid(),
                        UserName = "cmh",
                        PassWord = EncryptionMD5.Get32MD5One("654321"),
                        NickName = "陈敏航",
                        TeamId = teamId
                    },
                    new User
                    {
                        Id = new Guid(),
                        UserName = "zlj",
                        PassWord = EncryptionMD5.Get32MD5One("123456"),
                        NickName = "邹立杰",
                        TeamId = teamId
                    },
                    new User
                    {
                        Id = new Guid(),
                        UserName = "ffg",
                        PassWord = EncryptionMD5.Get32MD5One("ffg123"),
                        NickName = "翁超群",
                        TeamId = teamId
                    }
                };
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
