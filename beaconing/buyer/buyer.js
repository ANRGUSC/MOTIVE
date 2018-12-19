/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
var net = require("net");
var stdin = process.openStdin();
var json_svc_needed = require("./services_needed.json");

var port = 44188;
var ip = "10.1.1.2";

var client = new net.Socket();
var existing_connection = false;

function startIntervalConnection() {
    if (existing_connection !== false) return;
    existing_connection = setInterval(startConnection, 5000);
};

function clearIntervalConnection() {
    if (existing_connection === false) return;
    clearInterval(existing_connection);
    existing_connection = false;
};

function startConnection() {
    client.connect({
      port: port,
      host: ip
    })
};

client.on("error", function(e) {
    console.log("Connection unsuccessful: " + e.code);
    console.log("Retrying in 5s...");
    startIntervalConnection();
});

client.on("connect", function() {
    clearIntervalConnection(existing_connection);
    client.write("Services Needed: " + JSON.stringify(json_svc_needed));
});

client.on("data", function(d) {
    console.log("server >> " + d.toString());
});

client.on("end", function() {
    process.exit(0);
});

stdin.addListener("data", function(d) {
    d = d.slice(0, d.length - 1);
    if (d.toString() !== "end")
    {
        client.write(d);
        console.log("server << " + d);
    }
    else
        client.end();
});

startConnection();