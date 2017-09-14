using bdd_speckflow.PageLibrary.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bdd_speckflow.PageLibrary.Pages
{
       public  class HomePage : BasePage
    {
        public override string DefaultTitle { get { return "KLM Royal Dutch Airlines"; } }
        

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


        //public void VerifyPage(string pageTitle)
        //{
        //    if (!pageTitle.Equals(Browser.Current.Title))
        //    {
        //        throw new InvalidOperationException("This page is not " + pageTitle + ". The title is: " + Browser.Current.Title);
        //    }
        //}


       


        public BookingPage ClickOnCountryLink(IWebElement elt)
        {
            elt.Click();
            Thread.Sleep(3000);
            //return new BookingPage();
            return GetInstance<BookingPage>();
        }
        


        
    }

}