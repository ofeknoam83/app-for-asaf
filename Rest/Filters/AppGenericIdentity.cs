using Rest.Enity;
using System.Security;
using System.Security.Principal;

namespace Rest.Filters
{
    public class AppGenericIdentity : GenericIdentity
    {
        public User User { get; set; }

        public AppGenericIdentity(string name): base(name)
        {

        }

        [SecuritySafeCritical]
        public AppGenericIdentity(string name, string type, User user) : base(name, type)
        {
            User = user;
        }

        [SecuritySafeCritical]
        public AppGenericIdentity(string name, string type): base(name, type)
        {

        }

        protected AppGenericIdentity(GenericIdentity identity) : base(identity)
        {

        }
    }
}