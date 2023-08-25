using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SerilogDemo.Controllers;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] 
        public void Test1()
        {
            HomeController home = new HomeController();
            string result = home.GetEmployeeName(1);
            Assert.That(result, Is.EqualTo("Jignesh"));
            Assert.Pass();
        }

        [TestCase(1, "Jignesh")]
        [TestCase(2, "Rakesh")]
        [TestCase(3, "Not Found")]
        public void Test3(int empId, string name)
        {
            HomeController home = new HomeController();
            string result = home.GetEmployeeName(empId);
            Assert.That(result, Is.EqualTo(name));
        }



        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\");
        }

        [Test]
        public void test()
        {
            driver.Url = "http://www.google.co.in";
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }


        IWebDriver m_driver;

        [Test]
        public void cssDemo()
        {
            m_driver = new ChromeDriver("D:\\");
            m_driver.Url = "https://demo.guru99.com/test/guru99home/";
            m_driver.Manage().Window.Maximize();
            IWebElement link = m_driver.FindElement(By.XPath(".//*[@id='rt-header']//div[2]/div/ul/li[2]/a"));
            link.Click();
            m_driver.Close();
        }
    }
}