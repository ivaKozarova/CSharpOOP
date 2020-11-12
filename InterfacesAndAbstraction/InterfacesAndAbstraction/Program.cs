namespace InterfacesAndAbstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document("title", "this is the content of the document!!!!");
            doc.Print();
            IPrintable printNewDoc = new Document("new title", "new content");
            printNewDoc.Print();
           
        }
    }
}
