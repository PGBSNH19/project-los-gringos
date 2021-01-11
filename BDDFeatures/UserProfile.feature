Feature: User profile settings

    Scenario: User changes password
        Given the user has signed in
        And navigated to Profile
        When clicking on Password button
        Then fields is displayed
        And the user can now change the current password
