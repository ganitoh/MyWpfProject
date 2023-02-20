namespace MyWpfProject.View.MainView.ParserView.core
{

    interface IParserSettings
    {
         string  BaseUrl { get;  }
         string  Prefix { get; }
         int StartPoint { get; set; }
         int  EndPoint { get; set; }
    }
}