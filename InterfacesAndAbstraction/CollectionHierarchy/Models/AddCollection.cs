using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{

    public class AddCollection : Collection, IAddCollection
    {
        public AddCollection()
        {
        }
        public int Add(string item)
        {
            if (this.collection.Count < MAX_LENTGH)
            {
                this.collection.Add(item);                
            }
            return this.collection.Count - 1;
        }
    }
}
