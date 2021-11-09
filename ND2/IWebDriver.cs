namespace ND2
{
    internal interface IWebDriver
    {
        string Url { get; set; }

        IWebElement CssSelector(object p);
        IWebElement FindElement(object p);
    }
}