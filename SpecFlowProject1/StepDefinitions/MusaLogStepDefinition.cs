using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class MusaLogStepDefinition
    {
        private readonly InstantiateCalculator _calculator;
        private string _result;

        public MusaLogStepDefinition(InstantiateCalculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*), (.*), (.*), and (.*) into the calculator and press MusaLogReliability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMusaLogReliability(double lambda0, double theta, double mu, double time)
        {
            var calculator = _calculator.GetCalculator();
            _result = calculator.CalculateMusaLogReliability(lambda0, theta, mu, time);
        }

        [Then(@"the Musa Log reliability result should be ""(.*)""")]
        public void ThenTheMusaLogReliabilityResultShouldBe(string expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult));
        }
    }
}
