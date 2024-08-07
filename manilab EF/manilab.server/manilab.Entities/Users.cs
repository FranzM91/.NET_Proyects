using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manilab.Entities
{
    public class Users
    {
        [Key]
        [StringLength(36)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(15)]
        public string cel { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string email { get; set; }
    }
}
