using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class UsingCalculatorDivisionStepDefinitions
    {
        private readonly CommonSteps _commonSteps;
        private double _result;

        public UsingCalculatorDivisionStepDefinitions(CommonSteps commonSteps)
        {
            _commonSteps = commonSteps;
        }

        [When(@"I have entered (.*) and (.*) into the calculator")]
        public void WhenIHaveEnteredAndIntoTheCalculator(int p0, int p1)
        {
            // Retrieve the calculator from CommonSteps
            var calculator = _commonSteps.GetCalculator();
            _result = calculator.Divide(p0, p1);
        }

        [Then(@"the division result should be (.*)")]
        public void ThenTheDivisionResultShouldBe(double expectedResult)
        {
            if (Math.Abs(_result - expectedResult) > 0.00001)
            {
                throw new Exception($"Expected result to be {expectedResult} but got {_result}");
            }
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(int p0, int p1)
        {
            var calculator = _commonSteps.GetCalculator();
            _result = calculator.Divide(p0, p1);
        }

        [Then(@"the division result should be an integer (.*)")]
        public void ThenTheDivisionResultShouldBe(int expectedResult)
        {
            if ((int)_result != expectedResult)
            {
                throw new Exception($"Expected result to be {expectedResult} but got {_result}");
            }
        }

        [Then(@"the division result equals positive_infinity")]
        public void ThenTheDivisionResultEqualsPositive_Infinity()
        {
            if (!double.IsPositiveInfinity(_result))
            {
                throw new Exception($"Expected result to be positive infinity but got {_result}");
            }
        }
    }
}
