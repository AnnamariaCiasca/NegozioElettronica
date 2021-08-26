using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    public class TV : Product
    {
        public int Inches { get; set; }

        public TV(string brand, string model, int quantity, int inches, int? id)
            : base(brand, model, quantity, id)
        {
            Inches = inches;
        }

        public TV()
        {
        }


        public override string Print()
        {
            return $"{base.Print()}, {Inches}";
        }
    }
}