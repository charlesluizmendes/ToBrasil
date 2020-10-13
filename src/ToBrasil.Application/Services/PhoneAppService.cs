using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Application.Interfaces;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services
{
    public class PhoneAppService : BaseAppService<Phone>, IPhoneAppService
    {
        public readonly IPhoneService _phoneService;

        public PhoneAppService(IPhoneService phoneService)
            : base(phoneService)
        {
            _phoneService = phoneService;
        }
    }
}
