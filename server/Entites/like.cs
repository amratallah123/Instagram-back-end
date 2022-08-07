using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entites
{
    public class Like
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string? CommentContent { get; set; }
        [ForeignKey("PostId")]

        public Post? Post { get; set; }
        public Guid PostId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public Guid UserId { get; set; }
    }
}
