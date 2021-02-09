﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System.Diagnostics;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.Threading;

namespace Test.Framework.Util
{
    //Utility Class, also known as Helper class, is a class, which contains just static methods, it is stateless and cannot be instantiated.
    //It contains a bunch of related methods, so they can be reused across the application.

    class IkmanUI
    {
        private IWebDriver driver = null;

        public static readonly int TIME_OUT = 15;
        static string parentWindow;
        public IkmanUI(IWebDriver d)
        {
            driver = d;
        }

        //SCREENSHOT
        public void CaptureScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(Settings.ScreenShot_path + "Step" + GetTimestamp(DateTime.Now) + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }

        //TIMESTAMP
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        //WAITING FOR ELEMENTS
        public IWebElement WaitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(1000));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        public IWebElement waitTillElementLoaded(By by, TimeSpan timeout)
        {
            return (IWebElement)(new WebDriverWait(this.driver, timeout)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public IWebElement waitTillElementLoaded(By by)
        {
            return this.waitTillElementLoaded(by, TimeSpan.FromSeconds(15));
        }

        public void waitTillCSSAttributeValueToBePresent(IWebElement element, String attributeName, String expectedValue, long timeout)
        {
            long counter = 0L;
            long timeoutNew = timeout * 1000L;
            while (counter <= timeoutNew)
            {
                try
                {
                    if (this.GetCssValue(element, attributeName).Equals(expectedValue))
                    {
                        return;
                    }
                }
                catch (NullReferenceException var14)
                {
                }
                finally
                {
                    this.sleepInMiliSeconds(50);
                    counter += 50L;
                }
            }
        }

        public bool LoaderNotVisible(By locator)
        {
            bool returnValue = false;
            try
            {
                returnValue = WaitForElementVisible(locator).Displayed;
                if (returnValue == true)
                {
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1000000);
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = true;
            }
            return returnValue;
        }

        //CLICK ELEMENTS
        public bool ClickElement(By locator)
        {
            bool returnValue = false;
            try
            {
                WaitForElementVisible(locator).Click();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public bool doubleClickElement(By locator)
        {
            bool returnValue = false;
            try
            {
                WaitForElementVisible(locator).Click();
                WaitForElementVisible(locator).Click();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public bool ClickMarkedElement(By locator, string mText)
        {
            Console.WriteLine("1working" + locator + mText);
            bool returnValue = false;
            try
            {
                Console.WriteLine("2working" + locator + mText);
                IList<IWebElement> objMark = driver.FindElements(locator);
                for (int i = 0; i < objMark.Count(); i++)
                {
                    Console.WriteLine("3working - " + objMark.Count());
                    IWebElement currentMark = objMark.ElementAtOrDefault(i);
                    Console.WriteLine("4working - " + currentMark.Text );
                    if (currentMark.Text == mText)
                    {
                        Console.WriteLine("List # " + currentMark.Text + " # found on page " + driver.Title);
                        ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(currentMark))).Click();
                        returnValue = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("List # " + currentMark.Text + " # not found on page " + driver.Title);
                        returnValue = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("NoSuchElementException # " + locator + " # not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Unknown error # " + e.Message + " # occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public bool ClickFilterElement(By locator, string fList)
        {
            bool returnValue = false;
            try
            {
                IList<IWebElement> objList = driver.FindElements(locator);
                for (int i = 0; i < objList.Count(); i++)
                {
                    IWebElement currentList = objList.ElementAtOrDefault(i);
                    if (currentList.Text == fList)
                    {
                        ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(currentList))).Click();
                        returnValue = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("List # " + currentList.Text + " # not found on page " + driver.Title);
                        returnValue = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("NoSuchElementException # " + locator + " # not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Unknown error # " + e.Message + " # occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }
        
        public bool ClickMultipleCheckBox(By locator, int num)
        {
            // Console.WriteLine("1working" + locator + Ttext);
            bool returnValue = false;
            try
            {
                //   Console.WriteLine("2working" + locator + Ttext);
                IList<IWebElement> objLink = driver.FindElements(locator);
                for (int i = 0; i < objLink.Count(); i++)
                {
                    //     Console.WriteLine("3working - " + objLink.Count());
                    IWebElement currentRowLink = objLink.ElementAtOrDefault(i);
                    //    Console.WriteLine("4working - " + currentRowLink.Text );
                    /*if (currentRowLink.Text == Ttext)
                    {
                        Console.WriteLine("Title # " + currentRowLink.Text + " # found on page " + driver.Title);
                        ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(currentRowLink))).Click();
                        returnValue = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Title # " + currentRowLink.Text + " # not found on page " + driver.Title);
                        returnValue = false;
                    }*/
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("NoSuchElementException # " + locator + " # not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Unknown error # " + e.Message + " # occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public bool ClickRowElement(By locator, string Ttext)
        {
            bool returnValue = false;
            try
            {
                IList<IWebElement> objLink = driver.FindElements(locator);
                for (int i = 0; i < objLink.Count(); i++)
                {
                    IWebElement currentRowLink = objLink.ElementAtOrDefault(i);
                    if (currentRowLink.Text == Ttext)
                    {
                        Console.WriteLine("Title # " + currentRowLink.Text + " # found on page " + driver.Title);
                        ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(currentRowLink))).Click();
                        returnValue = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Title # " + currentRowLink.Text + " # not found on page " + driver.Title);
                        returnValue = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("NoSuchElementException # " + locator + " # not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Unknown error # " + e.Message + " # occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public bool ClickRowElementCheckbox(By locator1, By locator2, string Ttext)
        {
            bool returnValue = false;
            try
            {
                IList<IWebElement> objTitle = driver.FindElements(locator1);
                for (int i = 0; i < objTitle.Count(); i++)
                {
                    IWebElement currentRowTitle = objTitle.ElementAtOrDefault(i);
                    if (currentRowTitle.Text == Ttext)
                    {
                        Console.WriteLine("Title # " + currentRowTitle.Text + " # found on page " + driver.Title);
                        ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(locator2))).Click();
                        returnValue = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Title # " + currentRowTitle.Text + " # not found on page " + driver.Title);
                        returnValue = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("NoSuchElementException # " + locator1 + " # not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Unknown error # " + e.Message + " # occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public void click(By by) {
            IWebElement element = this.FindElement(by);
            ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(element))).Click();
        }

        public void click(IWebElement element) {
            ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(element))).Click();
        }

        public void click(IWebElement parentElement, By by) {
            this.click(parentElement.FindElement(by));
        }

        public void clickWithJavascript(By by) {
            this.clickWithJavascript(this.FindElement(by));
        }

        public void clickWithJavascript(IWebElement element)
        {
            this.driver.ExecuteJavaScript("arguments[0].click();", new Object[] { element });
        }

        public void doubleClick(IWebElement element)
        {
            ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(element))).Click();
            ((IWebElement)(new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.ElementToBeClickable(element))).Click();
        }

        public void clickOnVisibleElement(By by)
        {
            IList<IWebElement> elements = this.findElements(by);
            IEnumerator var3 = elements.GetEnumerator();
            /*while (var3.hasNext())
            {
                IWebElement element = (IWebElement)var3.next();
                if (this.isDisplayed(element))
                {
                    this.click(element);
                }
            }*/
        }      

        //SEND VALUES
        public bool ValueSendkeys(By locator, String u)
        {
            bool returnValue = false;
            try
            {
                WaitForElementVisible(locator).SendKeys(u);
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        //Alphabetical Order
        public bool Alphabetical(By locator)
        {
            bool alphabetical = false;
            string previous = null;
            try
            {
                IList<IWebElement> titleList = driver.FindElements(locator);
                List<string> list = new List<string>();
                foreach (var item in titleList)
                {
                    string btnText = item.Text.Replace(System.Environment.NewLine, "");
                    var current = item.Text.Replace(System.Environment.NewLine, "");
                    list.Add(current);
                    //Console.WriteLine("working 1 - : | " + btnText);
                    if (previous != null && StringComparer.Ordinal.Compare(previous, current) > 0)
                    {
                        //Console.WriteLine("working 2 - : | " + alphabetical);
                        alphabetical = true;
                    }
                    previous = current;
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Title Element # " + locator + " # not found on page " + driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Title Unknown error # " + e.Message + " # occurred on page " + driver.Title);
            }
         return alphabetical;
        }
        
        //CLEAR FIELDS
        public bool Textclear(By locator)
        {
            bool returnValue = false;
            try
            {
                WaitForElementVisible(locator).Clear();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        //ISDISPLAY
        public bool IsElementVisible(By locator)
        {
            bool returnValue = false;
            try
            {
                returnValue = this.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element - " + locator + " - not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error - " + e.Message + " - occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public string isDetailTextVisible(By locator, String DTtext)
        {
            string returnValue = "";
            try
            {
                IList<IWebElement> objH4 = driver.FindElements(locator);

                for (int i = 0; i < objH4.Count(); i++)
                {
                    IWebElement currentH4 = objH4.ElementAtOrDefault(i);

                    if (currentH4.Text == DTtext)
                    {
                        returnValue = currentH4.Text;
                        Console.WriteLine("Text # " + returnValue + " # found on page " + driver.Title); 
                    }
                    else
                    {
                        returnValue = currentH4.Text;
                        Console.WriteLine("Text # " + returnValue + " # not found on page " + driver.Title);
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Text Element # " + locator + " # not found on page " + driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Text Unknown error # " + e.Message + " # occurred on page " + driver.Title);
                returnValue = e.Message;
            }
         return returnValue;
        }

        public bool isDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception var3)
            {
                return false;
            }
        }

        public bool IsEnabled(By by)
        {
            return this.WaitForElementVisible(by).Enabled;
        }

        public bool IsClickable(By by)
        {
            return this.FindElement(by).Enabled;
        }

        public bool isClickable(IWebElement element)
        {
            return element.Enabled;
        }

        //FIND ELEMENTS
        public IWebElement FindElement(By locator)
        {
            return this.driver.FindElement(locator);
        }

        public IList<IWebElement> findElements(By by)
        {
            return this.driver.FindElements(by);
        }

        //GET TEXT
        public String GetText(By locator)
        {
            IWebElement element = this.FindElement(locator);
            return element.Text;
        }

        public String getText(IWebElement element)
        {
            return element.Text;
        }

        public String getTitle()
        {
            return this.driver.Title;
        }

        public String GetInvisibleText(By locator)
        {
            return this.FindElement(locator).GetAttribute("textContent");
        }

        public String GetFirstSelectedOptionText(By locator)
        {
            SelectElement select = new SelectElement(this.FindElement(locator));
            IWebElement option = select.SelectedOption;
            return option.Text;
        }

        public String getFirstSelectedOptionText(IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            IWebElement option = select.SelectedOption;
            return option.Text;
        }

        //GET VALUE
        public String GetAttribute(By by, String attributeName)
        {
            return this.FindElement(by).GetAttribute(attributeName);
        }

        public String GetAttribute(IWebElement element, String attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public String GetCssValue(By by, String attributeName)
        {
            return this.FindElement(by).GetCssValue(attributeName);
        }

        public String GetCssValue(IWebElement element, String attributeName)
        {
            return element.GetCssValue(attributeName);
        }

        public String GetValue(By by)
        {
            return this.FindElement(by).GetAttribute("value");
        }

        public String GetValue(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public void SelectFromDropDown(By by, String option)
        {
            SelectElement oSelect = new SelectElement(driver.FindElement(by));
            oSelect.SelectByText(option);
        }

        //SCROLL
        public void ScrollUp()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, 0)", new Object[0]);
        }

        public void ScrollBottom()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)", new Object[0]);
        }

        public void ScrollRight()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(1000,0)", new Object[] { "" });
        }

        public void ScrollDown(double height)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0," + height + ")", new Object[0]);
        }

        public void ScrollToRight(By by)
        {
            IWebElement element = this.driver.FindElement(by);
            Actions actions = new Actions(this.driver);
            actions.MoveByOffset(0, 0);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public void ScrollToRight(IWebElement element)
        {
            Actions actions = new Actions(this.driver);
            actions.MoveByOffset(0, 0);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void ScrollToElement(IWebElement element)
        {
            Actions actions = new Actions(this.driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void ScrollToElement(By by)
        {
            Actions actions = new Actions(this.driver);
            actions.MoveToElement(this.FindElement(by));
            actions.Perform();
        }

        //MOVE
        public void Move(By by)
        {
            IWebElement element = this.FindElement(by);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", new Object[] { element });
        }

        public void Move(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", new Object[] { element });
        }

        public void MoveToAndClick(IWebElement element)
        {
            (new Actions(this.driver)).MoveToElement(element).Click().Perform();
        }

        public void MoveToAndClick(By by)
        {
            (new Actions(this.driver)).MoveToElement(this.FindElement(by)).Click().Perform();
        }

        //MOUSE ACTIONS
        public void mouseHover(By by)
        {
            (new Actions(this.driver)).MoveToElement(this.FindElement(by)).Build().Perform();
        }

        //SWITCH
        public void switchToFrame(By iFrame)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(iFrame));
        }

        public void switchToDefaultFrame()
        {
            this.driver.SwitchTo().DefaultContent();
        }

        public void switchToDefaultWindow()
        {
            this.driver.SwitchTo().Window(parentWindow);
        }

        public void switchToWindow()
        {
            parentWindow = this.driver.CurrentWindowHandle;
            IEnumerator var1 = this.driver.WindowHandles.GetEnumerator();
            /*while (var1.hasNext())
            {
                String handle = (String)var1.next();
                this.driver.SwitchTo().Window(handle);
            }*/
        }

        //SLEEP
        public void sleep(int noOfSeconds)
        {
            try
            {
                Thread.Sleep((1000*noOfSeconds));
            }
            catch (ThreadInterruptedException var3)
            {
                Thread.CurrentThread.Interrupt();
            }

        }

        public void sleepInMiliSeconds(int noOfMiliSeconds)
        {
            try
            {
                Thread.Sleep(noOfMiliSeconds);
            }
            catch (ThreadInterruptedException var3)
            {
                Thread.CurrentThread.Interrupt();
            }
        }

        //BROWSER FUNCTIONS
        public void navigateTo(String url)
        {
            this.driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void navigateBack()
        {
            this.driver.Navigate().Back();
        }

        public void refreshBrowser()
        {
            this.driver.Navigate().Refresh();
        }

        public void select(By by, String option)
        {
            (new SelectElement(this.FindElement(by))).SelectByText(option);
        }

        //ALERTS
        public bool isAlertDisplayed()
        {
            try
            {
                this.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException var2)
            {
                return false;
            }
        }

        public String getAlertText()
        {
            IAlert simpleAlert = this.driver.SwitchTo().Alert();
            return simpleAlert.Text;
        }

        public void clickOkInWindowsAlert()
        {
            IAlert simpleAlert = this.driver.SwitchTo().Alert();
            simpleAlert.Accept();
        }

        public void waitTillAlertBoxAppears()
        {
            (new WebDriverWait(this.driver, TimeSpan.FromSeconds(15))).Until(ExpectedConditions.AlertIsPresent());
        }
    }
}