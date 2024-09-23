Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's failures/intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

@Reliability
Scenario: Calculating Current Failure Intensity (λ(τ))
    Given I have a calculator
    When I have entered 7, 8, and 9 into the calculator and press FailureIntensity
    Then the failure intensity result should be "0.778"

@Reliability
Scenario: Calculating Expected Failures (μ(τ))
    Given I have a calculator
    When I have entered 10, 11, and 12 into the calculator and press ExpectedFailures
    Then the expected failures result should be "11.0"

@Reliability
Scenario: Calculating Failure Intensity with negative parameters
    Given I have a calculator
    When I have entered -7, 8, and 9 into the calculator and press FailureIntensity
    Then a Failure Intensity exception should be thrown with the message "Parameters cannot be negative"

@Reliability
Scenario: Calculating Expected Failures with negative parameters
    Given I have a calculator
    When I have entered 10, -11, and 12 into the calculator and press ExpectedFailures
    Then a Expected Failure exception should be thrown with the message "Parameters cannot be negative"
