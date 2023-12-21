using Azure;
using Azure.Core;
using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CommonHelpers
{
    public class AuthHelper
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        private readonly IConfiguration _configuration;

        public AuthHelper(DBContext dbContext, CommonRepo commonRepo, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
            _configuration = configuration;
        }

        public async Task<CommonResponse> Login(LoginReqDTO loginReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                LoginResDTO loginResDTO = new LoginResDTO();
                TokenMst tokenMst = new TokenMst();

                var userDetail = _dbContext.UserMsts.FirstOrDefault(x => x.Email == loginReqDTO.Email.Trim() && loginReqDTO.Password != null && x.Password == loginReqDTO.Password.Trim() && x.IsDelete == false);
                if (userDetail != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                    {
                          new Claim(ClaimTypes.Name,loginReqDTO.Email),
                          new Claim("Password",loginReqDTO.Password)
                    };
                    var token = new JwtSecurityToken(_configuration["JsonWebTokenKeys:ValidIssuer"],
                        _configuration["JsonWebTokenKeys:ValidAudience"],
                        claims,

                        expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"])),
                        signingCredentials: credentials);

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    var randomNumber = new byte[32];
                    string refreshtokenstring = null;

                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(randomNumber);
                        refreshtokenstring = Convert.ToBase64String(randomNumber);
                    }

                    var tokenDetail = await _commonRepo.TokenMstList().FirstOrDefaultAsync(x => x.EmployeeId == userDetail.EmployeeId);

                    if (tokenDetail != null)
                    {
                        tokenDetail.Token = tokenString;
                        tokenDetail.TokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"]));
                        tokenDetail.RefreshToken = refreshtokenstring;
                        tokenDetail.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:RefreshTokenexpiryDays"]));
                        tokenDetail.UpdatedDate = DateTime.Now;
                        _dbContext.Entry(tokenDetail).State = EntityState.Modified;
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        tokenMst.Token = tokenString;
                        tokenMst.TokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"]));
                        tokenMst.RefreshToken = refreshtokenstring;
                        tokenMst.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:RefreshTokenexpiryDays"]));
                        tokenMst.CreatedDate = DateTime.Now;
                        tokenMst.EmployeeId = userDetail.EmployeeId;
                        _dbContext.TokenMsts.Add(tokenMst);
                        _dbContext.SaveChanges();
                    }
                    loginResDTO.Token = tokenString;
                    loginResDTO.RefreshToken = refreshtokenstring;
                    loginResDTO.TokenExpiryTime = tokenMst.TokenExpiryTime;
                    loginResDTO.Email = userDetail.Email;

                    response.Data = loginResDTO;
                    response.Message = "login successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;

                }
                else
                {
                    response.Message = "email and password is not correct";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> CreateNewToken(TokenReqDTO tokenReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var tokenDetail = _commonRepo.TokenMstList().FirstOrDefault(x => x.Token == tokenReqDTO.Token && x.RefreshToken == tokenReqDTO.RefreshToken);

                var userDetail = _commonRepo.UserMstList().FirstOrDefault(x => x.EmployeeId == tokenDetail.EmployeeId);
                TokenResDTO tokenResDTO = new TokenResDTO();

                if (userDetail != null)
                {
                    if (tokenDetail != null)
                    {
                        string Token = tokenReqDTO.Token;
                        string refreshToken = tokenReqDTO.RefreshToken;
                        var tokenHandler = new JwtSecurityTokenHandler();
                        SecurityToken securityToken;
                        var principal = tokenHandler.ValidateToken(Token, new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]))
                        }, out securityToken);

                        var jwtSecurityToken = securityToken as JwtSecurityToken;

                        var username = principal.Identity.Name;

                        if (username == userDetail.Email)
                        {
                            //if refresh token expired
                            if (tokenDetail.RefreshToken != refreshToken || tokenDetail.RefreshTokenExpiryTime <= DateTime.Now)
                            {
                                response.Message = "refresh token is expired";
                                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                                return response;
                            }
                            //if token is not expired
                            else if (tokenDetail.Token != Token || tokenDetail.TokenExpiryTime >= DateTime.Now)
                            {
                                response.Message = " token is not expired";
                                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                                return response;
                            }
                            else
                            {
                                //if token expired but refreh token not expired
                                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]));
                                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                                var claims = new[]
                                {
                               new Claim(ClaimTypes.Name,userDetail.Email),
                               new Claim("Password",userDetail.Password)
                            };
                                var token = new JwtSecurityToken(_configuration["JsonWebTokenKeys:ValidIssuer"],
                               _configuration["JsonWebTokenKeys:ValidAudience"],
                               claims,
                               expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"])),
                               signingCredentials: credentials);

                                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                                var randomNumber = new byte[32];
                                string refreshtokenstring = null;

                                using (var rng = RandomNumberGenerator.Create())
                                {
                                    rng.GetBytes(randomNumber);
                                    refreshtokenstring = Convert.ToBase64String(randomNumber);
                                }
                                tokenDetail.Token = tokenString;
                                tokenDetail.TokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"]));
                                tokenDetail.RefreshToken = refreshtokenstring;
                                tokenDetail.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:RefreshTokenexpiryDays"]));
                                tokenDetail.UpdatedDate = DateTime.Now;
                                _dbContext.Entry(tokenDetail).State = EntityState.Modified;
                                _dbContext.SaveChanges();

                                tokenResDTO.Token = tokenString;
                                tokenResDTO.RefreshToken = refreshtokenstring;

                                response.Data = tokenResDTO;
                                response.Message = "new token generated successfully";
                                response.Status = true;
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                            }
                        }
                    }
                    else
                    {
                        response.Message = "token is not correct";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Message = "user is not corrct";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
