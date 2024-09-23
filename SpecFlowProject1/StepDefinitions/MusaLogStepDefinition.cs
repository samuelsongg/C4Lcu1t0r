using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class MusaLogStepDefinition
    {
        private readonly InstantiateCalculator _calculator;
        private string _result;
        private Exception _exception;

        public MusaLogStepDefinition(InstantiateCalculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*), (.*), (.*), and (.*) into the calculator and press MusaLogReliability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMusaLogReliability(double lambda0, double theta, double mu, double time)
        {
            var calculator = _calculator.GetCalculator();
            try
            {
                _result = calculator.CalculateMusaLogReliability(lambda0, theta, mu, time);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the Musa Log reliability result should be ""(.*)""")]
        public void ThenTheMusaLogReliabilityResultShouldBe(string expectedResult)
        {
            if (_exception == null)
            {
                Assert.That(_result, Is.EqualTo(expectedResult));
            }
            else
            {
                Assert.Fail($"Unexpected exception: {_exception.Message}");
            }
        }

        [Then(@"a MusaLog exception should be thrown with the message ""(.*)""")]
        public void ThenAnExceptionShouldBeThrownWithTheMessage(string expectedMessage)
        {
            Assert.That(_exception, Is.Not.Null, "Expected an exception, but none was thrown.");
            Assert.That(_exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}
