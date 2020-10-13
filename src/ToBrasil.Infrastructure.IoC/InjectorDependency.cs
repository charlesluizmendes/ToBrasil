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
using ToBrasil.Infrastructure.Identity.Service;

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

            // Data

            container.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddScoped<IUserRepository, UserRepository>();
            container.AddScoped<IPhoneRepository, PhoneRepository>();

            // Identity

            container.AddScoped<ITokenService, TokenService>();
        }
    }
}
