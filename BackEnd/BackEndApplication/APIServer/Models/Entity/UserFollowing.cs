using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Models.Entity
{
    public class UserFollowing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserFollowingId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
