using System.ComponentModel.DataAnnotations;

namespace JWPROJECT.Models
{
    public class Branch
    {
        [Key]
        public int id { get; set; }
        public string? email { get; set; }
        public string? contact { get; set; }
        public string? address { get; set; }
        public string? fb_link { get; set; }
        public string? ins_link { get; set; }
        public string? li_link { get; set; }
        public string? you_link { get; set; }
        public string? logo_image { get; set; }

        public string? description { get; set; }
    }
}
