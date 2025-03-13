using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Basics;

namespace Core.Models
{
    public class ConnectedPerson : BaseEntity
    {
        public ConnectionType ConnectionType { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public int ConnectedPersonId { get; set; }
        public Person? RelatedPerson { get; set; }
    }
}
