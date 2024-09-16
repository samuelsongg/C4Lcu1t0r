Feature: UsingCalculatorMusaModel
  In order to predict failure intensity and expected failures
  As a system quality engineer
  I want to calculate failure intensity and the number of expected failures using the Musa Logarithmic model

@MusaModel
Scenario: Calculating Musa Log reliability
    Given I have a calculator
    When I have entered 5, 6, 0.001, and 0.01 into the calculator and press MusaLogReliability
    Then the Musa Log reliability result should be "Failure Intensity: 4.970089820269676, Expected Failures: 0.043727377411248505"

Scenario: Calculating Musa Log reliability for another case
Given I have a calculator
    When I have entered 10, 11, 0.002, and 0.02 into the calculator and press MusaLogReliability
    Then the Musa Log reliability result should be "Failure Intensity: 9.7824023505121, Expected Failures: 0.10574098270960736"
