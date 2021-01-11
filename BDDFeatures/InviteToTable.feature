Feature: Invite friends to private table

    Scenario: User invites friend to private table by email
        Given the user is signed in
        And at a private table
        When user clicks on invite by email button
        Then email provider is opened with the link pasted
        And the user can send the link

    Scenario: User invites friend via link from copyboard
        Given the user is signed in
        And at a private table
        When user clicks on Copy invite link button
        Then the link is copied to copyboard
        And and now the user can paste the link where they want
