"use strict";

var privateTableConnection = new signalR.HubConnectionBuilder().withUrl("/privatetablehub").build();

privateTableConnection.on("UpdateUserList", ()=> {
    $('#UserListPartial').load('/PrivateTable?handler=UserListPartial&tableId=' + Group);
});

privateTableConnection.start().then(() =>{
    privateTableConnection.invoke("AddUserToUserList", Group);
    $('#UserListPartial').load('/PrivateTable?handler=UserListPartial&tableId=' + Group);
});

window.addEventListener("unload", (event) =>{ 
    privateTableConnection.invoke("RemoveUserFromUserList", Group);
});
