using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Infrastructure.Data.Context;
using ToBrasil.Infrastructure.Data.Factory;

namespace ToBrasil.Infrastructure.Data.Repository
{
    public class TokenRepository : BaseRepository<Token>, ITokenRepository
    {
        private readonly ToBrabilFactory _factory;
        private readonly ToBrasilContext _context;

        public TokenRepository(ToBrabilFactory factory,
            ToBrasilContext context)
            : base(factory, context)
        {
            _factory = factory;
            _context = context;
        }
    }
}
