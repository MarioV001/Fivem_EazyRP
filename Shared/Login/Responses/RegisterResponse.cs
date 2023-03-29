using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Login.Responses
{
    public enum RegisterResponse
    {
        EmailExists,
        AccountLimitReached,
        UnexpectedError,
        Ok
    }
}
