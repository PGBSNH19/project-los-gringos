Feature: User sends a message in the chat

    Background: User is signed in
    Scenario: User sends a message in the message board
        Given the user has written a text
        And it's not an empty string
        When user clicks on Send button
        Then the message is sent
        And all the users at that chatgroup can read the message

    Scenario: User tries to send an empty message
        Given the user hasn't written anything
        When the user clicks on the send button
        Then nothing happends

