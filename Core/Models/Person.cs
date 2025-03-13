using Core.Enums;
using Core.Basics;

namespace Core.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public string PersonalNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<SharedPhone> PhoneNumbers { get; set; } = new List<SharedPhone>();
        public ICollection<ConnectedPerson> RelatedIndividuals { get; set; } = new List<ConnectedPerson>();
        
    }
}
