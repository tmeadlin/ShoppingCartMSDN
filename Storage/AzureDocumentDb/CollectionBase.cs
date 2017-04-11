

using AzureDocumentDb.Models;

namespace AzureDocumentDb
{
    public class CollectionBase<T> : AzureDocCollection<T>, IDocumentCollection<T> where T : CollectionItemEntity
    {
        public CollectionBase(IAzureDocDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}
