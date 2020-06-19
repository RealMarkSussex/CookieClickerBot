using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
                //var lineOutput = File.ReadAllLines("Cookies.txt");
                //foreach (var line in lineOutput)
                //{
                //    var cookieStrings = line.Split(",");
                //    var cookie = new Cookie(cookieStrings[2], cookieStrings[4], cookieStrings[0], cookieStrings[3], Convert.ToDateTime(cookieStrings[1]));
                //    driver.Manage().Cookies.AddCookie(cookie);
                //}
                while (true)
                {
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
                    //var cookies = driver.Manage().Cookies.AllCookies;
                    //var lines = cookies.Select(cookie => cookie.Domain + "," + cookie.Expiry + "," + cookie.Name + "," + cookie.Path + "," + cookie.Value).ToList();
                    //File.WriteAllLines("Cookies.txt", lines);
                }
            }
        }
    }
}
