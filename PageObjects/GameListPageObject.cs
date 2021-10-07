using OpenQA.Selenium;
using System;

namespace Task2SteamTests.PageObjects
{
    public class GameListPageObject
    {
        private IWebDriver webDriver;

        private readonly By searchResultList = By.XPath("//*[contains(@id,'search_resultsRows')]//a");
        private readonly By sortByTrigger = By.XPath("//*[contains(@id,'sort_by_trigger')]");
        private readonly By sortByPriceDescButton = By.XPath("//*[contains(@id,'Price_DESC')]");
        private readonly By gamePrice = By.XPath("//*[contains(@id, search_resultsRows')]//*[@class='col search_price  responsive_secondrow']");

        public int FoundGamesCount { get => webDriver.FindElements(searchResultList).Count; }
        public bool IsPageLoaded { get => webDriver.FindElements(sortByTrigger)[0].Displayed; }

        public GameListPageObject(IWebDriver webDriver) => this.webDriver = webDriver;

        public void SortGamesByPriceDesc()
        {
            webDriver.FindElement(sortByTrigger).Click();
            webDriver.FindElement(sortByPriceDescButton).Click();
        }

        public bool IsSortingCorrect(int quantityToCheck)
        {
            var elements = webDriver.FindElements(gamePrice);

            for (int i = 0; i < quantityToCheck; i++)
            {
                if (GetPriceAsDouble(elements[i].Text) < GetPriceAsDouble(elements[i].Text))
                {
                    return false;
                }
            }

            return true;
        }

        private static double GetPriceAsDouble(string text)
        {
            if (String.IsNullOrEmpty(text.Trim()) || Char.IsDigit(text[0]) is false)
            {
                return 0;
            }

            if (Double.TryParse(text.Trim().Substring(0, text.IndexOf(' ')), out double price))
            {
                return price;
            }

            return 0;
        }
    }
}
