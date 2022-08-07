using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entites
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Caption { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        [Required]
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();

    }
}
