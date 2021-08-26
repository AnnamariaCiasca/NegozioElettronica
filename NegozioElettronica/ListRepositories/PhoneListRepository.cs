using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{

    public class PhoneListRepository : IPhoneDbManager
    {
        public static List<Phone> phones = new List<Phone>
        {
            new Phone("Samsung", "Galaxy 10", 150, 128, null),
            new Phone("Apple", "iPhone X", 250, 64, null),
            
        };


        public void Delete(Phone phone)
        {
            phones.Remove(phone);
        }

        public List<Phone> Fetch()
        {
            return phones;
        }

        public Phone GetById(int? id)
        {
            return phones.Find(p => p.Id == id);

          
        }

        public void Insert(Phone phone)
        {
            phones.Add(phone);
        }

        public void Update(Phone phone)
        {

            var phoneToDelete = GetById(phone.Id);

            Delete(phoneToDelete);


            Insert(phone);
        }
    }
}