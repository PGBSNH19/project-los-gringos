Feature: Show score board
    
    Scenario: Display scoreboard at private table
        Given there is users at the table
        When updating their scores
        Then the scoreboard is updated for everyone
        
