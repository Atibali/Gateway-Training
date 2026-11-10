Feature: Customer login
  As a registered customer
  I want to log in with my email and password
  So that I can access my account

  Background:
    Given a registered customer "jane@example.com"

  Scenario: Successful login
    Given the customer is on the login page
    When they enter "jane@example.com" and the correct password
    Then they are taken to the account dashboard
    And they see a greeting "Welcome back, Jane"

  Scenario: Wrong password
    Given the customer is on the login page
    When they enter "jane@example.com" and an incorrect password
    Then they see the error "Email or password is incorrect"
    And they remain on the login page
    And the account is not locked

  Scenario Outline: Rejecting malformed emails
    Given the customer is on the login page
    When they enter <email> and any password
    Then they see the validation message "Enter a valid email address"

    Examples:
      | email              |
      | jane@             |
      | @example.com      |
      | jane.example.com  |
      | jane@example       |
      | (empty)            |