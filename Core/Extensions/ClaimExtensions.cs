using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimExtensions//var olan bir clasa kendi metotlarını eklemek 
    {
            public static void AddEmail(this ICollection<Claim> claims, string email)//ICollection<Claim> şunu extend ediyorum demek yani genişletiyorum..string email buda parametre
        {
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));//yeni bir claim ekleme yukarıdaki email i ekle
            }

            public static void AddName(this ICollection<Claim> claims, string name)
            {
                claims.Add(new Claim(ClaimTypes.Name, name));
            }

            public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
            }

            public static void AddRoles(this ICollection<Claim> claims, string[] roles)//bana gönderilen rolleri listeye çevir her biriini tek tek dolaş ve her rolü git claime ekle
        {
                roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            }
        }

}

