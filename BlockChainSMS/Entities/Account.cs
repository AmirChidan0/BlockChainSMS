using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainSMS.Entities
{
    public class Account
    {
        public Account(string address)
        {
            Address = address;

            Balance = 0;

        }

        public string Address { get; private set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            return $"{Address}: {Balance} units";
        }
    }
}
