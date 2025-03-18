using Application.DTO_s.Phone;
using System.Text.Json.Serialization;

namespace Application.DTO_s.Person
{
    public class GetPersonDTO : PersonDTO
    {
        public int id { get; set; }
        [JsonPropertyOrder(8)]
        public List<PhoneDTO> PhoneNumbers { get; set; }
        [JsonPropertyOrder(9)]
        public List<ConnectedPersonDTO> RelatedIndividuals { get; set; }
        [JsonPropertyOrder(10)]
        public string ImagePath { get; set; }
    }
}
