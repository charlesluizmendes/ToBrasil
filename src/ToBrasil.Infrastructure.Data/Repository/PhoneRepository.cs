using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Infrastructure.Data.Context;
using ToBrasil.Infrastructure.Data.Factory;

namespace ToBrasil.Infrastructure.Data.Repository
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        private readonly ToBrabilFactory _factory;
        private readonly ToBrasilContext _context;

        public PhoneRepository(ToBrabilFactory factory,
            ToBrasilContext context)
            : base(factory, context)
        {
            _factory = factory;
            _context = context;
        }
    }
}
