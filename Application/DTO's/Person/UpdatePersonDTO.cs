using Application.Attributes;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Person
{
    public class UpdatePersonDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [LanguageValidation(ErrorMessage = "Only Georgian or only English letters allowed.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [LanguageValidation(ErrorMessage = "Only Georgian or only English letters allowed.")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Personal number must be exactly 11 digits.")]
        public string PersonalNumber { get; set; }

        [Required]
        [Age(18)]
        public DateTime DateOfBirth { get; set; }

        public int cityId { get; set; }

       

    }
}
