using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ReliabilityStepDefinitions
    {
        private readonly InstantiateCalculator _calculator;
        private double _result;
        private Exception _exception;

        public ReliabilityStepDefinitions(InstantiateCalculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press FailureIntensity")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressFailureIntensity(double initial_failure_intensity, double avg_failures, double ttl_failures)
        {
            var calculator = _calculator.GetCalculator();

            try
            {
                _result = calculator.CalculateFailureIntensity(initial_failure_intensity, avg_failures, ttl_failures);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press ExpectedFailures")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressExpectedFailures(double current_failure_intensity, double initial_failure_intensity, double ttl_failures)
        {
            var calculator = _calculator.GetCalculator();

            try
            {
                _result = calculator.CalculateExpectedFailures(current_failure_intensity, initial_failure_intensity, ttl_failures);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the failure intensity result should be ""(.*)""")]
        public void ThenTheFailureIntensityResultShouldBe(string expectedResult)
        {
            if (_exception == null)
            {
                Assert.That(_result.ToString("F3"), Is.EqualTo(expectedResult));
            }
            else
            {
                Assert.Fail($"Unexpected exception: {_exception.Message}");
            }
        }

        [Then(@"the expected failures result should be ""(.*)""")]
        public void ThenTheExpectedFailuresResultShouldBe(string expectedResult)
        {
            if (_exception == null)
            {
                Assert.That(_result.ToString("F1"), Is.EqualTo(expectedResult));
            }
            else
            {
                Assert.Fail($"Unexpected exception: {_exception.Message}");
            }
        }

        [Then(@"a Failure Intensity exception should be thrown with the message ""(.*)""")]
        public void ThenAFailureIntensityExceptionShouldBeThrownWithTheMessage(string expectedMessage)
        {
            Assert.That(_exception, Is.Not.Null, "Expected an exception, but none was thrown.");
            Assert.That(_exception.Message, Is.EqualTo(expectedMessage));
        }

        [Then(@"a Expected Failure exception should be thrown with the message ""(.*)""")]
        public void ThenAExpectedFailuresExceptionShouldBeThrownWithTheMessage(string expectedMessage)
        {
            Assert.That(_exception, Is.Not.Null, "Expected an exception, but none was thrown.");
            Assert.That(_exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}
