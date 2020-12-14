Feature: Show score board

    Background: User has a valid account and authorized access

    Scenario: At a table show the members and their scores
        Given that the players written their scores in the chat
        When Administrator adds every score to its player
        Then all the other participants should see the updated score
        
