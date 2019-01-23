using ASTCapi.Models;
using ASTCapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASTCapi.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly ShopService _shopService;

        public ShopsController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet()]
        public ActionResult<List<Shop>> Get()
        {
            return _shopService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetShop")]
        public ActionResult<Shop> Get(string id)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        [HttpPost()]
        public ActionResult<Shop> Create(Shop shop)
        {
            _shopService.Create(shop);

            return CreatedAtRoute("GetShop", new { id = shop.Id.ToString() }, shop);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Shop shopIn)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            _shopService.Update(id, shopIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            _shopService.Remove(shop.Id);

            return NoContent();
        }
    }
}