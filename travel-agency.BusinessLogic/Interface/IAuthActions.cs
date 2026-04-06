using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travel_agency.BusinessLogic.Interface
{
    public class IAuthActions
    {
        object? LoginActionFlow(UserAuthAction auth);
    }
}
