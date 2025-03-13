using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s
{
    public class PersonDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$|^[\u10A0-\u10FF]+$", ErrorMessage = "Only Georgian or only English letters allowed.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$|^[\u10A0-\u10FF]+$", ErrorMessage = "Only Georgian or only English letters allowed.")]
        public string LastName { get; set; }

        [Required]
        [Range(18, 120, ErrorMessage = "Age must be at least 18 years old.")]
        public DateTime DateOfBirth { get; set; }

        public string Image { get; set; }

        public int cityId { get; set; }
    }
}
