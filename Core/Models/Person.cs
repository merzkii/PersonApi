using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Personal Number must be exactly 11 digits.")]
        public string PersonalNumber { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [ForeignKey("CityId")]
        public City? City { get; set; }

        public string? ImagePath { get; set; }

        public ICollection<SharedPhone> PhoneNumbers { get; set; } = new List<SharedPhone>();

        public ICollection<ConnectedPerson> RelatedIndividuals { get; set; } = new List<ConnectedPerson>();
    }
}
