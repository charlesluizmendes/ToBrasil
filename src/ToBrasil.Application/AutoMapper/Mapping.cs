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
            CreateMap<CadastroInputDTO, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => HasherExtension.HashPassword(dto.Password)));
            CreateMap<User, CadastroInputDTO>()
                .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => entity.PasswordHash));

            CreateMap<PhoneDTO, Phone>();
            CreateMap<Phone, PhoneDTO>();
                       
            CreateMap<LoginInputDTO, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, LoginInputDTO>()
                .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => entity.PasswordHash));
        }
    }
}
