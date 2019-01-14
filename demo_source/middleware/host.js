/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
 const web3 = require('./config/web3setup');
 var contract = require('./config/contract');
 const keys = require('./config/keys');
 var net = require("net");
 //var stdin = process.openStdin();

 // Middleware

 var port = 44188;

 var server = net.createServer(function(socket) {
 	socket.name = socket.remoteAddress + ":" + socket.remotePort;

 	console.log("Connected: " + socket.name);

 	socket.write(parseFloat(balanceA).toFixed(4) + "," + parseFloat(balanceB).toFixed(4) + "," + parseFloat(curratingA).toFixed(0) + "," + parseFloat(curratingB).toFixed(0));
 	console.log("MOTIVE << " + parseFloat(balanceA).toFixed(4) + "," + parseFloat(balanceB).toFixed(4) + "," + parseFloat(curratingA).toFixed(0) + "," + parseFloat(curratingB).toFixed(0));

 	socket.on("data", function(d) {
 		console.log("MOTIVE >> "+ d.toString());

 		if (d.toString().includes("scheduling_service") ||
 			d.toString().includes("service_advertisement") ||
 			d.toString().includes("link_prediction") ||
 			d.toString().includes("_beaconing")) {
 			setTimeout(function() {
 				socket.write("OK");
 				console.log("MOTIVE << OK");
 			}, 2000); 
 	}

 	if (d.toString().includes("blockchain_payment")) {
 		make_payment(account2, account);
 		socket.write("OK");
 		console.log("MOTIVE << OK");
 	}

 	if (d.toString().includes("_rating")) {
 		add_rating();
 		socket.write("OK");
 		console.log("MOTIVE << OK");
 	}
 });

 	socket.on("end", function() {
 		console.log("Disconnected: " + socket.name); 
 		console.log("Listening: " + port);
 	});

 	socket.on("error", function() {
 		console.log("Disconnected: " + socket.name); 
 		process.exit(0);
 		//console.log("Listening: " + port);
 	});

 	/*
 	stdin.addListener("data", function(d) {
 		d = d.slice(0, d.length - 1);
 		socket.write(d);
 		console.log("MOTIVE << " + d);
 	});
 	*/
 });

 console.log("Listening: " + port);
 server.listen(port);

// Blockchain

var driver1 = "DL3CAP5424";
var driver2 = "DL3CAP5426";

var curratingA = 0;
var curratingB = 0;
var balanceA = 0;
var balanceB = 0;

function bal(address) {
	let balance = web3.eth.getBalance(address);
	return balance;
}

const account = web3.eth.accounts.privateKeyToAccount('(REDACTED)');
web3.eth.accounts.wallet.add(account);
web3.eth.defaultAccount = account.address;
bal(account.address).then(function(result){
	balanceA = web3.utils.fromWei(result , 'ether');
	console.log(driver1 + " balance: " + balanceA);
});

const account2 = web3.eth.accounts.privateKeyToAccount('(REDACTED)');
web3.eth.accounts.wallet.add(account2);
bal(account2.address).then(function(result){
	balanceB = web3.utils.fromWei(result , 'ether');
	console.log(driver2 + " balance: " + balanceB);
});

contract.methods.getIntegerRating(driver1).call().then(function(result){
	curratingA = result[0];
	console.log(driver1 + " rating: " + curratingA);
});

contract.methods.getIntegerRating(driver2).call().then(function(result){
	curratingB = result[0];
	console.log(driver2 + " rating: " + curratingB);
});

var make_payment = function(from, to) {
	web3.eth.sendTransaction({
		from: from.address,
		to: to.address,
		value: '10000000000000000',
		gas: 2000000
	}).then(function(res){
		console.log(res);
	});
}

var add_rating = function() {
	contract.methods.addRating(driver1 , driver2 , 5).send({
		from:account.address,
		gas:1000000
	}, (error , hash) => {
		if (hash) console.log(hash);
	});
	console.log(driver1 + " new rating added: 5");

	contract.methods.addRating(driver2 , driver1 , 5).send({
		from:account.address,
		gas:1000000
	}, (error , hash) => {
		if (hash) console.log(hash);
	});
	console.log(driver2 + " new rating added: 5");
}

// Launcher

var exec = require('child_process').execFile;

var show_display = function() {
	console.log("Launching: WPF");
	exec('app.exe', function(err, data) {  
		console.log("app.exe not found in .\\");
		console.log(data.toString());
		process.exit(0);
	});  
}

show_display();