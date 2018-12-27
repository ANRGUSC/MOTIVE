var express = require('express');
var router = express.Router();
const web3 = require('../config/web3setup');
var contract = require('../config/contract');
const keys = require('../config/keys');

/* GET home page. */

const account = web3.eth.accounts.privateKeyToAccount('0xE8B03DE7D420DB4164D02D143548E81CB8D2F898E38E9A0629AD47ED89770AF8');
web3.eth.accounts.wallet.add(account);
web3.eth.defaultAccount = account.address;
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
  contract.methods.getIntegerRating(driver1).call().then(function(result){
  //console.log(result[0]);
  curratingA = result[0];
  for(var i = 0; i<curratingA; i++){
    posratingA.push(i);
  }
  for(var i =0; i<5-curratingA; i++) {
    negratingA.push(i);
  }
  res.render('dashboardA' , {pos : posratingA , neg:negratingA});
  console.log(posratingA);
  console.log(negratingA);
});
});

router.get('/dashboardB' , function(req , res) {
  contract.methods.getIntegerRating(driver2).call().then(function(result){
  console.log(result[0]);
  curratingB = result[0];
  for(var i = 0; i<curratingB; i++){
    posratingB.push(i);
  }
  for(var i =0; i<5-curratingB; i++) {
    negratingB.push(i);
  }
  res.render('dashboardB' , {pos : posratingB , neg:negratingB});
  console.log(posratingB);
  console.log(negratingB);
});
});

router.get('/sendingA' , function(req , res) {
  res.render('sendingA');
});

router.get('/receiveB' , function(req , res) {
  res.render('receiveB');
});

router.get('/sendingB' , function(req , res) {
  res.render('sendingB');
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
