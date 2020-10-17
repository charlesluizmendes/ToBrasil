using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ToBrasil.Application.Services.Command;
using ToBrasil.Application.Services.Query;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;
using ToBrasil.Domain.Services;
using ToBrasil.Infrastructure.Data.Factory;
using ToBrasil.Infrastructure.Data.Repository;
using ToBrasil.Infrastructure.Identity.Services;

namespace ToBrasil.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Factory

            container.AddSingleton<ToBrabilFactory>();

            // Command and Query

            container.AddMediatR(Assembly.GetExecutingAssembly());           
            container.AddTransient<IRequestHandler<CreateUserCommand, Users>, CreateUserCommandHandler>();
            container.AddTransient<IRequestHandler<GetUserByEmailQuery, Users>, GetUserByEmailQueryHandler>();
            container.AddTransient<IRequestHandler<GetUserByLoginQuery, Users>, GetUserByLoginQueryHandler>();

            // Service

            container.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            container.AddScoped<IUserService, UserService>();
            container.AddScoped<ITokenService, TokenService>();
            container.AddScoped<IPhoneService, PhoneService>();

            // Repository

            container.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddScoped<IUserRepository, UserRepository>();
            container.AddScoped<ITokenRepository, TokenRepository>();
            container.AddScoped<IPhoneRepository, PhoneRepository>();

            // Identity

            container.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
