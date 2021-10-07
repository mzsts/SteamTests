using OpenQA.Selenium;

namespace Task2SteamTests.PageObjects
{
    public class MainPagePageObject
    {
        private IWebDriver webDriver;

        private readonly By searchGameInput = By.XPath("//*[contains(@id,'store_nav_search_term')]");
        private readonly By searchGameInputButton = By.XPath("//*[contains(@id,'store_search_link')]//img");
        private readonly By popularGamesCarousel = By.XPath("//*[contains(@class,'carousel_container') and contains(@class,'maincap')]");

        public bool IsPageLoaded { get => webDriver.FindElements(popularGamesCarousel)[0].Displayed; }

        public MainPagePageObject(IWebDriver webDriver) => this.webDriver = webDriver;

        public GameListPageObject SearchGame(string gameTitle)
        {
            webDriver.FindElement(searchGameInput).SendKeys(gameTitle);
            webDriver.FindElement(searchGameInputButton).Click();

            return new GameListPageObject(webDriver);
        }
    }
}
