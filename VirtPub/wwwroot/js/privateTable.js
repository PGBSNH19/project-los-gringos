"use strict";

var privateTableConnection = new signalR.HubConnectionBuilder().withUrl("/privatetablehub").build();

privateTableConnection.on("UpdateUserList", function () {
    $('#UserListPartial').load('/PrivateTable?handler=UserListPartial&tableId=' + Group);
});

privateTableConnection.start().then(function () {
    privateTableConnection.invoke("AddUserToUserList", Group);
    $('#UserListPartial').load('/PrivateTable?handler=UserListPartial&tableId=' + Group);
});

window.addEventListener("unload", function(event) { 
    privateTableConnection.invoke("RemoveUserFromUserList", Group);
});
