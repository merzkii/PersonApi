﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Phone
{
    public class UpdateSharedPhoneDTO : SharedPhoneDTO
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public int PersonId { get; set; }
    }
}
