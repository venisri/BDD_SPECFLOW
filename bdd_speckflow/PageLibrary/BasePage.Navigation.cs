using bdd_speckflow.PageLibrary.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bdd_speckflow.PageLibrary.Base
{
    public abstract partial class BasePage
    {
        public static IndexPage LoadIndexPage(IWebDriver driver, string baseURL)
        {
            //Console.WriteLine("URL" + baseURL);
            driver.Navigate().GoToUrl(baseURL.TrimEnd(new char[] { '/' }) + IndexPage.URL);
            return GetInstance<IndexPage>(driver, baseURL, "");
        }

        [FindsBy(How = How.LinkText, Using = "Germany")]
        public IWebElement germanylink { get; set; }
        [FindsBy(How = How.LinkText, Using = "Netherlands")]
        public IWebElement netherlandsLink { get; set; }
        [FindsBy(How = How.LinkText, Using = "Norway")]
        public IWebElement norwayLink { get; set; }
        [FindsBy(How = How.LinkText, Using = "United Kingdom")]
        public IWebElement ukLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//header[@id='logo']/h1")]
        public IWebElement KLMLogo { get; set; }

        public IndexPage NavigateToLogo()
        {
            KLMLogo.Click();
            return GetInstance<IndexPage>(Driver);
        }


        public BookingPage GoToGermanyBookingPage()
        {
            germanylink.Click();
            Thread.Sleep(3000);
            return GetInstance<BookingPage>(Driver);
        }
        public BookingPage GoToNorwayBookingPage()
        {
            norwayLink.Click();
            Thread.Sleep(3000);
            return GetInstance<BookingPage>(Driver);
        }
        public BookingPage GoToUKBookingPage()
        {
            ukLink.Click();
            Thread.Sleep(3000);
            return GetInstance<BookingPage>(Driver);
        }


        protected String GetKLMLogoText()
        {
            return (KLMLogo.Text);
        }

    }
}
