using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class LoginEvents
    {
        public const string Configuration = "mReg:login:configuration";

        public const string AuthenticationStarted = "mReg:login:authentication:started";

        public const string Register = "mReg:login:register";

        public const string Login = "mReg:login:login";

        public const string Registered = "mReg:login:registered";

        public const string LoggedIn = "mReg:login:loggedin";

        public const string GetCurrentAccountsCount = "mReg:login:get:currentaccounts:count";

        public const string GetCurrentAccounts = "mReg:login:get:currentaccounts";
    }
}
