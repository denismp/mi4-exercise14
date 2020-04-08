# mi4-exercise14
Playing with Smart Contracts using Nethereum
Exercises: Playing with Smart Contracts using Nethereum
In this exercise, we will use Nethereum .NET integration library for Ethereum, simplifying the access and smart contract interaction with Ethereum nodes. The exercise will show how to interact with an already deployed contract on the Ethereum Ropsten Testnet.
Goal
•	Deploy and interact with a Smart Contract using Nethereum.
Prerequisites
•	Visual Studio Community 2019.
You may download it here: https://visualstudio.microsoft.com/vs/
 
Then, just continue with the installation steps.
You may find that the setup will prompt you for some miscellaneous plugins. It’s important that you select .NET Desktop Development. As for others, you may select if you fancy them.
Proceed with the installation.
 
1.	Setup the Development Environment
Open the Visual Studio 2019 Software. Then, create a C# .NET Core Console Application:
 
Continue to configure your project specifying the name, location, solution name, and framework.
This exercises uses .NET Framework 4.7.2

Then go to Tools -> NuGet Package Manager -> Manager NuGet Packages for Solution:
 
 
Navigate to Browse and install the following NuGetPackages:
 

Accept any prompts that will show up.

After successful installation, you’ll see these packages in the installed tab, along with other dependencies:
 
 
2.	Implementing the Contract
Import the following namespaces in order to use Nethereum’s Web3 libraries.

 
Inside the Program class, create a class called ContractService, which will be the connection to the Ropsten Testnet. Create 3 read-only private properties for the Web3, the Contract and for an Account, which will be the wallet.
 
Then, create a constructor, which takes 4 parameters: provider of the node, contract address, contract ABI, and a private key for an account/wallet. Putting it all together:
 
We will need HTTPProvidere in order to create our connection to the Ropsten Testnet using Infura.io.
Now, let’s get the necessary Infura.io provider. Go to https://infura.io/ and click [Get started for free]. You may also choose to login if you have registered before.
 
When you are logged in, select on a project (create one first if you already don’t have a project) and take note of the endpoint URL found in the highlighted section:

 
 

Add a Main() entry point just below the ContractService class and add the provider variable:
 
In order to get a contract instance of an already deployed contract, we will need its address and application binary interface. For exercise’s purpose, deploy a simple contract storing an array of facts through Remix IDE using MetaMask Ropsten a provider:
 
If you do not have ETHt, use the MetaMask faucet: https://faucet.metamask.io/ 
Copy the contract’s ABI by compiling the contract and clicking on the ‘ABI’ button below the Compilation Details.
You may not be able to copy the ABI directly in Visual Studio because the ABI is a JSON Object.
You have to escape all string characters (“) by prepending a backslash (\”).

Hint:
Use the editor’s CTRL + H feature to quickly replace these occurrences. Be careful not to replace the quotes in other parts of your program.
  
Then, deploy the contract using Injected Web3 while taking note of the address, copy those values in your C# code. 
 
 
Because the contract owner can only add facts to this contract, export and copy the private key of the account that deployed the contract. Don’t forget to prepend 0x to the private key.
   

Putting it all together, along with an instance of ContractService:
 
3.	Smart Contract Interaction: Writing to the Smart Contract
Return to the ContractService class. Create a method which takes a string as an argument (a fact) and adds it to the contract. We will send an asynchronous transaction - method.SendTransactionAsync(from, gas, value, functionInput) and will not wait to be mined, just get the transaction hash.
 
In the main function, call the method:
 

Then, press Start:
 

A terminal will launch and will contain the transaction hash:
 
Check the transaction hash in in Ropsten Etherscan to confirm if the transaction has succeeded:
 
Try adding a fact using another private key as an account. Hypothesize on what could happen and test it.
 
4.	Smart Contract Interaction: Reading from the Smart Contract
When reading from a Smart Contract, no wallets or private keys are needed. 
In the ContractService class, create a method which gets a fact by a given index and returns a string with the fact. Get the method of the contract and then make an asynchronous call with the index as parameter, which will return Task<string> and get the result:
 
 
Run the program.
 
Finally, create a method, which gets how many facts are stored in the contract:
 
 

Run the program.
 
 
What to Submit?
Create a zip file (e.g. username-playing-smart-contracts-nethereum-web3.zip) containing the following:
•	The implemented .cs program file.
•	A screenshot of the Ropsten Etherscan contract address and its transactions.

Submit your zip file as homework at the course platform.

NOTES:
Make sure you have dotnet installed for MAC from https://dotnet.microsoft.com/download

Start VSC.

In the terminal window, run dotnet new "Console Application" to initialize your project in your project directory.

You will end up with a file called Program.cs that looks like:
using System;

namespace mi4_exercise14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

Use this to install NuGet Package Manager for the MAC

Got to the Extensions Icon on the left and look for NuGet

NuGet Package Manager
jmrog.vscode-nuget-package-manager
jmrog
336,557
Repository
License
Add or remove .NET Core 1.1+ package references to/from your project's .csproj or .fsproj file using Code's Command Palette.
Disable
Uninstall
This extension is enabled globally.

To install the Nethereum.Contracts and Nethereum.Web3
1. Click on View -> Command Palette
2. In the search bar, search for Nethereum.
3. You should see Nethereum Add.
4. Select that.
5. Enter Nethereum in the search bar again.
6. Select Nethereum.Contracts and select the latest.
7. Repeat steps 3 through 5.
8. Select Nethereum.Web3


