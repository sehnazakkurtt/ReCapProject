using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //credentials: bir sisteme girmek için elimşizde olanlar
        public class SigningCredentialsHelper //securitykey ve algoritmamızı belirttiğimiz nesne
        {
        //Jwt sistemini yönetecek anahtar ve şifreleme algritması veriyor
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)//hangi anahtarı kullanacak
            {
                return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);//anahtarım securitykey den algoritmam da şu HmacSha512Signature
        }

        }
    }

