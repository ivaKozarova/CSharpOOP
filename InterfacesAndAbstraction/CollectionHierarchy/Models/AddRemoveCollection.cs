using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public AddRemoveCollection()
        {
        }
        public int Add(string item)
        {
            if (this.collection.Count < MAX_LENTGH)
            {
                this.collection.Insert(0,item);
            }
            return 0;
        }

        public string Remove()
        {
            var index = this.collection.Count - 1;
            var item = this.collection[index];
            this.collection.RemoveAt(index);
            return item;
        }
    }
}
