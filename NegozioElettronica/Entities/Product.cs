using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    public class Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public int? Id { get; set; }


        public Product()
        {

        }
        public Product(string brand, string model, int quantity, int? id)
        {
            Brand = brand;
            Model = model;
            Quantity = quantity;
            Id = id;
        }

        public virtual string Print()
        {
            return $"{Brand}, {Model}, {Quantity}";
        }
    }
}