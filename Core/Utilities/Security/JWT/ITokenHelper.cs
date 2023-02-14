using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //token üretecek mekanizma
        public interface ITokenHelper //ilgili kullanıcı(burda ki kullanıcı User) için ilgili kullanıcının claimlerini içerecek bir token üretecek
    {
            AccessToken CreateToken(User user, List<OperationClaim> operationClaims);//user için oluştur ..operationClaims içerisinden gelecek  yetkiler girecek 
        //kullanıcı burdan kullanıcı adını ve paralosanı girdi eğer dopru ise createToken çalışacak ilgili
        //kullanıcı için veritabanına gidecek vt dan bu kullanıcın claimlerini
        //bulacak orda bir tane jwt üretecek ve bilgileri verecek
    }
}

