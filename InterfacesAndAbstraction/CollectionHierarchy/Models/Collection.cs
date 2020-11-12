using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public abstract class Collection
    {
        protected const int MAX_LENTGH = 100;
        protected List<string> collection;
        public Collection()
        {
            this.collection = new List<string>();
        }
    }
}
