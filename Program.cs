using System;
using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexTypes;

namespace mi4_exercise14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var provider = "https://ropsten.infura.io/v3/2c64faa795c242d083706a5e3105e830";
            var abi = "[ { \"inputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"constructor\" }, { \"inputs\": [ { \"internalType\": \"string\", \"name\": \"newFact\", \"type\": \"string\" } ], \"name\": \"add\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"count\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"index\", \"type\": \"uint256\" } ], \"name\": \"getFact\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\" } ], \"stateMutability\": \"view\", \"type\": \"function\" } ]"; 
            var address = "0x9f4481052fd01f0e8d17ebac57d6ca8c62360f2c";
            var privateKey = "0x7EB2255581AED1C929A291B65BC3A37FB70BA8C6783FFFABE18D8C6EC5DCFFC1";

            ContractService contractService = new ContractService(provider,address,abi,privateKey);

            var fact = "The Times 03/Jan/2009 Chancellor on brink of second bailout for banks";
            System.Console.WriteLine($"Transaction Hash: {contractService.AddFact(fact)}");
            System.Console.WriteLine("Press Any Key to Exit...");
            System.Console.ReadLine();
        }
        class ContractService
        {
            private readonly Web3 web3;
            private readonly Contract contract;
            private readonly Account account;

            private static readonly HexBigInteger GAS = new HexBigInteger(4600000);

            public ContractService(string provider, string contractAddress, string abi, string privateKey)
            {
                this.account = new Account(privateKey);
                this.web3 = new Web3(account, provider);
                this.contract = web3.Eth.GetContract(abi, contractAddress);
            }

            public string AddFact(string fact)
            {
                var addFactFunction = contract.GetFunction("add");
                var txHash = addFactFunction.SendTransactionAsync(account.Address, GAS, new HexBigInteger(0), fact)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
                return txHash;
            }
        }
    }
}
