using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;



using System.ServiceModel;//Dll'ide ekledik--> ServiceContract attribute için .WCF için.
namespace Northwind.Interfaces
{
    [ServiceContract]//Servis olarak dışarıya açılması için
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();

        [OperationContract]
        Product Get(int productId);

        [OperationContract]
        void Add(Product product);

        [OperationContract]
        void Delete(int productId);

        [OperationContract]
        void Update(Product product);

    }
}
