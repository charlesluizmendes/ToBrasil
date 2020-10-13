using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Infrastructure.Data.Context;

namespace ToBrasil.Infrastructure.Data.Repository
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        private readonly ToBrasilContext _context;

        public PhoneRepository(ToBrasilContext context)
            : base( context)
        {
            _context = context;
        }
    }
}
