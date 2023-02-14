using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public  class HashingHelper//hash oluşturmaya ve onu doğrulamaya yarar
    {

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)//biz bir tane password değer vericez ve dışarıya şu iki değeri(passwordhash,passwordsalt) çıkarıcak şekilde tasarlayacaz//verilen bir passwordun hashing i oluşturacak aynı zamanda saltingini de oluşturacak
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//Hash oluştururken hangi algoritmayı kullanacağımızı söylüyoruz//hmac:bizim Cryptography sınıfında kullandığımız clasa denk geliyor 
            {
                //Kısacası bu kod(9-17 satır) verilen password değerine göre bir tane hash ve salt değerini oluşturmaya yarıyor
                passwordSalt = hmac.Key;//ilgili kullanılan algoritmanın o an oluşturdupu key değeridir dolayısıyla herkes için farklıdır 
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//bir stringin byte karşılı...gönderilen passwordun byte değeri
            }
        }

        //Verify:doğrula ,,, VerifyPassworHash:passwordhash i doğrula
        //sisteme sonradan sonradan girmek isteyen kişinin verdiği passwordun bizim veri kaytnağımızdaki hash ve salt ile eşleşip eşleşmediğini verdiğimiz yer
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)//hesaplanan hashin bütün değerleini dolaş
                {
                    if (computedHash[i] != passwordHash[i])//compuıted hashin i değeri ile veri tabanından gönderilen hanshin i değeri birbiri ile eşleşmiyorsa 
                    {
                        return false;
                    }
                }
                return true;
            }


        }
    }
}
