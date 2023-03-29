using Shared.Login;
using Shared.Models.Player;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyResource.Server.Model
{
    public class Account : IAccount
    {
        [Required]
        [StringLength(254, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(60)]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfRegistration { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
