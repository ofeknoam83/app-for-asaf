using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest.Models
{
    public class GetUsersReponse: BaseResponse
    {
        public List<int> UserIds { get; set; }
    }
}