using AngleSharp.Html.Dom;

namespace MyWpfProject.View.MainView.ParserView.core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}