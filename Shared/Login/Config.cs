﻿
namespace Shared.Login
{
    public class Config
    {
        public int LoginAttempts { get; set; } = 5; // Maximum login attempts allowed
        public int BCryptCost { get; set; } = 12; // BCrypt cost
        public int MaxAccountsPerUser { get; set; } = 3; // Maximum numbers of accounts the same user can create
        public int MinPasswordLength { get; set; } = 5; // Minimum password length
        public bool ForceSymbols { get; set; } = true; // Force passwords to contain at least one symbol
        public bool ForceDigits { get; set; } = true; // Force passwords to contain at least one digit
        public bool ForceMixCase { get; set; } = true; // Force passwords to have both uppercase and lowercase
        public string GlobalSalt { get; set; } = "vzoPZ1ogQv"; // Global salt that will be appended to all inputs for added security
    }
}
