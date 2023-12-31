﻿using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public  class JwtConfigurator
    {
        public static string GetToken(Usuario userInfo, IConfiguration config)
        {
            string secretKey = config["Jwt:SecretKey"]!;
            string issuer = config["Jwt:Issuer"]!;
            string audience = config["Jwt:Audience"]!;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Nombre),
                new Claim("idUsuario", userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int GetIdUsuario(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                var id = claims.Where(x => x.Type == "idUsuario").Select(x => int.Parse(x.Value)).FirstOrDefault();
                return id;
            }
            return 0;
        }
    }
}
