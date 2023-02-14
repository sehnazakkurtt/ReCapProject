using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success) //this clasın kendisi demek yani this = result
        {
            Message = message;  //aşağıda ki Message yi message olarak set et
          
        }

        public Result(bool success) 
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
