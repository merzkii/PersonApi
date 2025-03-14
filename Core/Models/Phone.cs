using Core.Basics;
using Core.Enums;

namespace Core.Models
{
    public class Phone : BaseEntity
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; } 
        public ICollection<SharedPhone> SharedPhone { get; set; }
    }
}
