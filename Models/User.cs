using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string PhoneNumber { get; set; }
        public Parent? Parent { get; set; }
    }
}
