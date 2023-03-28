using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResource.Client.Services
{
    public abstract class ClientServices : IClientService
    {
        public abstract Task UpdateTick();
    }
}
