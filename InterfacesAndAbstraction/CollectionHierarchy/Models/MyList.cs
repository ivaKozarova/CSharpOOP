using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : Collection, IMyList
    {
        public int Used => this.collection.Count;

        public int Add(string item)
        {
            if (this.collection.Count < MAX_LENTGH)
            {
                this.collection.Insert(0, item);
            }
            return 0;
        }

        public string Remove()
        {
            
            var item = this.collection[0];
            this.collection.RemoveAt(0);
            return item;
        }
    }
}
