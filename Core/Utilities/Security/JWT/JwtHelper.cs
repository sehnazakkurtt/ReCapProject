using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{

        public class JwtHelper : ITokenHelper//
        {
            public IConfiguration Configuration { get; }//IConfiguration:apide appsetings dosyasndaki değerleri okumaya yarıyor
            private TokenOptions _tokenOptions;//tokenoptions alanını bu nesneye akratıcaz..okudupum değerleri TokenOptions diye bir nesneye atıcam
            private DateTime _accessTokenExpiration;////AccessToken ne zaman geçersizleşecek ...
            public JwtHelper(IConfiguration configuration)
            {
                Configuration = configuration;
                _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//Configuration dan GetSection ı oku.TokenOptions ı oku ve get et ..dolayısıyla tokenoptiondaki tüm alanları TokenOptions a attım
                                                                                             //appsetings içinde ki tokenoptions bölümünü al ve onu TokenOptions kullarak mapla.Kısacası appsetingsdeki alanları Tokenoptiondaki değerlere ata 
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) //Bu kullanıcı(User) için bir tane token oluşturma... User ve Claimleri ver diyorum buna göre bir token oluşturucam
        {
                _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//bitiş zamanı ..  tokenoptionda dakika olarak tutmuştum burda tarihe çeviriyorum
               var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//_tokenOptions.SecurityKey i kullanarak bir tane güvenlik anahtarı oluşturucak
                var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//_tokenOptions nı kullarak ilgili kullanıcı için ilgili claimleri kullanarak buna atanacak yetkileri içeren bir tane metot  
                var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//jwt üretecek
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();//elimizdeki tokenı bir handler vasıtası ile yazmamız lazım
                var token = jwtSecurityTokenHandler.WriteToken(jwt);//yukarıdaki jwt yi parametre olarak verdim

                return new AccessToken //iki tane bilgisi var
                {
                    Token = token,
                    Expiration = _accessTokenExpiration
                };

            }

            public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, //token üretme; tokenOptions, user, signingCredentials, operationClaims şu alanları vericem
                SigningCredentials signingCredentials, List<OperationClaim> operationClaims)//roller demek
            {
                var jwt = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _accessTokenExpiration,
                    notBefore: DateTime.Now,//
                    claims: SetClaims(user, operationClaims),
                    signingCredentials: signingCredentials
                );
                return jwt;
            }

            private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)//bana elindeki kullanıcı bilgini operationClaims lerini ver
        {
                var claims = new List<Claim>();
                claims.AddNameIdentifier(user.Id.ToString());
                claims.AddEmail(user.Email);//
                claims.AddName($"{user.FirstName} {user.LastName}");
                claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

                return claims;
            }
        }
    }

