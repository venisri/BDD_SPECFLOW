using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdd_speckflow.FeatureSuite
{
    public class TestFixtureBase
    {
        protected IWebDriver CurrentDriver { get; set; }

        [SetUp]
        public void Test_Setup()
        {
            FirefoxBinary fb;
            if (!String.IsNullOrWhiteSpace(Settings.CurrentSettings.FirefoxBinaryPath))
            {
                fb = new FirefoxBinary(Settings.CurrentSettings.FirefoxBinaryPath);
            }
            else
            {
                fb = new FirefoxBinary();
            }
            CurrentDriver = new FirefoxDriver();
        }



        [TearDown]
        public void Test_Teardown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed
                        && CurrentDriver is ITakesScreenshot)
                {
                    ((ITakesScreenshot)CurrentDriver).GetScreenshot().SaveAsFile(TestContext.CurrentContext.Test.FullName + ".jpg", ScreenshotImageFormat.Jpeg);
                }
            }
            catch { }   // null ref exception occurs from accessing TestContext.CurrentContext.Result.Status property

            try
            {
                
                CurrentDriver.Close();
               
               // CurrentDriver.Quit();
                
            }
            catch { }
        }

    }

}
