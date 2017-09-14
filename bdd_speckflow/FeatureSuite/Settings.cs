using bdd_speckflow.FeatureSuite.DefaultValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bdd_speckflow.FeatureSuite
{
    class Settings { 
    public string BaseUrl { get; private set; }
    public string FirefoxBinaryPath { get; set; }

    public DefaultValues.DefaultValues Defaults { get; set; }

    private static Settings _settings;
    public static Settings CurrentSettings
    {
        get
        {
            if (_settings == null)
            {
                LoadSettings(@"C:\Users\venisridhar\documents\visual studio 2017\Projects\bdd_speckflow\bdd_speckflow\TestRun.config");
            }
            return _settings;
        }
    }

    private Settings(string url)
    {
        BaseUrl = url;
    }

    private static void LoadSettings(String file)
    {
        XElement settingsFile = XElement.Load(file);
        string url = settingsFile.Element("URL").Value;
        _settings = new Settings(url);

        _settings.Defaults = new DefaultValues.DefaultValues();
        _settings.Defaults.BookingpageData = new BookingpageData()
        {
            GermanyText = settingsFile.Element("germany").Value,
            NorwayText = settingsFile.Element("norway").Value,
            UKText = settingsFile.Element("uk").Value,

        };
       

        //_settings.Defaults.User = settingsFile.Descendants("user").Select(u => new User()
        //{
        //    Username = u.Element("username").Value,
        //    Password = u.Element("password").Value,
        //    FirstName = u.Element("firstName").Value,
        //    LastName = u.Element("lastName").Value,
        //    Address = u.Element("address").Value,
        //    City = u.Element("city").Value,
        //    State = u.Element("state").Value,
        //    PostalCode = u.Element("postalCode").Value,
        //    Country = u.Element("country").Value,
        //    PhoneNumber = u.Element("phoneNumber").Value,
        //    EmailAddress = u.Element("emailAddress").Value
        //}).FirstOrDefault();
    }

}
}
