Feature: Generate random link to a table

    Scenario: User wants to join a random table
        Given the user is signed in
        And at lobby
        And wants to play with random people
        When the user clicks on the random table button
        Then the user is transferred to a random table
