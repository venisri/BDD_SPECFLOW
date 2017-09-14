using bdd_speckflow.PageLibrary.Base;
using bdd_speckflow.FeatureSuite;
using bdd_speckflow.FeatureSuite.Feature;
using System;
using TechTalk.SpecFlow;
using bdd_speckflow.PageLibrary.Pages;
using System.Threading;
using NUnit.Framework;

namespace bdd_speckflow.TestScripts
{
    [Binding]
    public class NavigationFeatureSteps:FeatureBase
    {
        [Given(@"I have entered the URL of KLM")]
        public void GivenIHaveEnteredTheURLOfKLM()
        {
            CurrentPage = BasePage.LoadIndexPage(CurrentDriver, Settings.CurrentSettings.BaseUrl);
           
                 
        }
        
        [Given(@"Iam on the Welcomepage of KLM")]
        public void GivenIamOnTheWelcomepageOfKLM()
        {
            Console.WriteLine(CurrentPage.DefaultTitle);
            Assert.That(CurrentPage.DefaultTitle.Equals("KLM Royal Dutch Airlines – Flights | Vliegtickets | Flüge"));
            Thread.Sleep(3000);
            Console.WriteLine(" Step 2 passed");
        }
        
        [When(@"I clicked  on the Germany  Link")]
        public void WhenIClickedOnTheGermanyLink()
        {
            CurrentPage.NavigateToLogo();
            NextPage=CurrentPage.GoToGermanyBookingPage();
            Console.WriteLine(" Step 3 passed");
        }

        [Then(@"I should landed on the Germany Page")]
        public void ThenIShouldLandedOnTheGermanyPage()
        {
            Console.WriteLine(Default.BookingpageData.GermanyText);
           CurrentPage.As<BookingPage>().GermanyLangIsDisplayed(Default.BookingpageData.GermanyText);
            Console.WriteLine(" Step 4 passed");
        }

        [When(@"I clicked  on the Norway  Link")]
        public void WhenIClickedOnTheNorwayLink()
        {
            NextPage=CurrentPage.GoToNorwayBookingPage();
            Console.WriteLine(" Step 2 passed");
        }
        [Then(@"I should landed on the Norway Page")]
        public void ThenIShouldLandedOnTheNorwayPage()
        {
           CurrentPage.As<BookingPage>().CountryNameIsDisplayed(Default.BookingpageData.NorwayText);
            Console.WriteLine(" Step 3 passed");
        }

        [When(@"I clicked  on the UK  Link")]
        public void WhenIClickedOnTheUKLink()
        {
            NextPage=CurrentPage.GoToUKBookingPage();
            Console.WriteLine(" Step 2 passed");
        }
          
        [Then(@"I should landed on the UK Page")]
        public void ThenIShouldLandedOnTheUKPage()
        {
            CurrentPage.As<BookingPage>().CountryNameIsDisplayed(Default.BookingpageData.UKText);
            Console.WriteLine(" Step 3 passed");
        }
    }
}
