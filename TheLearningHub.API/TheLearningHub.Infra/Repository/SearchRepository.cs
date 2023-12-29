using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Common;
using TheLearningHub.Core.DTO;
using TheLearningHub.Core.Repository;

namespace TheLearningHub.Infra.Repository
    {
    public class SearchRepository : ISearchRepository
        {
        private readonly IDbContext _dBContext;

        public SearchRepository(IDbContext dbContext)
            {
            _dBContext = dbContext;
            }
        public async Task<List<Search>> StudentSearch(Search search)
            {
            var p = new DynamicParameters();
            p.Add("cName", search.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fName", search.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("startDate", search.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("endDate", search.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = await _dBContext.Connection.QueryAsync<Search>("Search_Package.StudnetSearch", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
            }
        }
    }
