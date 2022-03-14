using System.ComponentModel.DataAnnotations;

namespace MySocialNetwork.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
