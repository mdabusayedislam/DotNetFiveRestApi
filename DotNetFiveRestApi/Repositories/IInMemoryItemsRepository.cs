using DotNetFiveRestApi.Entities;
using System;
using System.Collections.Generic;

namespace DotNetFiveRestApi.Repositories
{
    public interface IInMemoryItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}