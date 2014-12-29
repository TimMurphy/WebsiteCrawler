using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using WebsiteCrawler.Console;
using WebsiteCrawler.Specifications.Support;

namespace WebsiteCrawler.Specifications.Steps
{
    [Binding]
    public class ConsoleApplicationSteps
    {
        private int _consoleResult;
        private JObject _result;
        private string _resultPath;
        private string _startUrl;

        [When(@"I run the console application with valid arguments")]
        public void WhenIRunTheConsoleApplicationWithValidArguments()
        {
            _startUrl = MachineConfiguration.SimpleStaticWebsite;
            _resultPath = FileExtensions.GetTempFullName("json");
            _consoleResult = RunConsoleApplication(_startUrl, _resultPath);
        }

        private static int RunConsoleApplication(string startUrl, string resultPath)
        {
            var args = new[] {"--startUrl", startUrl, "--resultPath", resultPath};

            return Program.Main(args);
        }

        [AfterScenario]
        public void Cleanup()
        {
            _resultPath.DeleteTempFile();
        }

        [When(@"I run the console application with invalid arguments")]
        public void WhenIRunTheConsoleApplicationWithInvalidArguments()
        {
            throw new ToDoException();
        }

        [Then(@"the web site is crawled")]
        public void ThenTheWebSiteIsCrawled()
        {
            _consoleResult.Should().Be(0);
        }

        [Then(@"the report is created")]
        public void ThenTheReportIsCreated()
        {
            _resultPath.Exists().Should().BeTrue();
            _result = _resultPath.ReadJsonDocument();
        }

        [Then(@"the report lists all internal links")]
        public void ThenTheReportListsAllInternalLinks()
        {
            var actual = GetResultList("InternalLinks");
            var expected = new []
            {
                "index.html",
                "folder1/index.html",
                "folder2/index.html",
                "folder3/index.html"
            };

            actual.Should().BeEquivalentTo(expected.Select(e => MachineConfiguration.SimpleStaticWebsite.Replace("index.html", e)));
        }

        private IEnumerable<string> GetResultList(string propertyName)
        {
            var value = _result[propertyName];
            var values = value.Select(x => x.ToString());

            return values;
        }

        [Then(@"the application help is displayed")]
        public void ThenTheApplicationHelpIsDisplayed()
        {
            throw new ToDoException();
        }
    }
}