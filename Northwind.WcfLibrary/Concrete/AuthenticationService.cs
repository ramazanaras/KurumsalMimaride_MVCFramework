﻿using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WcfLibrary.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {

        AuthenticationManager _authenticationManager = new AuthenticationManager(new EfAuthenticationDal());

        public Entities.User Authenticate(Entities.User user)
        {
            return _authenticationManager.Authenticate(user);
        }
    }
}



/*
 servisleri yayına çıkarmak için aşağıdakileri WCFIISHost katmanına ekledik
 * 
 *  <!--ekledik-->
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true">
      <serviceActivations>
        <add service="Northwind.WcfLibrary.Concrete.ProductService" relativeAddress="ProductService.svc"/>
        <add service="Northwind.WcfLibrary.Concrete.CategoryService" relativeAddress="CategoryService.svc"/>
        <add service="Northwind.WcfLibrary.Concrete.AuthenticationService" relativeAddress="AuthenticationService.svc"/>
      </serviceActivations>
    </serviceHostingEnvironment>
 
 * 
 * 
 * 
 * 
 * 
 * http://localhost:3427/Product.svc
 * http://localhost:3427/Category.svc
 */