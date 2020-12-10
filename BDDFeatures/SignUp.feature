    Scenario: SignUp
        Given The user have no account.
        When The user press the register button.
        And Enter a walid email.
        And Enter a valid password.
        And confirms the password.
        When Presses save.
        Then The user account will be created.
