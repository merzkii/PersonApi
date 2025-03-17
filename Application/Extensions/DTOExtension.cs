using Application.DTO_s.Person;
using Application.DTO_s.Phone;
using Core.Models;

namespace Application.Extensions
{
    public static class DTOExtension
    {
        public static GetPersonDTO CreateDTO(this Person person)
        {
            return new GetPersonDTO
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                PersonalNumber = person.PersonalNumber,
                DateOfBirth = person.DateOfBirth,
                cityId = person.CityId,
                ImagePath = person.ImagePath,
                PhoneNumbers = person.PhoneNumbers.Select(p => new PhoneDTO
                {
                    Number = p.Phone.Number,
                    Type = p.Phone.Type
                }).ToList(),

                RelatedIndividuals = person.RelatedIndividuals.Select(p => new ConnectedPersonDTO
                {
                    ConnectionType = p.ConnectionType,
                    PersonId = p.PersonId,
                    ConnectedPersonId = p.ConnectedPersonId,
                }).ToList(),
            };
        }


        public static GetPhonesDTO CreateDTO(this Phone phone)
        {
            return new GetPhonesDTO
            {
                Id = phone.Id,
                Number = phone.Number,
                Type = phone.Type
            };
        }

        public static GetConnectedPersonsDTO CreateDTO(this ConnectedPerson connectedPerson)
        {
            return new GetConnectedPersonsDTO
            {
                Id = connectedPerson.Id,
                ConnectionType = connectedPerson.ConnectionType,
                PersonId = connectedPerson.PersonId,
                ConnectedPersonId = connectedPerson.ConnectedPersonId
            };
        }

        public static GetSharedPhonesDTO CreateDTO(this SharedPhone sharedPhone)
        {
            return new GetSharedPhonesDTO
            {
                Id = sharedPhone.Id,
                PersonId = sharedPhone.PersonId,
                PhoneId = sharedPhone.PhoneId
            };
        }
    }
}
