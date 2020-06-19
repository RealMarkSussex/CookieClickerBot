using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CookieClickerBot
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://orteil.dashnet.org/cookieclicker/");
                Thread.Sleep(5000);
                driver.FindElementById("prefsButton").Click();
                Thread.Sleep(1000);
                driver.FindElementByLinkText("Import save").Click();
                var saveFile = File.ReadAllText("CookieSave.txt");
                driver.FindElementById("textareaPrompt").SendKeys(saveFile);
                driver.FindElementById("promptOption0").Click();
                var numOfLoops = 0;
                while (true)
                {
                    if (numOfLoops == 100)
                    {
                        try
                        {
                            driver.FindElementById("prefsButton").Click();
                            Thread.Sleep(1000);
                            driver.FindElementByLinkText("Export save").Click();
                            var save = driver.FindElementById("textareaPrompt").Text;
                            File.WriteAllText("CookieSave.txt", save);
                            driver.FindElementById("promptOption0").Click();
                            numOfLoops = 0;
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    try
                    {
                        driver.FindElementById("bigCookie").Click();
                    }
                    catch
                    {
                        break;
                    }
                    var productNum = new Random().Next(10);
                    var productElementId = "product" + productNum;
                    try
                    {
                        driver.FindElementById(productElementId).Click();
                    }
                    catch
                    {
                        continue;
                    }

                    numOfLoops++;
                }
            }
        }
    }
}
