Feature: Join private table

    Scenario: User joins a private table from an invite link
        Given the user is signed in
        And paste the link in the browser
        When the user continues to the link
        Then the user is transferred to the private table

    Scenario: User tries to join a table that don't exists
        Given the user is not signed in
        When the user joins via link
        Then the user is prompted to sign in
        And gets transferred to the table after signed in
        
