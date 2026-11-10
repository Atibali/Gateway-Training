Scenario: Valid percentage code applies discount
  Given a cart with a subtotal of $100.00
  And a valid 10% discount code "SAVE10"
  When the customer applies "SAVE10"
  Then the order total is $90.00

Scenario: Expired code is rejected
  Given a discount code "OLD5" that expired yesterday
  When the customer applies "OLD5"
  Then the customer sees "This code has expired"
  And the order total stays $100.00