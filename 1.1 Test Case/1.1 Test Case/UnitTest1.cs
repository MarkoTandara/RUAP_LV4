using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TestCase
    {
        private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;
    private bool acceptNextAlert = true;

    [SetUp]
    public void SetupTest()
    {
        driver = new FirefoxDriver();
        baseURL = "https://www.google.com/";
        verificationErrors = new StringBuilder();
    }

    [TearDown]
    public void TeardownTest()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
        Assert.AreEqual("", verificationErrors.ToString());
    }

    [Test]
    public void The11TestCaseTest()
    {
        driver.Navigate().GoToUrl("https://demo.opencart.com/");
        driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/i")).Click();
        driver.FindElement(By.LinkText("Register")).Click();
        driver.FindElement(By.Id("input-firstname")).Click();
        driver.FindElement(By.Id("input-firstname")).Clear();
        driver.FindElement(By.Id("input-firstname")).SendKeys("Marko");
        driver.FindElement(By.Id("input-lastname")).Clear();
        driver.FindElement(By.Id("input-lastname")).SendKeys("Tandara");
        driver.FindElement(By.Id("input-email")).Clear();
        driver.FindElement(By.Id("input-email")).SendKeys("markotandara12@gmail.com");
        driver.FindElement(By.Id("input-telephone")).Clear();
        driver.FindElement(By.Id("input-telephone")).SendKeys("+385911838420");
        driver.FindElement(By.Id("input-password")).Clear();
        driver.FindElement(By.Id("input-password")).SendKeys("registracija123");
        driver.FindElement(By.Id("input-confirm")).Clear();
        driver.FindElement(By.Id("input-confirm")).SendKeys("registracija123A");
        driver.FindElement(By.Id("input-password")).Click();
        driver.FindElement(By.Id("input-password")).Clear();
        driver.FindElement(By.Id("input-password")).SendKeys("registracija123A");
        driver.FindElement(By.Name("agree")).Click();
        driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
        driver.FindElement(By.LinkText("Continue")).Click();
    }
    private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return alertText;
        }
        finally
        {
            acceptNextAlert = true;
        }
    }
}
}
