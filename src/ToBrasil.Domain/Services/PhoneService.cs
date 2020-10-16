using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Domain.Services
{
    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
            : base(phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
    }
}
