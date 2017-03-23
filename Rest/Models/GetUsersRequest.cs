using System.Collections.Generic;

namespace Rest.Models
{
    public class GetUsersRequest
    {
        public List<string> phoneNumbers { get; set; }
    }
}