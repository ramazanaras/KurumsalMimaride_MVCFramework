using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationService _authenticationManager;

        public AccountController(IAuthenticationService authenticationManager) //depnedenct injection
        {
            _authenticationManager = authenticationManager;
        }



        public ActionResult Login()
        {
            return View(new User());
        }


        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            User validatedUser = _authenticationManager.Authenticate(user);

            if (validatedUser==null)
            {
                //model yanlış gelmişse
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifresi hatalı");  //view tarafında     @Html.ValidationSummary()   gösteririz.
            }



            if (ModelState.IsValid) //model doğru gelmişse
            {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return Redirect(returnUrl);
            }
           



            return View(user);





        }


    }
}


/*
 Webconfige ekledik
 * 
 * //giriş yapılmamışsa yönlenecek
 *   <authentication mode="Forms" >
      <forms loginUrl="~/Account/Login" timeout="2800" />
    </authentication>
 
 
 */
