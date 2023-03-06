namespace MyWpfProject.View.MainView.ParserView.core
{
    class ParserSettings : IParserSettings
    {
        public string BaseUrl { get;  } = "https://habr.com/ru/all";
        public string Prefix { get; } = "page{CurrentId}";
        public int StartPoint { get ; set; }
        public int EndPoint { get; set; }
        public ParserSettings( int startPoint, int endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}