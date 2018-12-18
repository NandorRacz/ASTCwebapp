using ASTCapi.Models;
using ASTCapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASTCapi.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("{name}")]
        public ActionResult<List<Product>> Search(string name)
        {
            return _searchService.SearchProducts(name);
        }
    }
}