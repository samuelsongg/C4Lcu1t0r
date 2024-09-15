using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class UsingCalculatorDivisionStepDefinitions
    {
        private Calculator _calculator;
        private double _result;

        [When(@"I have entered (.*) and (.*) into the calculator")]
        public void WhenIHaveEnteredAndIntoTheCalculator(int p0, int p1)
        {
            throw new PendingStepException();
        }

        [Then(@"the division result should be a decimal (.*)")]
        public void ThenTheDivisionResultShouldBe(Decimal p0)
        {
            throw new PendingStepException();
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(int p0, int p1)
        {
            throw new PendingStepException();
        }

        [Then(@"the division result should be an integer (.*)")]
        public void ThenTheDivisionResultShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the division result equals positive_infinity")]
        public void ThenTheDivisionResultEqualsPositive_Infinity()
        {
            throw new PendingStepException();
        }
    }
}
