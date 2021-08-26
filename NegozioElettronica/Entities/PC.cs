using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    public class PC : Product
    {
        public OperativeSystem OS { get; set; }
        public bool IsTouch {get; set; }

        public PC(string brand, string model, int quantity, OperativeSystem os, bool isTouch, int? id)
            : base(brand, model, quantity, id)
        {
            OS = os;
            IsTouch = isTouch;
        }

        public PC()
        {
        }


        public override string Print()
        {
            return $"{base.Print()}, {OS}, {IsTouch}";
        }
    }

    public enum OperativeSystem
    {
            WINDOWS, //0
            MAC,     //1
            LINUX    //2
    }
}