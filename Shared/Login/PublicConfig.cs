using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Login
{
    public class PublicConfig
    {
        public int MinPasswordLength { get; set; }
        public bool ForceSymbols { get; set; }
        public bool ForceDigits { get; set; }
        public bool ForceMixCase { get; set; }

        public PublicConfig()
        {

        }

        public PublicConfig(Config config)
        {
            this.MinPasswordLength = config.MinPasswordLength;
            this.ForceSymbols = config.ForceSymbols;
            this.ForceDigits = config.ForceDigits;
            this.ForceMixCase = config.ForceMixCase;
        }
    }
}
