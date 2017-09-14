using bdd_speckflow.PageLibrary.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdd_speckflow.PageLibrary.Pages
{
  public  class TravelsPage:BasePage
    {
        public override string DefaultTitle { get { return "Travel Page"; } }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement countryLanguageText { get; set; }

        //public newPage SubmitOrder()
        //{
        //    ButtonSubmit.Click();
        //    return GetInstance<newPage>();
        //}


    }
}
