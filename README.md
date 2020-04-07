# mi4-exercise14
Playing with Smart Contracts using Nethereum

Exercises: Playing with Smart Contracts using Nethereum
In this exercise, we will use Nethereum .NET integration library for Ethereum, simplifying the access and smart contract interaction with Ethereum nodes. The exercise will show how to interact with an already deployed contract on the Ethereum Ropsten Testnet.
1.	Setup the Development Environment
Create a .NET Core Console Application and install the following NuGetPackages:
 
Create a class called ContractService, which will be the connection to the Ropsten Testnet. Create 3 readonly private properties for the Web3, the Contract and for an Account, which will be the wallet.
 
Then, create a constructor, which takes 4 parameters: provider of the node, contract address, contract abi and a private key for an account/wallet.
 
We will need HTTPProvider in order to create our connection to the Ropsten Testnet using Infura.io.
Now let’s get the necessary Infura.io provider. Go to https://infura.io/ and click [Get started for free]:
 
Fill out the form and click [Submit]. Then copy the Ropsten URL:
 
 
In order to get a contract instance of an already deployed contract, we will need its address and application binary interface. For exercise’s purpose, deploy a simple contract storing an array of facts through Remix IDE using MetaMask Ropsten a provider:
 
If you do not have ETHt, use the MetaMask faucet: https://faucet.metamask.io/ 
Then, copy its address and ABI, and create an instance of the contract.  
Because the contract owner can only add facts to this contract, copy his private key.
 
 
Copy the private key and the address. The address will be needed to easily calculate the nonce:
 
 
2.	Writing to the Smart Contract
In the ContractService class, create a method, which takes as an argument a fact and adds it to the contract. We will send an asynchronous transaction - method.SendTransactionAsync(from, gas, value, functionInput) and will not wait to be mined, just get the transaction hash.
 
 
 
In Ropsten Etherscan:
 


Try adding a fact using another private key as an account.
3.	Reading from the Smart Contract
When reading from a Smart Contract, no wallets or private keys are needed. 
In the ContractService class create a method which gets a fact by a given index and returns a string with the fact. Get the method of the contract and then make an asynchronous call with the index as parameter, which will return Task<string> and get the result:
 
 
 
Then create a method, which gets how many facts are stored in the contract:
 
 
 
What to Submit?
Create a zip file (e.g. username-playing-smart-contracts-nethereum-web3.zip) holding the two .cs files with the methods, a snapshot of the Ropsten Etherscan contract address and its transactions.
Submit your zip file as homework at the course Website.

