using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace POM_SELENIUM
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "wp-login.php");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

    public class LoginCommand
    {
        private string password;
        private readonly string username;

        public LoginCommand(string username)
        {
            this.username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.XPath("//input[@id='user_login']"));
            loginInput.SendKeys(username);

            var passwordInput = Driver.Instance.FindElement(By.XPath("//input[@id='user_pass']"));
            passwordInput.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.XPath("//input[@id='wp-submit']"));
            loginButton.Click();

        }

    }
}
