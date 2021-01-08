Feature: Update chatboard for everyone at the table


    Scenario: Users at the table reads the new chatmessage
        Given Users is signed in
        And has joined a table
        When a new message been added to the chatboard
        Then the chatboard is updated for everyone
        And the message is displayed
