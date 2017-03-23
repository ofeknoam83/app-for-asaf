using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest.Enity
{
    [Table("UserRelations")]
    public class UserRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index]
        public int UserId { get; set; }
        [Index]
        public int FriendId { get; set; }
    }
}