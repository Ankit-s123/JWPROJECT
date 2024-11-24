using System.ComponentModel.DataAnnotations;

namespace JWPROJECT.Models
{
    public class Contact
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
        public string CEmail { get; set; }
        public string CSubject { get; set; }
        public string CMessage { get; set; }
    }
}
