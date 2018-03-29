using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.CrossCuttingConcerns.Validation.EnterpriseLibrary
{
    public class ValidationInterceptor:SimpleInterceptor
    {
       




        //protected override void BeforeInvoke(IInvocation invocation)
        //{
        //    //Burada method attribute okunacak
        //    //Bu olay reflection ile yapılır


        //    //if (invocation.Request.Target.GetType().Name.Contains("Manager"))
        //    //{
        //    //    //var attributes=invocation.Request.Method.GetCustomAttributes(typeof());
        //    //}


        //    if (invocation.Request.Method.Name=="Add" || invocation.Request.Method.Name=="Update")
        //    {
        //        foreach (var parameter in invocation.Request.Arguments)
        //        {
        //            var results=ValidationFactory.crea
        //        }
        //    }






        //}


    }
}
