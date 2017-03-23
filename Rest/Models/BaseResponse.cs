using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models
{
    public class BaseResponse
    {
        public int code { get; set; }
        public Error error { get; set; }

        public BaseResponse()
        {

        }

        public BaseResponse(int code, string errorDescription)
        {
            this.code = code;
            this.error = new Error
            {
                Description = errorDescription
            };
        }
    }

    public class Error
    {
        public string Description { get; set; }
    }
}