Feature: UsingCalculatorAvailability
  In order to calculate MTBF and Availability
  As someone who struggles with math
  I want to be able to use my calculator to do this

@Availability
Scenario: Calculating MTBF
	Given I have a calculator
	When I have entered 1000 and 100 into the calculator and press MTBF
	Then the availability result should be "1100"

@Availability
Scenario: Calculating Availability
	Given I have a calculator
	When I have entered 1000 and 100 into the calculator and press Availability
	Then the availability result should be "0.909"

@Availability
Scenario: Calculating MTBF with larger values
	Given I have a calculator
	When I have entered 5000 and 500 into the calculator and press MTBF
	Then the availability result should be "5500"

@Availability
Scenario: Calculating Availability with different values
	Given I have a calculator
	When I have entered 2000 and 200 into the calculator and press Availability
	Then the availability result should be "0.909"

@Availability
Scenario: Calculating MTBF with negative values
	Given I have a calculator
	When I have entered -1000 and -100 into the calculator and press MTBF
	Then a MTBF exception should be thrown with the message "Parameters cannot be negative"

@Availability
Scenario: Calculating Availability with negative values
	Given I have a calculator
	When I have entered -1000 and -100 into the calculator and press Availability
	Then a Availability exception should be thrown with the message "Parameters cannot be negative"
