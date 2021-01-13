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

privateTableConnection.on("SendScoreSuggestionToAdmin", (score, userName)=> {

    var alreadyFoundUser = false;

    for (let i = 0; i < scoreSuggestions.length; i++) {
        const suggestion = scoreSuggestions[i];
        if (suggestion.UserName == userName) {
            suggestion.Score = score;
            alreadyFoundUser = true;
            break;
        }
    }
    if (!alreadyFoundUser) {
        var suggestions = {Score:score, UserName:userName};
        scoreSuggestions[scoreSuggestions.length] = suggestions;
    }
    
    UpdateScoreSuggestions();
});

function UpdateScoreSuggestions() {
    var scoreSuggestionDiv = document.getElementById("scoreSuggestionsDiv");
    scoreSuggestionDiv.innerHTML = "";

    for (let i = 0; i < scoreSuggestions.length; i++) {
        const suggestion = scoreSuggestions[i];
        var encodedMsg = "<li style='color: white'><b>" + suggestion.UserName + "</b>" + " want his score to be: <b>" + suggestion.Score + "</b></li>" +
        "<button class='btn btn-warning' onclick='UpdateScoreForPlayer(\"" + suggestion.UserName + "\", \"" + suggestion.Score + "\")'>Accept Score</button>" +
        "<button class='btn btn-warning margin-left' onclick='RemoveSuggestionFromPlayer(\"" + suggestion.UserName + "\")'>Reject</button>";
        var p = document.createElement("span");
        p.innerHTML = encodedMsg;
        scoreSuggestionDiv.appendChild(p);
    }
};

function UpdateScoreForPlayer(userName, score){
    privateTableConnection.invoke("UpdateScoreForPlayer", userName, score, Group).catch(function (err) {
        return console.error(err.toString());
    });

    RemoveSuggestionFromPlayer(userName)
};
function RemoveSuggestionFromPlayer(userName){
    var index = scoreSuggestions.findIndex(x => x.UserName == userName);
    if (index >= 0) {
        scoreSuggestions.splice(index, 1);
        UpdateScoreSuggestions();
    }
};


document.getElementById("submitScoreButton").addEventListener("click", function (event) {
    event.preventDefault();
    SubmitScore()
});

function SubmitScore(){
    var score = document.getElementById("scoreInput").value;

    if (score != "") {
        document.getElementById("scoreInput").value = "";
        privateTableConnection.invoke("SendScoreSuggestion", score, Group).catch(function (err) {
            return console.error(err.toString());
        });
    }
};