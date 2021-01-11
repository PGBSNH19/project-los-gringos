Feature: Users reads new chatmessage


    Scenario: All users in the same chatgroup, is displayed with new message
        Given the users are signed in
        When a new message been added to the chatboard
        Then the chatboard is updated for everyone
        And the message is displayed
