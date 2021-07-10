﻿using DotNetFiveRestApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetFiveRestApi.Repositories
{
    public class InMemoryItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id=Guid.NewGuid(),Name="Potion 1",Price=9,CreatedDate=DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Potion 2", Price = 10, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Potion 3", Price = 11, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(a=>a.Id==id).SingleOrDefault();
        }
    }
}
