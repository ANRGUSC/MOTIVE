const web3 = require('./config/web3setup');
var contract = require('./config/contract');
const keys = require('./config/keys');


const account = web3.eth.accounts.privateKeyToAccount('0xE8B03DE7D420DB4164D02D143548E81CB8D2F898E38E9A0629AD47ED89770AF8');
web3.eth.accounts.wallet.add(account);
web3.eth.defaultAccount = account.address;

//console.log('Sending from Metamask account: ' + account.address);

var rating_from = "DL3CAP5424" // DL of the rater
var rating_to = "DL3CAP5426"; // DL of the person to be rated
var rating = 4 // rating from 0-5

contract.methods.addRating(rating_from , rating_to , rating).send({
    from:account.address,
    gas:1000000
  }, (error , hash) => {
    console.log(hash);
  });
