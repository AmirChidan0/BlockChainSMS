using BlockChainSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainSMS.Entities
{
    public class Block
    {
        public Block(int index, string previousHash)
        {
            Index = index;
            PreviousHash = previousHash;
            Timestamp = DateTime.Now;
            Transactions = new List<Transaction>();
        }
        public int Index { get; }
        public string PreviousHash { get; }
        public string Hash { get; private set; }
        public DateTime Timestamp { get; }
        public List<Transaction> Transactions { get; }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void MineBlock(int difficulty)
        {
            string prefix = new string('0', difficulty);

            do
            {
                Hash = Utility.GetSha256($"{Index}{PreviousHash}{Timestamp}{string.Join("", Transactions)}");
            } while (!Hash.StartsWith(prefix));
        }

        public override string ToString()
        {
            return $"Block #{Index} [Hash : {Hash}, Transactions : {Transactions.Count}]";
        }
    }
}
