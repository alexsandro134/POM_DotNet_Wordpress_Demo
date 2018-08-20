using OpenQA.Selenium;

namespace POM_SELENIUM
{
    public class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                var dashboardText = Driver.Instance.FindElements(By.XPath("//div[@class='wrap']/h1"));
                if (dashboardText.Count > 0)
                    return dashboardText[0].Text == "Dashboard";
                return false;
            }
        }
    }
}
