using System;
namespace InterfacesAndAbstraction
{
    public class Document : IPrintable
    {

        public Document(string title,string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public void Print()
        {
           Console.WriteLine(this.Title);
            Console.WriteLine(this.Content);
        }
    }
}
