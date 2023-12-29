using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Common;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.Repository;

namespace TheLearningHub.Infra.Repository
    {
    public class AuthRepository : IAuthRepository
        {

        private readonly IDbContext _dbContext;

        public AuthRepository(IDbContext dbContext)
            {
            _dbContext = dbContext;
            }
        public Login Login(Login login)
            {
            var p = new DynamicParameters();
            p.Add("user_name", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Login>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
            }
        }
    }
