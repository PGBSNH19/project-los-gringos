# Producera och leverera mjukvara


## Los Gringos

### Group 3
Members: Fredrik, William, Eric, Sebastian, Murat, Isach, Emelie, Meena, Saritha, Alexander, Thi

### Background
Los Gringos is meant to be a "local" virtual pub for you and your friends.

### Description (high level)
You need to register an account to be able to "enter" the pub. Once registered you enter the lobby!

In the lobby you will see cards with game names and a button to klick in to the game.
When you click on a game (button) you will see another page where a "table" is visible that you can join (button).

When you join a table you will see a list of members and who the admin is (crown next to name).
The admin is able to register the scores for the table.

In all the different lobbies you will be able to chat with other people that are logged in (in that particular lobby)
You will also be able to create private tables that you can play with just your friends, or join public tables if there is room.

### Tech Stack
- Hosting: Heroku
- DB: PostgreSQL
- Backend: .net 5.0
- Frontend: .net 5.0 web app
- Chat: SignalR + JQuery/JS

### To get started as a dev

1. Clone this repository
2. Add appsettings.Development.json to both VirtPub and VertPub.Backend with following:
````
[Frontend/ VirtPub]
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "User ID= ID_HERE;Password= PASSWORD_HERE;Server= SERVERNAME_HERE;Database=DBNAME_HERE;"
    },
  "DevBackendURI": "http://localhost:4000/"
}
````
</br>

</br>

````
[Backend/VertPub.Backend]
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "User ID= ID_HERE;Password= PASSWORD_HERE;Server= SERVERNAME_HERE;Database=DBNAME_HERE;"
    }
}
````
3. Run this command for both projects `dotnet ef database update -contex THEN_CONTEXTNAME`
### DB Setup (local env)
- Download Postgresql <https://www.postgresql.org/>
- Dowload PG Admin <https://www.pgadmin.org/>
- Follow instructions <https://www.pgadmin.org/docs/pgadmin4/latest/index.html>

### Usage
Go to <http://losvirtpub.herokuapp.com>
Register an Account
Tell your friends! *hihi*

### API Documentation
Swagger
- Clone the repo
- Run the backend = Vertpub.Backend in VS Code
- Run the command dotnet run in the Vertpub.Backend folder
- Go to: <https://localhost:4001/swagger>



### Other Resources
Link to project: <https://pgbsnh19.github.io/course-producera-leverera/assignments/project>
