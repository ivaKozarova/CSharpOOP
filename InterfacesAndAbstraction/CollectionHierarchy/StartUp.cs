using CollectionHierarchy.Core;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection collection = new AddCollection();
            Engine engine = new Engine();
            engine.Run();

        }
    }
}
