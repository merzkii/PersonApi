using Application.DTO_s;
using Application.DTO_s.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.DTO_s.Phone
{
    public class GetPhonesDTO:PhoneDTO
    {
        public PersonDTO Person { get; set; }
    }
}
