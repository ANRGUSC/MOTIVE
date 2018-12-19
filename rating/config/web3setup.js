const Web3 = require('web3');
const keys = require('../config/keys');

const web3 = new Web3(new Web3.providers.HttpProvider(keys.HTTP_SERVER));
web3.eth.net.isListening().then(console.log);

module.exports = web3;
