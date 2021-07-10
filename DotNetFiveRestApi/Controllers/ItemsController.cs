using DotNetFiveRestApi.Entities;
using DotNetFiveRestApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetFiveRestApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemoryItemsRepository repository;
        public ItemsController()
        {
            repository = new InMemoryItemsRepository();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items= repository.GetItems();
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item= repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
