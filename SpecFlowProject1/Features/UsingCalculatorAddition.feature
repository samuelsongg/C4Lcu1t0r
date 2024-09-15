Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject1/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@Addition
Scenario: Add two numbers
	Given I have a calculator
	When I have entered 50 and 70 into the calculator and press add
	Then the result should be 120

@Addition
Scenario Outline: Add zeros for special cases
	Given I have a calculator
	When I have entered <value1> and <value2> into the calculator and press add
	Then the result should be <value3>
	Examples:
	| value1 | value2 | value3 |
	| 1      | 11     | 12     |
	| 10     | 11     | 21     |
	| 11     | 11     | 22     |