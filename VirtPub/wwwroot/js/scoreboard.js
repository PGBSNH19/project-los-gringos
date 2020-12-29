"use strict";

var scoreboardConnection = new signalR.HubConnectionBuilder().withUrl("/scoreboard").build();

scoreboardConnection.on("UpdateUserList", function () {
    $('#UserListPartial').load('/PrivateTable?handler=UserListPartial&tableId=' + Group );
});

scoreboardConnection.start().then(function () {
    scoreboardConnection.invoke("AddUserToUserList", Group);
});

window.addEventListener("unload", function(event) { 
    scoreboardConnection.invoke("RemoveUserFromUserList", Group);
});
