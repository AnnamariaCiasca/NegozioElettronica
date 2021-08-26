using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    class PCListRepository : IPcDbManager
    {
        public static List<PC> pcs = new List<PC>
        {
            new PC("Lenovo", "IdeaPad", 100, OperativeSystem.WINDOWS, true, null),
            new PC("Apple", "MacBook Pro", 125, OperativeSystem.MAC, false, null),
          
        };
        public void Delete(PC pc)
        {
            pcs.Remove(pc);
        }

        public List<PC> Fetch()
        {
            return pcs;
        }

        public PC GetById(int? id)
        {
            return pcs.Find(c => c.Id == id);
        }

        public void Insert(PC pc)
        {
            pcs.Add(pc);
        }

        public void Update(PC pc)
        {
            Delete(GetById(pc.Id));
            Insert(pc);
        }
    }
}