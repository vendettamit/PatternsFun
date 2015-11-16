using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Product Fetch(Guid id);
    }

    /// <summary>
    /// For demo purpose only.
    /// </summary>
    public class ProductRepository : IRepository
    {
        public Product Fetch(Guid id)
        {
            // fill it in.

            return new Product();
        }
    }

}
