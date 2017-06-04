using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAZip.Pages.NavigationPage
{
    public partial class NavigationPage
    {
        public IWebElement CitiesWithI
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//table[5]/tbody/tr/td/a[9]"));
            }
        }
    }
}
