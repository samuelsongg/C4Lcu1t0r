using NUnit.Framework;
using SpecFlowProject1.StepDefinitions;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class DefectDensityStepDefinitions
    {
        private readonly InstantiateCalculator _calculator;
        private double _result;
        private Exception _exception;

        public DefectDensityStepDefinitions(InstantiateCalculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press DefectDensity")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDefectDensity(int defects, int ssi)
        {
            var calculator = _calculator.GetCalculator();

            try
            {
                _result = calculator.CalculateDefectDensity(defects, ssi);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the defect density result should be ""(.*)""")]
        public void ThenTheDefectDensityResultShouldBe(string expectedResult)
        {
            if (_exception == null)
            {
                Assert.That(_result.ToString("F2"), Is.EqualTo(expectedResult));
            }
            else
            {
                Assert.Fail($"Unexpected exception: {_exception.Message}");
            }
        }

        [Then(@"a Defect Density exception should be thrown with the message ""(.*)""")]
        public void ThenAnExceptionShouldBeThrownWithTheMessage(string expectedMessage)
        {
            Assert.That(_exception, Is.Not.Null, "Expected an exception, but none was thrown.");
            Assert.That(_exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}
