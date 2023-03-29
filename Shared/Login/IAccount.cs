using JetBrains.Annotations;
using System;

namespace Shared.Login
{
        [PublicAPI]
        public interface IAccount 
        {
            string Email { get; set; }

            string Password { get; set; }

            DateTime DateOfRegistration { get; set; }

            DateTime? LastLogin { get; set; }
        }
}
