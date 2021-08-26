using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
  public class ProductRepository : IProductDbManager
    {
       

        public static PhoneRepository phoneRepository = new PhoneRepository();
        public static PCRepository pcRepository = new PCRepository();
        public static TVRepository tvRepository = new TVRepository();

        
        public List<Product> Fetch()
        {
            List<Product> products = new List<Product>();

            products.AddRange(phoneRepository.Fetch());
            products.AddRange(pcRepository.Fetch());
            products.AddRange(tvRepository.Fetch());

            return products;
        }

        public void Delete(Product products)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product products)
        {
            throw new NotImplementedException();
        }

        public void Update(Product products)
        {
            throw new NotImplementedException();
        }
    }
}