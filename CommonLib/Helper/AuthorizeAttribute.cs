using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Helper
{
    public class AuthorizeAttribute: TypeFilterAttribute
    {
        public AuthorizeAttribute(params string[] roles)
            : base(typeof(AuthorizeActionFilter))

        {
            Arguments = new object[] { };
        }
    }
}
