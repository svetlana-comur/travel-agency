using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travel_agency.BusinessLogic.Core.Auth
{
    internal class AuthActions
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
