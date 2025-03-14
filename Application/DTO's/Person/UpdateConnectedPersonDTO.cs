using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Person
{
    public class UpdateConnectedPersonDTO : ConnectedPersonDTO
    {
        public int Id { get; set; }

        [Required]
        public ConnectionType ConnectionType { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        public int ConnectedPersonId { get; set; }
    }
}
