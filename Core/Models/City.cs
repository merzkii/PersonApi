using Core.Basics;

namespace Core.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public List<Person> Persons { get; set; }
    }
}
