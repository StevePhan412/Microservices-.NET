using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Play.Common;
using Play.Inventory.Service.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Play.Inventory.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<InventoryItem> itemRepository;

        public ItemsController(IRepository<InventoryItem> repository)
        {
            this.itemRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
        {
            if (userId == Guid.Empty) return BadRequest();
            var items = (await itemRepository.GetAllAsync(item => item.UserId == userId))
                        .Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(GrantItemsDto grantItemsDto)
        {
            var inventoryItem = await itemRepository.GetAsync(
                item => item.UserId == grantItemsDto.UserId && item.CatalogItemId == grantItemsDto.CatalogItemId);
            if(inventoryItem == null) { 
                inventoryItem = new InventoryItem {
                    CatalogItemId = grantItemsDto.CatalogItemId,
                    UserId = grantItemsDto.UserId,
                    Quantity = grantItemsDto.Quantity,
                    AccquiredDate = DateTimeOffset.UtcNow
                };
                await itemRepository.CreateAsync(inventoryItem);
            }
            else
            {
                inventoryItem.Quantity = grantItemsDto.Quantity;
                await itemRepository.UpdateAsync(inventoryItem);
            }
            return Ok();
        }
    }
}
