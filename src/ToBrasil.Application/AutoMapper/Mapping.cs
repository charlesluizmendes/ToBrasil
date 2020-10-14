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
                .ForMember(entity => entity.UserName, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => HasherExtension.HashPassword(dto.Password)))
                .ForMember(entity => entity.Phone, opt => opt.MapFrom(dto => dto.Phones))
                .ForMember(entity => entity.Created, opt => opt.MapFrom(dto => DateTime.Now))
                .ForMember(entity => entity.Modified, opt => opt.MapFrom(dto => DateTime.Now));
            CreateMap<User, CadastroInputDTO>();                      

            CreateMap<CadastroOutputDTO, User>();
            CreateMap<User, CadastroOutputDTO>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(entity => entity.UserName))
                .ForMember(dto => dto.Phones, opt => opt.MapFrom(entity => entity.Phone));

            CreateMap<LoginInputDTO, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, LoginInputDTO>();

            CreateMap<LoginOutputDTO, User>();
            CreateMap<User, LoginOutputDTO>()
                .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => entity.PasswordHash));

            CreateMap<PhoneDTO, Phone>();
            CreateMap<Phone, PhoneDTO>();
        }
    }
}
