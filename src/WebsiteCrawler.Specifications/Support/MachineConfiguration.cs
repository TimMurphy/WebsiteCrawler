namespace WebsiteCrawler.Specifications.Support
{
    internal class MachineConfiguration
    {
        static MachineConfiguration()
        {
            SimpleStaticWebsite = @"file:///C:/Users/Tim/Code/TimMurphy/WebsiteCrawler/src/WebsiteCrawler.Specifications/Support/Dummies/SimpleStaticWebsite/index.html";
        }

        public static string SimpleStaticWebsite { get; private set; }
    }

}