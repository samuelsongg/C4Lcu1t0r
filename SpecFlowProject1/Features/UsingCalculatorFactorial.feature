Feature: UsingCalculatorFactorial
	As a user
	I want to use the calculator to calculate the factorial of a number
	So that I can quickly get the result

@Factorial
Scenario: Doing factorial of a number
	Given I have a calculator
	When I have entered 5 into the calculator and press factorial
	Then the factorial result should be 120

@Factorial
Scenario: Doing factorial of 0
	Given I have a calculator
	When I have entered 0 into the calculator and press factorial
	Then the factorial result should be 1