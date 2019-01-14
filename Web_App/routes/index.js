var express = require('express');
var router = express.Router();
const web3 = require('../config/web3setup');
var contract = require('../config/contract');
const keys = require('../config/keys');

/* GET home page. */

var balanceA;
var balanceB;

function bal(address) {
  let balance = web3.eth.getBalance(address);
  return balance;
}
const account = web3.eth.accounts.privateKeyToAccount('0xE8B03DE7D420DB4164D02D143548E81CB8D2F898E38E9A0629AD47ED89770AF8');
web3.eth.accounts.wallet.add(account);
web3.eth.defaultAccount = account.address;
bal(account.address).then(function(result){
  //console.log(web3.utils.fromWei(result , 'ether'));
  balanceA = web3.utils.fromWei(result , 'ether');
});

const account2 = web3.eth.accounts.privateKeyToAccount('0xC89ADA337DCDD9D9D092D582104064554DDC3A835B0D164B82E304F0DFC5F0FC');
web3.eth.accounts.wallet.add(account2);
bal(account2.address).then(function(result){
  //console.log(web3.utils.fromWei(result , 'ether'));
  balanceB = web3.utils.fromWei(result , 'ether');
});


var driver1 = "DL3CAP5424";
var driver2 = "DL3CAP5426";
var posratingA = [];
var negratingA = [];
var posratingB = [];
var negratingB= [];
var curratingA;
var curratingB;
var time_contact;
var duration;

router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

router.post('/beaconingA' , function(req , res , next) {
  console.log(req.body.time_contact);
  console.log(req.body.duration);
  time_contact = req.body.time_contact;
  duration = req.body.duration;
  res.render('beaconing' , {duration : req.body.time_contact/2});
});

router.get('/discoverA' , function(req , res) {
  res.render('discoverA' , {duration : time_contact / 2 , vehicle : driver1})
});

router.get('/discoverB' , function(req , res) {
  res.render('discoverB' , {duration : time_contact / 2 , vehicle : driver2})
});

router.get('/linkpredictA' , function(req , res) {
  res.render('linkpredictA' , {link_duration : duration});
});

router.get('/linkpredictB' , function(req , res) {
  res.render('linkpredictB' , {link_duration : duration});
});

router.get('/dashboardA' , function(req , res) {
  console.log(balanceA);
  console.log(balanceB);
  posratingA.length = 0;
  negratingA.length = 0;
  contract.methods.getIntegerRating(driver1).call().then(function(result){
  //console.log(result[0]);
  curratingA = result[0];
  console.log(curratingA);
  for(var i = 0; i<curratingA; i++){
    posratingA.push(i);
  }
  for(var i =0; i<5-curratingA; i++) {
    negratingA.push(i);
  }
  res.render('dashboardA' , {pos : posratingA , neg:negratingA , balance : balanceA});
  console.log(posratingA);
  console.log(negratingA);
});
});

router.get('/dashboardB' , function(req , res) {
  posratingB.length = 0;
  negratingB.length = 0;
  contract.methods.getIntegerRating(driver2).call().then(function(result){
  console.log(result[0]);
  curratingB = result[0];
  for(var i = 0; i<curratingB; i++){
    posratingB.push(i);
  }
  for(var i =0; i<5-curratingB; i++) {
    negratingB.push(i);
  }
  res.render('dashboardB' , {pos : posratingB , neg:negratingB , balance : balanceB});
  console.log(posratingB);
  console.log(negratingB);
});
});

router.get('/sendingA' , function(req , res) {
  res.render('sendingA');
  web3.eth.sendTransaction({
    from: account.address ,
    to: account2.address,
    value: '500000000000000000',
    gas: 2000000
  }).then(function(res){
    console.log(res);
  });
});

router.get('/download' , function(req,res) {
  var file = __dirname + '/data.json';
  res.download(file, function(err){
  if(err) {
    if(res.headersSent) {
    } else {
      return res.sendStatus(404);
    }
  }
});
});

router.get('/receiveB' , function(req , res) {
  res.render('receiveB');
});

router.get('/sendingB' , function(req , res) {
  res.render('sendingB');
  web3.eth.sendTransaction({
    from: account2.address ,
    to: account.address,
    value: '500000000000000000',
    gas: 2000000
  }).then(function(res){
    console.log(res);
  });
});

router.get('/receiveA' , function(req , res) {
  res.render('receiveA');
});

router.get('/rateA' , function(req , res) {
  res.render('rateA');
});

router.get('/rateB' , function(req , res) {
  res.render('rateB');
});

router.post('/thankyouA' , function(req , res) {
  console.log(req.body.star);
	//console.log(rating_from + " " + "rated" + rating_to + " " + "with" + rating);
  res.render('thankyouA');
  contract.methods.addRating(driver1 , driver2 , req.body.star).send({
    from:account.address,
    gas:1000000
  }, (error , hash) => {
    console.log(hash);
    });
});

router.post('/thankyouB' , function(req , res) {
  console.log(req.body.star);
  res.render('thankyouB');
  contract.methods.addRating(driver2 , driver1 , req.body.star).send({
    from:account.address,
    gas:1000000
  }, (error , hash) => {
    console.log(hash);
});
});

module.exports = router;
