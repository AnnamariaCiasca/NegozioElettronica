using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    class ProductListRepository : IProductDbManager
    {
        static List<Product> products = new List<Product>();

        public static PhoneListRepository phoneRepository = new PhoneListRepository();
        public static PCListRepository pcRepository = new PCListRepository();
        public static TVListRepository tvRepository = new TVListRepository();

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> Fetch()
        {
            if (products.Count() > 0)
            {
                products.Clear();
            }

            products.AddRange(phoneRepository.Fetch());
            products.AddRange(pcRepository.Fetch());
            products.AddRange(tvRepository.Fetch());

            return products;
        }

        public Product GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}