Feature: Login Tests

Verify Login functionlity of the page.

@smoke
Scenario: Positive LogIn test
	Given User opens the login page at "https://practicetestautomation.com/practice-test-login/"
	When User enters username "student" and password "Password123"
	And User click on the login button
	Then User should be logged in successfully and see the message "Logged In Successfully"

@smoke1
Scenario Outline: Invalid Login test
	Given User opens the login page at "https://practicetestautomation.com/practice-test-login/"
	When User enters username '<Username>' and password '<Password>'
	And User click on the login button
	Then User should be logged in successfully and see the message '<Message>'
	Examples: 
	| Username | Password    | Message                |
	| student  | Password123 | Logged In Successfully |
	| students  | Password123   | Your username is invalid! |
	| student | Password123s | Your password is invalid!   |
