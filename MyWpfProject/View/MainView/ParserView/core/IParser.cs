using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace MyWpfProject.View.MainView.ParserView.core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
        Dictionary<string,string> ParseUrl(IHtmlDocument document);
    }
}