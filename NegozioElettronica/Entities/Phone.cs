using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    public class Phone : Product
    {
        public int Memory { get; set; }

        public Phone(string brand, string model, int quantity, int memory, int? id)
            : base(brand, model, quantity, id)
        {
            Memory = memory;
        }

        public Phone()
        {
        }


        public override string Print()
        {
            return $"{base.Print()}, {Memory}";
        }
    }
}