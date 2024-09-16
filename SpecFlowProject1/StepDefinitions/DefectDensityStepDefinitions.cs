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

        public DefectDensityStepDefinitions(InstantiateCalculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press DefectDensity")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDefectDensity(int defects, int ssi)
        {
            var calculator = _calculator.GetCalculator();
            _result = calculator.CalculateDefectDensity(defects, ssi);
        }

        [Then(@"the defect density result should be ""(.*)""")]
        public void ThenTheDefectDensityResultShouldBe(string expectedResult)
        {
            Assert.That(_result.ToString("F2"), Is.EqualTo(expectedResult));
        }
    }
}
