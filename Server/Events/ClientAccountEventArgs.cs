using MyResource.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyResource.Server.Events
{
    public class ClientAccountEventArgs : EventArgs
    {
        public Client Client;
        public Account Account;

        public ClientAccountEventArgs(Client client, Account account)
        {
            this.Client = client;
            this.Account = account;
        }
    }
}
