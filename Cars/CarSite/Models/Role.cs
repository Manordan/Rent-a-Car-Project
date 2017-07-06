using System.ComponentModel.DataAnnotations;

namespace CarSite.Models
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Authorization { get; set; }
        [StringLength(9)]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
