Scenario Outline: Password length
  Given the customer is on the sign-up page
  When they enter a password of <length> characters
  Then they see <result>

  Examples:
    | length | result                          |
    | 7      | "Password must be 8 characters" |
    | 8      | "Password accepted"             |
    | 9      | "Password accepted"             |
    | 64     | "Password accepted"             |
    | 65     | "Password too long"             |