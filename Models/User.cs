using System.ComponentModel.DataAnnotations;

namespace JWPROJECT.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }
        public string UName { get; set; }
        public string UEmail { get; set; }
        public string UPhone { get; set; }
        public string UPass { get; set; }
        public string UCPass { get; set; }
        public string UAddress { get; set; }
        public int UStatus { get; set; } = 0;
        public DateTime UAdded_Date { get; set; }= DateTime.Now;

    }
}
