using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.DTO;

namespace TheLearningHub.Core.Repository
    {
    public interface ISearchRepository
        {
        Task<List<Search>> StudentSearch(Search search);
        }
    }
