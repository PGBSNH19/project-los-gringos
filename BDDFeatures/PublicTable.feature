Feature: Join public table

    Scenario: A user selects which game to play
        Given The user is signed in
        And located at the lobby
        When choosing which game to play
        Then the user is transferred to a page displaying public tables with that game
        When choosing which game to play
        Then the user is transferred to a page displaying public tables with that game

    Scenario: A user selects public table to join
        Given the user has choosen game to play
        When choosing which table to join
        Then the player is transferred to that specific table
