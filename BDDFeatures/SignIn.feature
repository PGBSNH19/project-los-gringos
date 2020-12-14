Feature: SignIn

    Scenario: Successfull sign in
        Given the user has an account.
        And entered a correct username.
        And Correct password.
        When User press the sign in button.
        Then The user is given access to the pub.

    Scenario: Failed sign in due to wrong password
        Given the user has an account
        And entered correct username
        And wrong password
        When the user clicks on the sign in button
        Then the user is notified that username or password is wrong
        And all the fields is cleared


    Scenario: Failed sign in due to wrong username
        Given the user has an account
        And entered wrong username
        And correct password
        When the user clicks on the sign in button
        Then the user is notified that username or password is wrong
        And all the fields is cleared
