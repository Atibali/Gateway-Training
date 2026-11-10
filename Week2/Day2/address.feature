Scenario: Save a new address
  Given a customer without a saved address
  When they complete checkout with a new shipping address
  Then the address is saved and shown on the next checkout

Scenario: Edit a saved address
  Given the customer has one saved address
  When they change the postcode and save
  Then the saved address reflects the new postcode on next checkout

Scenario: Delete a saved address that is the default
  Given the customer has two saved addresses, one set as default
  When they delete the default
  Then another address becomes the default

Scenario: Reject duplicate identical addresses
  Given the customer already has a saved address "10 Downing St"
  When they try to save the identical address again
  Then they see "This address is already saved" and are not prompted to pick between two identical entries