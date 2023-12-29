using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Data;

namespace TheLearningHub.Core.Service
    {
    public interface IAuthService
        {
        string Login(Login login);
        }
    }
