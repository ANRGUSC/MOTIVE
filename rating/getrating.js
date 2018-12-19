const web3 = require('./config/web3setup');
var contract = require('./config/contract');
const keys = require('./config/keys');


const account = web3.eth.accounts.privateKeyToAccount('0xE8B03DE7D420DB4164D02D143548E81CB8D2F898E38E9A0629AD47ED89770AF8');
web3.eth.accounts.wallet.add(account);
web3.eth.defaultAccount = account.address;

//console.log('Sending from Metamask account: ' + account.address);

var rating_address = "DL3CAP5426" // DL of the rater whose rating is to be fetched


contract.methods.getRatingParameters(rating_address).call().then(function(result){
  var total_points = result[0];
  var times_voted = result[1];
  console.log(total_points/times_voted);
});
