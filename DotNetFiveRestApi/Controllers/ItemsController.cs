using DotNetFiveRestApi.Dtos;
using DotNetFiveRestApi.Entities;
using DotNetFiveRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;



namespace DotNetFiveRestApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemoryItemsRepository _repository;
        public ItemsController(IInMemoryItemsRepository repository)
        {
            _repository =repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items= _repository.GetItems().Select(item=>item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id).AsDto();
            if(item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
