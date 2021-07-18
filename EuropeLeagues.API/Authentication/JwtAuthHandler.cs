using EuropeLeagues.API.UserModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;

namespace EuropeLeagues.API.Authentication
{
    public class JwtAuthHandler : IJwtAuthHandler
    {
        IConfiguration config;
        public JwtAuthHandler(IConfiguration _config)
        {
            config = _config;
        }
        public User AuthenticateUser(User user)
        {
            User model = null;
            if (user.Username == config["UserDetails:Username"] && user.Password == config["UserDetails:Password"])
            {
                model = new User
                {
                    Username = config["UserDetails:Username"],
                    Password = config["UserDetails:Password"],
                    EmailAddress = config["UserDetails:Email"]
                };
            }
            return model;
        }

        public string GenerateJwtToken(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey:Key"]));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: config["JwtKey:Issuer"],
                audience: config["JwtKey:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credential
                );

            var themainencodedtoken = new JwtSecurityTokenHandler().WriteToken(token);

            return themainencodedtoken;
        }
    }
}
