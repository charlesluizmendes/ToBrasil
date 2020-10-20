using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Infrastructure.Data.Context;
using ToBrasil.Infrastructure.Data.Factory;

namespace ToBrasil.Infrastructure.Data.Repository
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        private readonly ToBrabilFactory _factory;
        private readonly ToBrasilContext _context;

        public UserRepository(ToBrabilFactory factory,
            ToBrasilContext context)
            : base(factory, context)
        {
            _factory = factory;
            _context = context;
        }

        public override async Task<IEnumerable<Users>> GetAllAsync()
        {
            try
            {
                var result = await _factory.GetConnection()
                    .QueryAsync<Users, Phone, Token, Users>($"" +
                    $"Select * From Users " +
                    $"Inner Join Phone on Users.Id = Phone.UserId " +
                    $"Left Join Token on Users.Id = Token.UserId " +
                    $"", map: (users, phone, token) =>
                    {
                        if (phone != null)
                            users.Phones = new List<Phone>();
                            users.Phones.Add(phone);

                        if (token != null)
                            users.Token = token;

                        return users;
                    });

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<Users> GetByIdAsync(object id)
        {
            try
            {
                var result = await _factory.GetConnection()
                    .QueryAsync<Users, Phone, Token, Users>($"" +
                    $"Select * From Users " +
                    $"Inner Join Phone on Users.Id = Phone.UserId " +
                    $"Left Join Token on Users.Id = Token.UserId " +
                    $"Where Users.Id = '{ id }'" +
                    $"", map: (users, phone, token) =>
                    {
                        if (phone != null)
                            users.Phones = new List<Phone>();
                            users.Phones.Add(phone);

                        if (token != null)
                            users.Token = token;

                        return users;
                    });

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> GetUserByEmailAsync(Users user)
        {
            try
            {
                var result = await _factory.GetConnection()
                    .QueryAsync<Users, Phone, Token, Users>($"" +
                    $"Select * From Users " +
                    $"Inner Join Phone on Users.Id = Phone.UserId " +
                    $"Left Join Token on Users.Id = Token.UserId " +
                    $"Where Users.Email = '{ user.Email }'" +
                    $"", map: (users, phone, token) =>
                    {
                        if (phone != null)
                            users.Phones = new List<Phone>();
                            users.Phones.Add(phone);

                        if (token != null)
                            users.Token = token;

                        return users;
                    });

                return result.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
