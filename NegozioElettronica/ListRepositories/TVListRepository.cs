using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    class TVListRepository : ITvDbManager
    {
        public static List<TV> tvs = new List<TV>
        {
            new TV("Sony", "X2065", 10, 65, null),
            new TV("Samsung", "E2575", 8, 75, null),

        };
        public void Delete(TV tv)
        {
            tvs.Remove(tv);
        }

        public List<TV> Fetch()
        {
            return tvs;
        }

        public TV GetById(int? id)
        {
            return tvs.Find(t => t.Id == id);
        }

        public void Insert(TV tv)
        {
            tvs.Add(tv);
        }

        public void Update(TV tv)
        {
            Delete(GetById(tv.Id));
            Insert(tv);
        }
    }
}