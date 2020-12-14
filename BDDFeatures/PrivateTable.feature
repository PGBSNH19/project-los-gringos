Feature: Join private table

    Background: User is signed in
    Scenario: User joins a private table
        Given the user has a link to a private table
        And is located at the lobby
        When the user clicks on Private table button
        Then the user pastes the link
        And gets sent to that specific table

    Scenario: User tries to join a table that don't exists
        Given the user has pasted the non existing link
        When the user clicks join
        Then the user is notified that table doesn't exists
        And get the option to create a new private table
        
