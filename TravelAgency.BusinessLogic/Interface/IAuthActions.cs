using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domains.Models.User; 

namespace TravelAgency.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        object? LoginActionFlow(UserAuthAction auth);
    }
}
