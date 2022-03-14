using System.ComponentModel.DataAnnotations;

namespace MySocialNetwork.Models
{
    public class AccountRegisterModel
    {
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }
    }
}
