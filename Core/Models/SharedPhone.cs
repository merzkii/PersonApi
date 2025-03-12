using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SharedPhone
    {
        [Key]
        public int Id { get; set; }

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
