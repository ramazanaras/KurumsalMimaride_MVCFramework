using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Dal.Abstract
{
    public interface IAuthenticationDal
    {

        Entities.User Authenticate(Entities.User user);
    }
}
