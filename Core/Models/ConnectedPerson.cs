using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ConnectedPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
