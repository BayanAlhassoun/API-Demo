using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Data;

namespace TheLearningHub.Core.Repository
    {
    public interface IAuthRepository
        {

        Login Login(Login login);
        }
    }
