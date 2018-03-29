using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;//Ekledik -->DbContext sınıfı için.
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        


        //Not:UI katmanındaki webconfige ekledik
        /*
         <!--ekledik-->
  <connectionStrings>
    <add name="NorthwindContext" connectionString="Data Source=.;Initial Catalog=Northwind;Integrated Security=True;MultipleActiveResultSets=True"
      providerName="System.Data.SqlClient" />
  </connectionStrings>
         
         */

    }
}






//DAl projesine nugettan entity framework yükle.DbContext sınıfı ,FirstOrdefault() gibi metotlar için gerekli