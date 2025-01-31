using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainSMS.Entities
{
    public class Contract
    {
        public Contract(int difficulty, double miningReward, double transactionFee)
        {
            Difficulty = difficulty;
            MiningReward = miningReward;
            TransactionFee = transactionFee;
            Blocks = new List<Block>();
            PendingTransactions = new List<Transaction>();


            var genesisBlock = new Block(0, "0");
            genesisBlock.MineBlock(difficulty);
            Blocks.Add(genesisBlock);
        }

        public int Difficulty { get; }
        public List<Block> Blocks { get; }
        public double MiningReward { get; }
        public double TransactionFee { get; }
        public double MinimumTransactionFee { get; }
        public List<Transaction> PendingTransactions { get; private set; }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction.Fee < MinimumTransactionFee)
            {
                throw new Exception("Transaction fee is too low!");

                PendingTransactions.Add(transaction);
            }
        }

        public void MinePendingTransactions(string minerAddress)
        {
            var block = new Block(Blocks.Count, Blocks[^1].Hash);

            foreach (var transaction in PendingTransactions)
                block.AddTransaction(transaction);

            block.AddTransaction(new Transaction(null, minerAddress, "Mining Reward", MiningReward));
            block.MineBlock(Difficulty);

            Blocks.Add(block);
            PendingTransactions.Clear();
        }

        public override string ToString()
        {
            return $"Blockchain with {Blocks.Count} blocks.";
        }
    }
}
