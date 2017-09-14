using bdd_speckflow.PageLibrary.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdd_speckflow.PageLibrary.Pages
{
   public  class BookingPage : BasePage
    {
        public override string DefaultTitle { get { return "KLM Royal Dutch Airlines – Flights | Vliegtickets | Flüge"; } }

        [FindsBy(How = How.XPath, Using = "//span[@class='klm-countrylang-text']")]
        public IWebElement countryLanguageText { get; set; }

        public void GermanyLangIsDisplayed(String country)
        {
            Assert.That(countryLanguageText.Text.Contains(country),"Not Navigated to the"+ country+"Page");
        }

        public void CountryNameIsDisplayed(String country)
        {
            Assert.That(countryLanguageText.Text.Contains(country), "Not Navigated to the" + country + "Page");
        }
    }
}
