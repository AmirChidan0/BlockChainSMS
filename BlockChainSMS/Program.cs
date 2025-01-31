using BlockChainSMS.Entities;

var blockchain = new Contract(2, 10, 0.1);

var Amir = new Account("1");
var Hossein = new Account("2");

blockchain.AddTransaction(new Transaction(Amir.Address, Hossein.Address, "Hello Amir!", 0.15));
blockchain.MinePendingTransactions("Miner1");

Console.WriteLine(blockchain);
