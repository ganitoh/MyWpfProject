using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Markup;

namespace MyWpfProject.View.MainView.ParserView.core
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("tm-title__link"));

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            return list.ToArray();

            
        }
    }
}