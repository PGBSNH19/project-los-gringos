Feature: Display User profile

    Background: User has signed in successfully

    Scenario: Display chosen profile picture
        Given User has previously changed from the default profile
        When the user navigates to their profile
        Then the profile picture should be displayed
        And the users name

    Scenario: Display default profile picture
        Given the user hasn't uploaded any profile picture
        When user navigates to their profile
        Then a default picture is shown
        And the users name
