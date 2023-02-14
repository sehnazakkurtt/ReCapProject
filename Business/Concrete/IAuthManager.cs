using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
 
        public class AuthManager : IAuthService
        {
            private IUserService _userService;//kullanıcıyı kontrol etmek için 
            private ITokenHelper _tokenHelper;//kullanıcı login olunca token üreticez onun için

            public AuthManager(IUserService userService, ITokenHelper tokenHelper)
            {
                _userService = userService;
                _tokenHelper = tokenHelper;
            }

            public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)//
            {
                byte[] passwordHash, passwordSalt;//
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);//gönderşlen şifrenin hash ve saltı bize dönmesini bekliyoruz
                var user = new User//bir user oluşturdum 
                {
                    //kayıt etmek istediğimiz kullanıcının bilgileri
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }

            public IDataResult<User> Login(UserForLoginDto userForLoginDto)
            {
                var userToCheck = _userService.GetByMail(userForLoginDto.Email);//maili kontrol etme, mevcut kullanıcıyı getirme //userToCheck: kontrol edilecek kullanıcı ...email i çekiyorum burda
            if (userToCheck == null)//vt bu emeile sahip  herhangi mail gelmediyse
                {
                    return new ErrorDataResult<User>(Messages.UserNotFound);//
                }
            //1. if kullanıcı var demek eğer orayı geçerse 2. if şifresi doğru demek her iki if te doğrusuysa en alttaki return u döndürypruz mevcut 
                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))//userForLoginDto daki Password bilgisi.....vb bu bilgiler eşleşmiyorsa
            {
                    return new ErrorDataResult<User>(Messages.PasswordError);// şu mesajı döndür
                }

                return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);//eşleşiyorsa bunu döndür  mevcut kkulaıcıyı ekleyip mesajı veriyoruz 
        }

            public IResult UserExists(string email) //kullanıcı sistemde var mı yok mu
            {
                if (_userService.GetByMail(email) != null) //böyle bir kullanıcı varsa 
                {
                    return new ErrorResult(Messages.UserAlreadyExists); //bu kullanıcı zaten mevcut
                }
                return new SuccessResult();//
            }

            public IDataResult<AccessToken> CreateAccessToken(User user)//kullanıcı kayıt olduktan sonra biz bu kullanıcya bir token vericez ve bu token vasıtası ile artık işlemlerini gerçekleştirecek
            {
            //claim : kişinin rolleri
                var claims = _userService.GetClaims(user);
                var accessToken = _tokenHelper.CreateToken(user, claims);
                return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
            }
        }
    }

