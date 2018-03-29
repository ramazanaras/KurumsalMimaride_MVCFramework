using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Northwind.Dal.Abstract;

namespace Northwind.Bll.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        IAuthenticationDal _authenticationDal;


        public AuthenticationManager(IAuthenticationDal authenticationDal)//dependecy injection
        {
            _authenticationDal = authenticationDal;
        }

        public Entities.User Authenticate(Entities.User user)
        {
        return  _authenticationDal.Authenticate(user);
        }
    }
}
