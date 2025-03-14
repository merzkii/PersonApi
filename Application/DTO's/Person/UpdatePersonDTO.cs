using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Person
{
    public class UpdatePersonDTO : PersonDTO
    {
        public int Id { get; set; }


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

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Personal number must be exactly 11 digits.")]
        public string PersonalNumber { get; set; }

        public string Image { get; set; }

        public int cityId { get; set; }
    }
}
