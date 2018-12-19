/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
var net = require("net");
var json_svc_provided = require("./services_provided.json")

var port = 44188;
//var ip = "127.0.0.1";

var b_printer = function() {
    console.log("Sending beacon");
};


var server = net.createServer(function(socket) {
    socket.name = socket.remoteAddress + ":" + socket.remotePort;
    
    console.log("Connected: " + socket.name);
    socket.write("Services Provided: " + JSON.stringify(json_svc_provided));
    
    socket.on("data", function(d) {
        console.log("client >> "+ d.toString());
        socket.write(d.toString());
        console.log("client << "+ d.toString());
    });
    
    socket.on("end", function() {
       console.log("Disconnected: " + socket.name); 
       console.log("Listening: " + port);
    });
    
});

console.log("Listening: " + port);
server.listen(port);
