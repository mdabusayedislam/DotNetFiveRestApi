﻿using DotNetFiveRestApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetFiveRestApi.Repositories
{
    public class InMemoryItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion 1", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Potion 2", Price = 10, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Potion 3", Price = 11, CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            var item= items.Where(a => a.Id == id).SingleOrDefault();
            return await Task.FromResult(item);

        }

        public async Task CreateItemAsync(Item item)
        {
           items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(a => a.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(a => a.Id ==id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
