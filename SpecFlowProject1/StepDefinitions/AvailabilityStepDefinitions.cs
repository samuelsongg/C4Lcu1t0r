using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class AvailabilityStepDefinitions
    {
        private readonly Calculator _calculator;
        private double _result;

        public AvailabilityStepDefinitions(Calculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double mttf, double mttr)
        {
            _result = _calculator.CalculateMTBF(mttf, mttr);
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double mttf, double mttr)
        {
            _result = _calculator.CalculateAvailability(mttf, mttr);
        }

        [Then(@"the availability result should be ""(.*)""")]
        public void ThenTheAvailabilityResultShouldBe(string expectedResult)
        {
            if (expectedResult.Contains("."))
            {
                // Compare as a floating-point number with formatting for decimals
                Assert.That(_result.ToString("F3"), Is.EqualTo(expectedResult));
            }
            else
            {
                // Compare as an integer without decimals
                Assert.That(((int)_result).ToString(), Is.EqualTo(expectedResult));
            }
        }
    }
}
