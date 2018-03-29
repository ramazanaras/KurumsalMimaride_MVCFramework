using Northwind.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfAuthenticationDal:IAuthenticationDal
    {

        public Entities.User Authenticate(Entities.User user)
        {

            //Veritabanından alınacak
            if (user.UserName=="ramazan" && user.Password=="1")
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
