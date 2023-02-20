using AngleSharp.Html.Parser;
using System;

namespace MyWpfProject.View.MainView.ParserView.core
{
	class ParserWorker<T> where T : class
	{
		private	IParser<T> parser;
		private IParserSettings parserSettings;
		private HtmlLoader loader;
		private bool isActive;

        #region Prooerties
		public IParser<T> Parser 
		{
			get
			{
				return parser; 
			}
			set 
			{
				parser = value;
			}
		}

		public IParserSettings ParserSettings
		{
			get 
			{
				return parserSettings;
			}
			set
			{
				parserSettings = value;
				loader = new HtmlLoader(value);
			}
		}


        #endregion

    }
}