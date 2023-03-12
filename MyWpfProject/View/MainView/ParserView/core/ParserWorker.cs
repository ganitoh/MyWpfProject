using AngleSharp.Html.Parser;
using System;
using System.CodeDom;

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

		public event Action<object, T> OnNewData;
		public event Action<object> OnComplited;

        public ParserWorker(IParser<T> parser)
		{
			this.parser = parser;
		}
		public ParserWorker(IParser<T> parser,IParserSettings parserSettings):this(parser)
		{
			this.parserSettings = parserSettings;
		}

		public void Start()
		{
			isActive = true;
			Worker();
		}
		public void Stop()
		{
			isActive= false;
		}

        private async void Worker()
        {
			for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
			{
				if (!isActive)
				{
					OnComplited?.Invoke(this);
					return;
				}

				var source = await loader.GetSourceByPage(i);

				var domParser = new HtmlParser();
				var document = await domParser.ParseDocumentAsync(source);

				var result = parser.Parse(document);

				OnNewData?.Invoke(this, result);
			}
			OnComplited?.Invoke(this);
			isActive = false;
        }
    }
}