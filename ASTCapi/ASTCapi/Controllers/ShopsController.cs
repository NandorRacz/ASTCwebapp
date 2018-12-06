using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASTCapi.Models;
using ASTCapi.Services;

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

        [HttpGet(Name ="Shop_List")]
        public ActionResult<List<Shop>> Get()
        {
            return _shopService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "Shop_Info")]
        public ActionResult<Shop> Get(string id)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        [HttpPost(Name ="Shop_Create")]
        public ActionResult<Shop> Create(Shop shop)
        {
            _shopService.Create(shop);

            return CreatedAtRoute("GetShop", new { id = shop.Id.ToString() }, shop);
        }

        [HttpPut("{id:length(24)}", Name ="Shop_Update")]
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

        [HttpDelete("{id:length(24)}", Name ="Shop_Delete")]
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