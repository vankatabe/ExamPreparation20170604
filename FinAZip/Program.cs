using FinAZip.Models;
using FinAZip.Pages.ContentPage;
using FinAZip.Pages.GooglePage;
using FinAZip.Pages.NavigationPage;
using FinAZip.Pages.TargetPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinAZip
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            /* Add AdBlock plugin and start Firefox with plugin enabled - doesn't work
            FirefoxProfile profile = new FirefoxProfile();
            profile.AddExtension(@"..\..\Extensions\adblock_firefox.xpi");
            FirefoxDriver driver = new FirefoxDriver(profile);
            */

            // Add AdBlock plugin and start Chrome with plugin enabled
            ChromeOptions options = new ChromeOptions();
            options.AddExtension(@"C:\Extensions\adblock_chrome.crx");
            ChromeDriver driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();
            driver.Url = "http://www.findazip.com/";
            NavigationPage nav = new NavigationPage(driver);
            nav.CitiesWithI.Click();

            TargetPage target = new TargetPage(driver);
            var cities = target.Cities;


            ContentPage content = new ContentPage(driver);
            var citiesURLs = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                citiesURLs.Add(cities[i].GetAttribute("href"));
            }

            var citiesForClick = new List<CityInfo>();
            foreach (var citiesURL in citiesURLs)
            {
                driver.Url = citiesURL;
                citiesForClick.Add(new CityInfo(content.Name.Text,
                                                content.State.Text,
                                                content.Zip.Text,
                                                content.Longitude.Text,
                                                content.Latitude.Text));
            }

            driver.Url = "https://www.google.bg/maps";
            GooglePage maps = new GooglePage(driver);
            foreach (var cityInfo in citiesForClick)
            {
                maps.Search.Clear();
                maps.Search.SendKeys($"{cityInfo.Latitude}, {cityInfo.Longitude}");
                maps.Search.SendKeys(Keys.Enter);
                // Or: driver.Url = $"https://www.google.bg/maps/@{cityInfo.Latitude},{cityInfo.Longitude},15z";

                Thread.Sleep(5000);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile($"{cityInfo.Name}-{cityInfo.State}-{cityInfo.Zip}"+".jpg", ScreenshotImageFormat.Jpeg);
            }
        }
    }
}
