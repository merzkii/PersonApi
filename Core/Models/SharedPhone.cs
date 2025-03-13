using Core.Basics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
