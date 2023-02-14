using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   //kayıt olmak için gerekli olan operasyonlar
        public interface IAuthService //bu servis sayesinde register ve login olucam
        {
            IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);//kullanıcının sisteme kayıt olması demek
            IDataResult<User> Login(UserForLoginDto userForLoginDto);//login olmak : Vt kullanıcının varlığının kontrol edilmesi demek
            IResult UserExists(string email);//kullanıcı var ı
            IDataResult<AccessToken> CreateAccessToken(User user);
        }
    }

