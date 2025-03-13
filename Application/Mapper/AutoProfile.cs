using Application.DTO_s.City;
using Application.DTO_s.Person;
using Application.DTO_s.Phone;
using Application.DTO_s;
using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class AutoProfile:Profile
    {
        public AutoProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<ConnectedPerson, ConnectedPersonDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Phone, PhoneDTO>().ReverseMap();
            CreateMap<SharedPhone, SharedPhoneDTO>().ReverseMap();

        }
    }
}
