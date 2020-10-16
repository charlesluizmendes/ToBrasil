using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateMap<CadastroInputDTO, Users>()
                .ForMember(entity => entity.UserName, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));                
            CreateMap<Users, CadastroInputDTO>();       
     
            CreateMap<LoginInputDTO, Users>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<Users, LoginInputDTO>();

            CreateMap<UserDTO, Users>();
            CreateMap<Users, UserDTO>()
                 .ForMember(dto => dto.Name, opt => opt.MapFrom(entity => entity.UserName));

            CreateMap<PhoneDTO, Phone>();
            CreateMap<Phone, PhoneDTO>();

            CreateMap<TokenDTO, string[]>();              
            CreateMap<string[], TokenDTO>()
                .ForMember(dto => dto.Token, opt => opt.MapFrom(entity => entity[0]))
                .ForMember(dto => dto.Valid, opt => opt.MapFrom(entity => entity[1]));
        }
    }
}
