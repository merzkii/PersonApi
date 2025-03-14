using Core.Basics;

namespace Core.Models
{
    public class SharedPhone : BaseEntity
    {

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
