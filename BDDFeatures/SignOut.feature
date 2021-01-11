Feature: Feature name

    Scenario: Sign out
        Given The user is logged in.
        When User presses the log out button.
        Then  The user will sign out.
        And message shows that user successfully been signed out
