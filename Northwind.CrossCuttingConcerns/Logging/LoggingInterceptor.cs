using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.CrossCuttingConcerns.Logging
{
    public class LoggingInterceptor : SimpleInterceptor
    {
        //Ninject controllerfactorye belirttik.
        //_ninjectKernel.Intercept(p => (true)).With(new LoggingInterceptor());


        protected override void BeforeInvoke(IInvocation invocation)
        {
            //Loglama frameworkünün loglama işlemleri yapılacak

            //invocation.Request.Method.Name  kişi hangi metottan geldi gibi

            base.BeforeInvoke(invocation);
        }




        protected override void AfterInvoke(IInvocation invocation)
        {
            base.AfterInvoke(invocation);
        }

    }
}


//manage nugettan Ninject ve Ninject.Extensions.Interception 'ı  kuruyoruz.