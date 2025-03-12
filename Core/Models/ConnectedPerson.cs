using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Basics;

namespace Core.Models
{
    public class ConnectedPerson : BaseEntity
    {
        [Required]
        public ConnectionType ConnectionType { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey("IndividualId")]
        public Person? Person { get; set; }

        [Required]
        public int ConnectedPersonId { get; set; }

        [ForeignKey("RelatedIndividualId")]
        public Person? RelatedPerson { get; set; }
    }
}
