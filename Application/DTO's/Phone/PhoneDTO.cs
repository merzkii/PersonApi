using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Phone
{
    public class PhoneDTO
    {
        public PhoneType Type { get; set; }
        [StringLength(50, MinimumLength = 4)]
        public string Number { get; set; }
    }
}
