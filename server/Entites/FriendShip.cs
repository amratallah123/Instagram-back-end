using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entites
{
    public enum State
    { 
        pending,
        accepted,
        rejected 
    }
    public class FriendShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("RequesterId")]
        public User? RequesterUser { get; set; }
        public Guid RequesterId { get; set; }
        [ForeignKey("ReceiverId")]

        public User? ReceiverUser { get; set; }
        public Guid ReceiverId { get; set; }
        [Required]
        public State State { get; set; }
    }
}

