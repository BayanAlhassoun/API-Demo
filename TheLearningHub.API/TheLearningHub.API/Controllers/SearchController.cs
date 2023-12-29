using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.Core.DTO;
using TheLearningHub.Core.Service;

namespace TheLearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
        {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
            {
            _searchService = searchService;
            }

        [HttpPost]
        public async Task<List<Search>> StudentSearch(Search search)
            {
           return await _searchService.StudentSearch(search);
            }
        }
    }
