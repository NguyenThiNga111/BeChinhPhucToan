using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Guardian { get; set; }        
        public bool? IsVerify { get; set; }
        public string? OtpCode { get; set; }
        public DateTime? OtpExpiration { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
