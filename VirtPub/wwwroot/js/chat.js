"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = "<b>" + user + "</b>" + ": " + msg + "</br>";
    var p = document.createElement("span");
    p.innerHTML = encodedMsg;
    document.getElementById("ChatWindow").appendChild(p);
    updateScroll();
});

connection.start().then(function () {
    connection.invoke("AddUserToGroup", Group);
    connection.invoke("UserJoinedTable", Group);
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    SendChatMessage()
});

document.getElementById("MinimizeChat").addEventListener("click", function (event) {
    event.preventDefault();
    if (document.getElementById("ChatWindow").hidden) {
        document.getElementById("ChatWindow").hidden = false;
        document.getElementById("ModalFooter").hidden = false;
        document.getElementById("MinimizeChat").innerHTML = "Minimize chat window";
        document.getElementById("ModalWindow").style = "max-height:45%";
    }
    else {
        document.getElementById("ChatWindow").hidden = true;
        document.getElementById("ModalFooter").hidden = true;
        document.getElementById("MinimizeChat").innerHTML = "Maximize chat window";
        document.getElementById("ModalWindow").style = "max-height:45px";
    }
    
});

document.getElementById("messageInput").addEventListener("keyup", function (event) {
    event.preventDefault();
    if (event.key == "Enter") {
        SendChatMessage()
    }
});

function SendChatMessage(){
    var message = document.getElementById("messageInput").value;

    if (message == "") {
        document.getElementById("messageInput").placeholder = "Anything"
    }
    else {
        document.getElementById("messageInput").placeholder = "Write something"
        document.getElementById("messageInput").value = "";
        connection.invoke("SendMessageToGroup", message, Group).catch(function (err) {
            return console.error(err.toString());
        });
    }
};

function updateScroll(){
    var element = document.getElementById("ChatWindow");
    element.scrollTop = element.scrollHeight;
};

connection.on("UserJoinedTable", function () {
    connection.invoke("UpdateSelfToTableMembers", Group);
});

connection.on("UpdateSelfToTableMembers", function (user) {
    if (UserNeedsToBeAdded(user))
    {
        var p = document.createElement("span");
        p.innerHTML = "<b>" + user + "</b>" + "<br>";
        document.getElementById("CurrentMembers").appendChild(p);
    }
});

function UserNeedsToBeAdded(user){
    var users =  document.getElementById("CurrentMembers").innerHTML;
    if (users.includes(user)) {
        return false;
    }
    return true;
};

window.onbeforeunload = function (e) {
    var message = "Your confirmation message goes here.",
    e = e || window.event;
    // For IE and Firefox
    if (e) {
      e.returnValue = message;
    }
  
    // For Safari
    return message;
  };