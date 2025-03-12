using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PhoneType Type { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Number { get; set; } = string.Empty;

        public ICollection<SharedPhone> SharedPhone { get; set; }


    }


}
