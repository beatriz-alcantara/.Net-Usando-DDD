using AutoMapper;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Extensions.EnumMapping;
using Domain.Enums;

namespace Domain.Map
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            CreateMap<Cliente, ClienteMapper>();
            CreateMap<Pet, PetMapper>();
            CreateMap<Loja, LojaMapper>();
        }
    }
}
