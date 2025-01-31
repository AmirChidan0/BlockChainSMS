using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainSMS.Entities
{
    public class Transaction
    {
        public Transaction(string sender, string receiver, string message, double fee)
        {
            Sender = sender;
            Receiver = receiver;
            Message = message;
            Fee = fee;
            Timestamp = DateTime.Now;
        }
        public string Sender { get; }
        public string Receiver { get; }
        public string Message { get; }
        public double Fee { get; }
        public DateTime Timestamp { get; }

        public override string ToString()
        {
            return $"{Sender} -> {Message} | Message : {Message} Fee : {Fee} Time : {Timestamp}";
        }
    }
}
