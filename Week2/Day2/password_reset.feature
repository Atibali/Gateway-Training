Feature: Password reset
  Background:
    Given a registered customer with email "jane@example.com"

  Scenario: Request a reset link
    Given the customer is on the "Forgot password" page
    When they submit "jane@example.com"
    Then they see "If an account exists, we sent a reset link"
    And an email is sent to "jane@example.com"

  Scenario: Unknown email does not reveal registration
    When the customer submits "nobody@example.com"
    Then they see the same "If an account exists..." message

  Scenario: Expired link
    Given a reset link that expired 2 hours ago
    When the customer opens the link
    Then they see "This link has expired"
    And they can request a new link

  Scenario: Used link
    Given a reset link that has already been used
    When the customer opens the link
    Then they see "This link is no longer valid"

  Scenario Outline: Password policy
    Given the customer has an unexpired reset link
    When they submit a new password of <length> characters
    Then they see <result>

    Examples:
      | length | result                         |
      | 7      | "Password must be 8 characters" |
      | 8      | "Password updated"             |
      | 64     | "Password updated"             |
      | 65     | "Password is too long"         |