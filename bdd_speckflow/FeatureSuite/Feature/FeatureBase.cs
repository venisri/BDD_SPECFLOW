using bdd_speckflow.PageLibrary.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace bdd_speckflow.FeatureSuite.Feature
{
    
    public class FeatureBase : TestFixtureBase
    {

        #region Properties for Readability

        /// <summary>
        /// Shortcut property to Settings.CurrentSettings.Defaults for readability
        /// </summary>
        protected DefaultValues.DefaultValues Default { get { return Settings.CurrentSettings.Defaults; } }

        /// <summary>
        /// Sets the Current page to the specified value - provided to help readability
        /// </summary>
        protected BasePage NextPage { set { CurrentPage = value; } }

        #endregion

        protected BasePage CurrentPage
        {
            get { return (BasePage)ScenarioContext.Current["CurrentPage"]; }
            set { ScenarioContext.Current["CurrentPage"] = value; }
        }

        [BeforeScenario("UI")]
        public void BeforeScenario()
        {
            Console.WriteLine("Before");
            if (!ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Setup();
                ScenarioContext.Current.Add("CurrentDriver", CurrentDriver);
            }
            else
            {
                CurrentDriver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
        }

        [AfterScenario("UI")]
        public void AfterScenario()
        {
            Console.WriteLine("After");
            if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Teardown();
                ScenarioContext.Current.Remove("CurrentDriver");
            }
        }
    }
}
