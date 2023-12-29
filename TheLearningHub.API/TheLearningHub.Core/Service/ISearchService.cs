using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.DTO;

namespace TheLearningHub.Core.Service
    {
    public interface ISearchService
        {
        Task<List<Search>> StudentSearch(Search search);

        }
    }
