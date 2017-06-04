using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAZip.Pages.ContentPage
{
    public partial class ContentPage
    {
        public IWebElement Name
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//td[2]/font/font/b"));
            }
        }

        public IWebElement State
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//td[2]/font/b"));
            }
        }

        public IWebElement Zip
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//b/b"));
            }
        }

         public IWebElement Longitude
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//tr[8]/td[2]/font/b"));
            }
        }

        public IWebElement Latitude
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//tr[9]/td[2]/font/b"));
            }
        }
    }
}
