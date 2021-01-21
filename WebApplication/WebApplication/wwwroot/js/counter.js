"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/counterHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveCounter", function (counter) {
    var counterElement = document.getElementById("counter");
    counterElement.innerText = counter;
});
