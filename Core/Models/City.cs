using Core.Basics;
using System.Text.Json.Serialization;

namespace Core.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public List<Person> Persons { get; set; }
    }
}
