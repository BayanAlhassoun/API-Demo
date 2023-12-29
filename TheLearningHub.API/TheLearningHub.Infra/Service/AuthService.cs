using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.Repository;
using TheLearningHub.Core.Service;

namespace TheLearningHub.Infra.Service
    {
    public class AuthService: IAuthService
        {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
            {
            _authRepository = authRepository;
            }

        public string Login(Login login)
            {
           var result = _authRepository.Login(login);
            if (result == null)
                {
                return null;
                }
            else
                {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345"));
                var signCredentials = new SigningCredentials(secretKey , SecurityAlgorithms.HmacSha256);

                var claimes = new List<Claim>
                    {
                    new Claim("UserName" , result.Username),
                    new Claim("RoleId" , result.Roleid.ToString())
                       
                    };

                var tokenOptions = new JwtSecurityToken(
                    claims: claimes,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signCredentials
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;
                }
            }
        }
    }
