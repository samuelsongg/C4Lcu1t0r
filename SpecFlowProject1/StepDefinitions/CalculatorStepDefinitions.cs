using NUnit.Framework;
using SpecFlowProject1.StepDefinitions;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private readonly CommonSteps _commonSteps;
        private double _result;

        public UsingCalculatorStepDefinitions(CommonSteps commonSteps)
        {
            _commonSteps = commonSteps;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            // Retrieve the calculator from CommonSteps
            var calculator = _commonSteps.GetCalculator();
            _result = calculator.Add(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}
