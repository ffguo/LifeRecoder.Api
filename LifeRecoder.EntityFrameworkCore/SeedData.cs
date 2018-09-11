using LifeRecoder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeRecoder.EntityFrameworkCore
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LifeDbContext(serviceProvider.GetRequiredService<DbContextOptions<LifeDbContext>>()))
            {
                if (context.Users.Any())
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
                        UserName = "ffg",
                        PassWord = "123",
                        NickName = "疯疯过"
                    },
                    new User
                    {
                        Id = new Guid(),
                        UserName = "wcq",
                        PassWord = "321",
                        NickName = "翁超群"
                    }
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
