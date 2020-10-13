using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Application.Interfaces;
using ToBrasil.Application.Services;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;
using ToBrasil.Domain.Services;
using ToBrasil.Infrastructure.Data.Repository;

namespace ToBrasil.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Application

            container.AddScoped(typeof(IBaseAppService<>), typeof(BaseAppService<>));
            container.AddScoped<IUserAppService, UserAppService>();
            container.AddScoped<IPhoneAppService, PhoneAppService>();

            // Domain

            container.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            container.AddScoped<IUserService, UserService>();
            container.AddScoped<IPhoneService, PhoneService>();

            // Infrastructure

            container.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddScoped<IUserRepository, UserRepository>();
            container.AddScoped<IPhoneRepository, PhoneRepository>();
        }
    }
}
