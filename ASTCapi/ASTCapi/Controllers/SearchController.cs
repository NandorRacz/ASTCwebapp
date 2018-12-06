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
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("{name}", Name = "Search_Result")]
        public ActionResult<List<Product>> Search(string name)
        {
            return _searchService.SearchProducts(name);
        }



    }
}