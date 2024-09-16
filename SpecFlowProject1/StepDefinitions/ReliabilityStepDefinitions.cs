using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ReliabilityStepDefinitions
    {
        private readonly InstantiateCalculator _calculator;
        private double _result;

        public ReliabilityStepDefinitions(InstantiateCalculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press FailureIntensity")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressFailureIntensity(double initial_failure_intensity, double avg_failures, double ttl_failures)
        {
            var calculator = _calculator.GetCalculator();
            _result = calculator.CalculateFailureIntensity(initial_failure_intensity, avg_failures, ttl_failures);
        }

        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press ExpectedFailures")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressExpectedFailures(double current_failure_intensity, double initial_failure_intensity, double ttl_failures)
        {
            var calculator = _calculator.GetCalculator();
            _result = calculator.CalculateExpectedFailures(current_failure_intensity, initial_failure_intensity, ttl_failures);
        }

        [Then(@"the failure intensity result should be ""(.*)""")]
        public void ThenTheFailureIntensityResultShouldBe(string expectedResult)
        {
            Assert.That(_result.ToString("F3"), Is.EqualTo(expectedResult));
        }

        [Then(@"the expected failures result should be ""(.*)""")]
        public void ThenTheExpectedFailuresResultShouldBe(string expectedResult)
        {
            Assert.That(_result.ToString("F1"), Is.EqualTo(expectedResult));
        }
    }
}
