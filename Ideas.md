# Ideas

## Virtual Pup, with games

### Functionallity

- Create Account
- Sign In
- Sign Out
- Invite to table
- One table with one game
- Table with specific amount of seats
- Search for members
- Scoreboard? : Game master?
- Chatboard?

### Database Architecture

- Identity - Database
- Application- Database

#### Application Database- tables

- Table
- Game
- Scoreboard
- Chatboard?

#### Identity Database- tables

- User (Primary)

------------------------------------------------

## Landing page (after sign in)

- Chat
    This chat is open for everyone that is signed in and has not picked a table yet.
- Choose table
- Join random table
- Join private table
    User will then be asked to paste a table ID/link or create a new one.

## Table

### Private table

- Table with a menu (like a food menu, but with links to games)
    The table owner is choosing which link/game to use
- Chat for this table
    This chat is only open for peoples at the table
- Scoreboard
    The scoreboard is handled by the table owner, and it's lifecycle is
    depending on the session of the current table.

### Public table

- Chat for this table
    This chat is only open for peoples at the table
- Each public table gets generated a random link to a game.
- If the table has zero visitors, the session is closed to save resources. And
to not burden the servers.

## User profile

- Name
- Picture
