using Application.DTO_s.City;
using Application.DTO_s.Person;
using Application.DTO_s.Phone;
using Application.DTO_s;
using AutoMapper;
using Core.Models;

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

            CreateMap<City, ExistingCityDTO>().ReverseMap();
            CreateMap<ConnectedPerson, UpdateConnectedPersonDTO>().ReverseMap();
            CreateMap<Person, UpdatePersonDTO>().ReverseMap();
            CreateMap<Phone, UpdatePhoneDTO>().ReverseMap();
            CreateMap<SharedPhone, UpdateSharedPhoneDTO>().ReverseMap();

           

        }
    }
}
