using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace MyWpfProject.View.MainView.ParserView.core
{
    interface IParser<T> where T : class
    {
        T ParseUrl(IHtmlDocument document);
    }
}