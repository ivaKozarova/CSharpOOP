namespace CollectionHierarchy.Contracts
{
   public  interface IMyList : IAddCollection , IAddRemoveCollection
    {
        int Used { get; }
    }
}
