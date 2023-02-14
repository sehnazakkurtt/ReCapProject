using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
  
        public class AccessToken//sisteme giriş yaparken erişim anahtarı
        {
            public string Token { get; set; }//jeton jwt değerinin ta kendisi
            public DateTime Expiration { get; set; }//bitiş süresi
            // Expiration Bitiş Zamanını verdiğimiz değer
        }
    }

