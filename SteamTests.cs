using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;
using Task2SteamTests.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Task2SteamTests
{
    public class Tests
    {
        private IWebDriver webDriver;

        private MainPagePageObject mainPagePageObject;
        private GameListPageObject gameListPageObject;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions chromeOptions = new();
            chromeOptions.AddArguments("-lang= " + TestSettingsProvider.GetLocalization());

            webDriver = new ChromeDriver(chromeOptions);
        }

        [Test]
        [TestCaseSource(typeof(TestParametersProvider), nameof(TestParametersProvider.GetParameters))]
        public void OpenMainPage_StandartBehavior_PageOpened(Models.TestParameters parameters)
        {
            webDriver.Navigate().GoToUrl(TestSettingsProvider.GetAppUrl());
            webDriver.Manage().Window.Maximize();

            mainPagePageObject = new(webDriver);

            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(15));
            Assert.IsTrue(wait.Until(result => mainPagePageObject.IsPageLoaded),
                "������� �������� �� ���� ���������");

            gameListPageObject = mainPagePageObject.SearchGame(parameters.GameTitle);

            Assert.IsTrue(wait.Until(result => gameListPageObject.IsPageLoaded),
                "�������� ������ �� ���� ���������");
            Assert.IsTrue(gameListPageObject.FoundGamesCount > 0, "������ ��� �������� ������");

            gameListPageObject.SortGamesByPriceDesc();
            Assert.IsTrue(wait.Until(result => gameListPageObject.IsSortingCorrect(parameters.QuantityToCheckSorting)),
                "���������� ��� �� �������� ���� �����������");
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}