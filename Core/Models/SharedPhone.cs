using Core.Basics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class SharedPhone : BaseEntity
    {
        [Required]
        public int PhoneId { get; set; }

        [ForeignKey("PhoneId")]
        public Phone Phone { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
