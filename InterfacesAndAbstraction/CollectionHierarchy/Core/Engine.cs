using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy.Core
{
    class Engine
    {
        private AddCollection addCollection;
        private AddRemoveCollection addRemoveCollection;
        private MyList myList;

        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }

        public void Run()
        {
            var indexesAddCollection = new List<int>();
            var indexesAddRemoveCollection = new List<int>();
            var indexesMyList = new List<int>();

            var input = Console.ReadLine().Split().ToArray();

            AddElementToCollection(input, indexesAddCollection, indexesAddRemoveCollection, indexesMyList);

            Print(indexesAddCollection);
            Print(indexesAddRemoveCollection);
            Print(indexesMyList);

            var removeCount = int.Parse(Console.ReadLine());
            var removedItemsFromAddRemoveCollection = new List<string>();
            var removedItemsFromMyList = new List<string>();

            RemoveItems(removeCount, removedItemsFromAddRemoveCollection, removedItemsFromMyList);

            PrintRemoved(removedItemsFromAddRemoveCollection);
            PrintRemoved(removedItemsFromMyList);
        }

        private void Print(List<int> collection)
        {
            Console.WriteLine(string.Join(' ',collection));
        }
        private void PrintRemoved(List<string> collection)
        {
            Console.WriteLine(string.Join(' ', collection));
        }

        private void AddElementToCollection(string[] input, List<int> indexesAddCollection,
            List<int> indexesAddRemoveCollection, List<int> indexesMyList)
        {
            foreach (var item in input)
            {
                indexesAddCollection.Add(addCollection.Add(item));
                indexesAddRemoveCollection.Add(addRemoveCollection.Add(item));
                indexesMyList.Add(myList.Add(item));
            }
        }
        private void RemoveItems(int removeCount, List<string> removedItemsFromAddRemoveCollection, List<string> removedItemsFromMyList)
        {
            for (int i = 0; i < removeCount; i++)
            {
                removedItemsFromAddRemoveCollection.Add(addRemoveCollection.Remove());
                removedItemsFromMyList.Add(myList.Remove());
            }
        }


    }
}
