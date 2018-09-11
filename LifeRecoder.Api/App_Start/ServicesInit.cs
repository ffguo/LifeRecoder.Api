using LifeRecoder.Application.IServices;
using LifeRecoder.Application.Services;
using LifeRecoder.Domain.IRepositories;
using LifeRecoder.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeRecoder.Api
{
    public static class ServicesInit
    {
        public static void Init(IServiceCollection services)
        {
            ApplicationInit(services);
            RepositoriesInit(services);
        }

        private static void RepositoriesInit(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        private static void ApplicationInit(IServiceCollection services)
        {
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IAccountServices, AccountServices>();
        }
    }
}
