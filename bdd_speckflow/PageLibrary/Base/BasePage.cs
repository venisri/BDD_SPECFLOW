using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdd_speckflow.PageLibrary.Base
{
    public abstract partial class BasePage : TestBase
    {
        public string BaseURL { get; set; }
        public virtual string DefaultTitle { get { return ""; } }
      

        protected TPage GetInstance<TPage>(IWebDriver driver = null, string expectedTitle = "") where TPage : BasePage, new()
        {
            return GetInstance<TPage>(driver ?? Driver, BaseURL, expectedTitle);
        }

        protected static TPage GetInstance<TPage>(IWebDriver driver, string baseUrl, string expectedTitle = "") where TPage :BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                Driver = driver,
                BaseURL = baseUrl
            };
            PageFactory.InitElements(driver, pageInstance);

            if (string.IsNullOrWhiteSpace(expectedTitle)) expectedTitle = pageInstance.DefaultTitle;

            //wait up to 5s for an actual page title since Selenium no longer waits for page to load after 2.21

            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                                            .Until<IWebElement>((d) => {
                                                return d.FindElement(ByChained.TagName("body"));
                                            });

            //AssertIsEqual(expectedTitle, driver.Title, "Page Title");

            return pageInstance;
        }

        /// <summary>
        /// Asserts that the current page is of the given type
        /// </summary>
        public void Is<TPage>() where TPage : BasePage, new()
        {
            if (!(this is TPage))
            {
                throw new AssertionException(String.Format("Page Type Mismatch: Current page is not a '{0}'", typeof(TPage).Name));
            }
        }

        /// <summary>
        /// Inline cast to the given page type
        /// </summary>
        public TPage As<TPage>() where TPage : BasePage, new()
        {
            return (TPage)this;
        }
    }

}