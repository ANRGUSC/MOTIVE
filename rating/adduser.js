const web3 = require('./config/web3setup');
var contract = require('./config/contract');
const keys = require('./config/keys');


const account = web3.eth.accounts.privateKeyToAccount('0xE8B03DE7D420DB4164D02D143548E81CB8D2F898E38E9A0629AD47ED89770AF8');
web3.eth.accounts.wallet.add(account);
web3.eth.defaultAccount = account.address;

//console.log('Sending from Metamask account: ' + account.address);

var numberToAdd = "DL3CAP5426"; // DL of the user to be added - TO BE USED BY ADMIN

contract.methods.addUser(numberToAdd).send({
    from:account.address,
    gas:1000000
  }, (error , hash) => {
    console.log(hash);
  });
