using System.ComponentModel.DataAnnotations;

namespace MySocialNetwork.Models
{
    public class SubscribeModel
    {
        [Key]
        public int Id { get; set; }
        public int accountId { get; set; }
        public int customerId { get; set; }
    }
}
