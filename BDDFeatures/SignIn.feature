Feature: SignIn

    Scenario: Successfull sign in
        Given the user has an account.
        And entered a correct username.
        And Correct password.
        When User press the sign in button.
        Then The user is given access to the pub.