using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace JWPROJECT.Models
{
    public class Project
    {
        [Key]
        public int PId { get; set; }
        public string? PName { get; set; }
        public int? PCost { get; set; }
        public string? PDescription { get; set; }
        public DateTime PAdd_Date { get; set; }= DateTime.Now;
      

        public int PStatus { get; set; } = 0;
        public string? PZip {  get; set; }

        public string? PDocument { get; set; }



    }
}
