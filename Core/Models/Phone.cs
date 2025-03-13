using Core.Basics;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Phone : BaseEntity
    {

        public PhoneType Type { get; set; }
        public string Number { get; set; } = string.Empty;
        public ICollection<SharedPhone> SharedPhone { get; set; }
    }
}
