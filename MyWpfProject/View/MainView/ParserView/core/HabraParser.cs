using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

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

        public Dictionary<string,string> ParseUrl(IHtmlDocument document)
        {
            var dictionary = new Dictionary<string,string>();
            var itemsValue = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("tm-title__link")).ToArray();
            var itemsHref = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("tm-title__link")).Select(el => el.GetAttribute("href")).ToArray();

            for (int i = 0; i < itemsValue.Length; i++)
            {
                dictionary.Add($"{itemsValue[i].TextContent}", $"https://habr.com{itemsHref[i]}");
            }

            return dictionary;
        }
    }
}