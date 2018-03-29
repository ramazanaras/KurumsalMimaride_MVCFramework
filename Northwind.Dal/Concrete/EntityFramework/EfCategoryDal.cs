using Northwind.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfCategoryDal:ICategoryDal
    {

        public NorthwindContext _context = new NorthwindContext();
        public List<Entities.Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
