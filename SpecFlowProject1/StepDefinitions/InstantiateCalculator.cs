using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class InstantiateCalculator
    {
        private Calculator _calculator;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new Calculator();
        }

        // Provide a way to access the instantiated Calculator
        public Calculator GetCalculator()
        {
            return _calculator;
        }
    }
}
