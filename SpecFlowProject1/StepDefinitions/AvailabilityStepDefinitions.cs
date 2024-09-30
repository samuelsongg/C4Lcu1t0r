using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class AvailabilityStepDefinitions
    {
        private readonly InstantiateCalculator _calculator;
        private double _result;
        private Exception _exception;

        public AvailabilityStepDefinitions(InstantiateCalculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double mttf, double mttr)
        {
            var calculator = _calculator.GetCalculator();
            try
            {
                _result = calculator.CalculateMTBF(mttf, mttr);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double mttf, double mttr)
        {
            var calculator = _calculator.GetCalculator();
            try
            {
                _result = calculator.CalculateAvailability(mttf, mttr);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
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
                if (_exception == null)
                {
                    Assert.That(_result, Is.EqualTo(double.Parse(expectedResult)));
                }
                else
                {
                    Assert.Fail($"Unexpected exception: {_exception.Message}");
                }
            }
        }

        [Then(@"a Availability exception should be thrown with the message ""(.*)""")]
        public void ThenAAvailabilityExceptionShouldBeThrownWithTheMessage(string expectedMessage)
        {
            Assert.That(_exception, Is.Not.Null, "Expected an exception, but none was thrown.");
            Assert.That(_exception.Message, Is.EqualTo(expectedMessage));
        }

        [Then(@"a MTBF exception should be thrown with the message ""(.*)""")]
        public void ThenAMTBFExceptionShouldBeThrownWithTheMessage(string expectedMessage)
        {
            Assert.That(_exception, Is.Not.Null, "Expected an exception, but none was thrown.");
            Assert.That(_exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}
