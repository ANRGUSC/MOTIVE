/*
Author: Robert Lie (mobilefish.com)

The mam_sensor.js file publishes DHT11 sensor data (temperature and humidity) on the tangle using MAM.
This file only works on the Raspberry Pi.
The published data can be viewed using the mam_receive.js file or
https://www.mobilefish.com/services/cryptocurrency/mam.html (Select option: Data receiver)

Usage:
1)  Connect DHT11 sensor to Raspberry Pi.
2)  Do not forget to type: npm install
3)  You can change the default settings: MODE, SIDEKEY, SECURITYLEVEL or TIMEINTERVAL
    If you do, make the same changes in mam_receive.js file.
4)  Start the app: node mam_sensor.js

More information:
https://www.mobilefish.com/developer/iota/iota_quickguide_raspi_mam.html
*/

const Mam = require('./lib/mam.client.js');
const IOTA = require('iota.lib.js');
const iota = new IOTA({ provider: 'https://nodes.testnet.iota.org:443' });

const MODE = 'restricted'; // public, private or restricted
const SIDEKEY = 'mysecret'; // Enter only ASCII characters. Used only in restricted mode

let root;
let key;

// Check the arguments
const args = process.argv;
if(args.length !=3) {
    console.log('Missing root as argument: node mam_receive.js <root>');
    process.exit();
} else if(!iota.valid.isAddress(args[2])){
    console.log('You have entered an invalid root: '+ args[2]);
    process.exit();
} else {
    root = args[2];
}

// Initialise MAM State
let mamState = Mam.init(iota);

// Set channel mode
if (MODE == 'restricted') {
    key = iota.utils.toTrytes(SIDEKEY);
    mamState = Mam.changeMode(mamState, MODE, key);
} else {
    mamState = Mam.changeMode(mamState, MODE);
}

// Receive data from the tangle
const executeDataRetrieval = async function(rootVal, keyVal) {
    let resp = await Mam.fetch(rootVal, MODE, keyVal, function(data) {
        let json = JSON.parse(iota.utils.fromTrytes(data));
        console.log(`dateTime: ${json.dateTime}, data: ${json.data}`);
    });

    executeDataRetrieval(resp.nextRoot, keyVal);
}

executeDataRetrieval(root, key);
