using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.DTO;
using TheLearningHub.Core.Repository;
using TheLearningHub.Core.Service;

namespace TheLearningHub.Infra.Service
    {
    public class SearchService : ISearchService
        {

        private readonly ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
            {
            _searchRepository = searchRepository;
            }
        public async Task<List<Search>> StudentSearch(Search search)
            {
           return await _searchRepository.StudentSearch(search);
            }
        }
    }
