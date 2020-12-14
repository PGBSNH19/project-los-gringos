Feature: Sign up

    Scenario: New user creates an account
        Given The user have no account.
        When The user press the register button.
        And Enter a walid email.
        And Enter a valid password.
        And confirms the password.
        When Presses save.
        Then The user account will be created.

    Scenario: User enters invalid credentials
        Given The user have no account.
        And filled in all the fields
        But one or more is not valid
        When The user press the register button.
        Then the user is notified about which field that is incorrect
