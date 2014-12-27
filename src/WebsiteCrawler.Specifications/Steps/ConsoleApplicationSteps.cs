using TechTalk.SpecFlow;

namespace WebsiteCrawler.Specifications.Steps
{
    [Binding]
    public class ConsoleApplicationSteps
    {
        [When(@"I run the console application with valid arguments")]
        public void WhenIRunTheConsoleApplicationWithValidArguments()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I run the console application with invalid arguments")]
        public void WhenIRunTheConsoleApplicationWithInvalidArguments()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the web site is crawled")]
        public void ThenTheWebSiteIsCrawled()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the report lists all internal links")]
        public void ThenTheReportListsAllInternalLinks()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the report lists all external links")]
        public void ThenTheReportListsAllExternalLinks()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the report lists all broken links")]
        public void ThenTheReportListsAllBrokenLinks()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the report lists excluded urls")]
        public void ThenTheReportListsExcludedUrls()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the application help is displayed")]
        public void ThenTheApplicationHelpIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
