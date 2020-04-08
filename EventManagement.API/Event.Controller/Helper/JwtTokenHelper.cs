using Event.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Event.Controller.Helper
{
    public class JwtTokenHelper
    {
        public static string secret;
        /// <summary>
        /// Time in second
        /// </summary>
        public static int expireTime;
        
        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public UserInfo GenerateUserToken(UserInfo user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("UserName", user.UserName),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }


        public bool IsTokenExpired(string token)
        {
            var jwthandler = new JwtSecurityTokenHandler();
            var jwttoken = jwthandler.ReadToken(token);
            var expDate = jwttoken.ValidTo;
            if (expDate < DateTime.UtcNow)
                return true;
            else
                return false;
        }
        /// <summary>
        ///  Create new object of JwtTokenHelper and used default token expired and secrete key
        /// </summary>
        public JwtTokenHelper()
        {

        }
        /// <summary>
        ///  Create new object of JwtTokenHelper Used Default System Token Expired Time
        /// </summary>
        /// <param name="secretKey">Secrete Key For Signing Credentials</param>
        public JwtTokenHelper(string secretKey)
        {
            secret = secretKey;
        }
        /// <summary>
        ///  Create new object of JwtTokenHelper
        /// </summary>
        /// <param name="secretKey">Secrete Key For Signing Credentials</param>
        /// <param name="expireTime">Token Expire Time In Second</param>
        public JwtTokenHelper(string secretKey, int expireOn)
        {
            secret = secretKey;
            expireTime = expireOn;
        }
        /// <summary>
        /// Create new object of JwtTokenHelper
        /// </summary>
        /// <param name="expireTime">Token Expire Time In Minute</param>
        public JwtTokenHelper(int expireOn)
        {
            expireTime = expireOn;
        }
    }
}
