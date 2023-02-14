using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public class SecurityKeyHelper//şifreleme olan sistemlerde bizim herşeyi bir byte array formatında vermemiz gerekiyor ..//string olarak verilen passwordleri byte array haline getiriyır
    {
            // SecurityKey :  Microsoft.IdentityModel.Tokens; dan gelmektedir
            public static SecurityKey CreateSecurityKey(string securityKey)//bana bir tane securitykey ver 
            {
                return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //bende securitykey karşılığını vereyim
            }
        }
    }

