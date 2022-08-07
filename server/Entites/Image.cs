using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entites
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string? Photo { get; set; }
        [ForeignKey("PostId")]

        public Post? Post { get; set; }
        public Guid PostId { get; set; }

    }
}
