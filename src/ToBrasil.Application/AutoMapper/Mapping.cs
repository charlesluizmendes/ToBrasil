using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Application.DTO;
using ToBrasil.Application.Extensions;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CadastroDTO, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, CadastroDTO>()
                .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => entity.PasswordHash));

            CreateMap<PhoneDTO, Phone>();
            CreateMap<Phone, PhoneDTO>();

            CreateMap<LoginDTO, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, LoginDTO>()
                .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => entity.PasswordHash));
        }
    }
}
