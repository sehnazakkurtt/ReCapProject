using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için . İçinde sade işlem başarılı mı / değil mi bide mesaj dönecek
    public interface IResult
    {
        bool Success { get; } //yapılan işlem true/false
        string Message { get; }//işlem mesajı
    }
}
