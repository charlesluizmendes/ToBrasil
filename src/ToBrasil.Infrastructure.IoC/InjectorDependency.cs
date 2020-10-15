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
using ToBrasil.Infrastructure.Data.Repository;
using ToBrasil.Infrastructure.Identity.Services;

namespace ToBrasil.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Command and Query

            container.AddMediatR(Assembly.GetExecutingAssembly());           
            container.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserCommandHandler>();
            container.AddTransient<IRequestHandler<GetUserByEmailQuery, User>, GetUserByEmailQueryHandler>();
            container.AddTransient<IRequestHandler<GetUserByLoginQuery, User>, GetUserByLoginQueryHandler>();

            // Services

            container.AddScoped<ITokenService, TokenService>();

            // Repository

            container.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddScoped<IUserRepository, UserRepository>();
            container.AddScoped<IPhoneRepository, PhoneRepository>();
        }
    }
}
