using VCS.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VCS.Entities.Entities;

namespace VCS.Entities {
    [Table("UserSkills")]
    public class UserSkills : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Skill { get; set; }

        public int UserId { get; set; }
    }
}
