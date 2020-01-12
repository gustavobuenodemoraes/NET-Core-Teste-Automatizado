using ALura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; set; }
        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
