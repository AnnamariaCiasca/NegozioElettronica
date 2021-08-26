using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
  public class DealerManager
    {
        public static PhoneRepository phoneRepository = new PhoneRepository();
        public static PCRepository pcRepository = new PCRepository();
        public static TVRepository tvRepository = new TVRepository();
        public static ProductRepository productRepository = new ProductRepository();
        internal static void ShowProducts()
        {
            List<Product> products = productRepository.Fetch();
            foreach (var product in products)
            {
                Console.WriteLine(product.Print());
            }
        }

        internal static void ShowPhones()
        {
            List<Phone> phones = phoneRepository.Fetch();
            foreach (var phone in phones)
            {
                Console.WriteLine(phone.Print());
            }
        }

        internal static void ShowPC()
        {
            List<PC> pcs = pcRepository.Fetch();
            foreach (var pc in pcs)
            {
                Console.WriteLine(pc.Print());
            }
        }

        internal static void ShowTV()
        {
            List<TV> tvs = tvRepository.Fetch();
            foreach (var tv in tvs)
            {
                Console.WriteLine(tv.Print());
            }
        }

        internal static void InsertProducts()
        {
            int prodottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Quale prodotto vuoi inserire?");
                Console.WriteLine("Premi 1 per inserire un nuovo PC");
                Console.WriteLine("Premi 2 per inserire un nuovo cellulare");
                Console.WriteLine("Premi 3 per inserire una nuova TV");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    PC pc = ChiediDatiPC();
                    pcRepository.Insert(pc);
                    break;
                case 2:
                    Phone phone = ChiediDatiPhone();
                    phoneRepository.Insert(phone);
                    break;
                case 3:
                    TV tv = ChiediDatiTV();
                    tvRepository.Insert(tv);
                    break;
            }

        }

        internal static void FiltraMemoria()
        {
            int memoria;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci la memoria in GB");
                isInt = int.TryParse(Console.ReadLine(), out memoria);
            } while (!isInt);

            List<Phone> phones = phoneRepository.Filtra(memoria);
           
       
            foreach (var phone in phones)
            {
                Console.WriteLine(phone.Print());
            }

        }
    

        private static TV ChiediDatiTV()
        {
            Product product = ChiediDatiProdotto();
            TV tv = new TV();
            tv.Brand = product.Brand;
            tv.Model = product.Model;
            tv.Quantity = product.Quantity;

            int pollici;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci il numero di pollici");
                isInt = int.TryParse(Console.ReadLine(), out pollici);
            } while (!isInt);
            tv.Inches = pollici;

            return tv;
        }
        private static PC ChiediDatiPC()
        {
            Product product = ChiediDatiProdotto();
            PC pc = new PC();
            pc.Brand = product.Brand;
            pc.Model = product.Model;
            pc.Quantity = product.Quantity;

            int sistemaOp;
            bool isInt;
            do
            {
                Console.WriteLine("Scegli un Sistema Operativo");
                foreach (var os in Enum.GetValues(typeof(OperativeSystem)))
                {
                    Console.WriteLine($"Premi {(int)os} per {(OperativeSystem)os}");
                }
                isInt = int.TryParse(Console.ReadLine(), out sistemaOp);

            } while (!isInt || sistemaOp <= 0 || sistemaOp >= 4);

            pc.OS = (OperativeSystem)(sistemaOp);

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Il PC è touchscreen? Scrivi si o no");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);

            if(risposta == "si")
            {
                pc.IsTouch = true;
            }
            else if(risposta == "no")
            {
                pc.IsTouch = false;
            }

            return pc;
        }

        private static Phone ChiediDatiPhone()
        {
            Product product = ChiediDatiProdotto();
            Phone phone = new Phone();
            phone.Brand = product.Brand;
            phone.Model = product.Model;
            phone.Quantity = product.Quantity;

            bool isInt;
            int memoria;
            do
            {
                Console.WriteLine("Inserisci la memoria del cellulare in GB");

                isInt = int.TryParse(Console.ReadLine(), out memoria);

            } while (!isInt);

           phone.Memory = memoria;

            return phone;
        }

        private static Product ChiediDatiProdotto()
        {
            Product product = new Product();

            Console.WriteLine("Inserisci la marca");
            product.Brand = Console.ReadLine();

            Console.WriteLine("Inserisci il modello");
            product.Model = Console.ReadLine();

            bool isInt;
            int quantita;
            do
            {
                Console.WriteLine("Inserisci la quantità in magazzino");

                isInt = int.TryParse(Console.ReadLine(), out quantita);

            } while (!isInt);

            product.Quantity = quantita;

            return product;
        }


        internal static void UpdateProducts()
        {
            int prodottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Quale prodotto vuoi modificare?");
                Console.WriteLine("Premi 1 per modificare un PC");
                Console.WriteLine("Premi 2 per modificare un cellulare");
                Console.WriteLine("Premi 3 per modificare una TV");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    PC pcScelto = ScegliPCModifica();

                    if (pcScelto.Id == null)
                    {
                        pcRepository.Delete(pcScelto);
                    }

                    PC pc = ModificaPC(pcScelto);
                    pcRepository.Update(pc);
                  
                    break;

                case 2:
                    Phone phoneScelto = ScegliPhoneModifica();

                    if (phoneScelto.Id == null)
                    {
                        phoneRepository.Delete(phoneScelto);
                    }

                    Phone phone = ModificaPhone(phoneScelto);
                    phoneRepository.Update(phone);
                    break;
                   
                case 3:
                    TV tvScelta = ScegliTVModifica();

                    if (tvScelta.Id == null)
                    {
                       tvRepository.Delete(tvScelta);
                    }

                    TV tv = ModificaTV(tvScelta);
                    tvRepository.Update(tv);
                    break;
            }
        }

        private static PC ModificaPC(PC pc)
        {
            bool check = true;
            int choice;
          
            do
            {
                Console.WriteLine("Quale dato vuoi modificare? \n1)Brand \n2)Modello \n3)Quantità \n4)Sistema Operativo \n5)Touchscreen \n0)Per uscire");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserisci il Brand:");
                        pc.Brand = Console.ReadLine();
                    
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il Modello:");
                        pc.Model = Console.ReadLine();
                        break;
                    case 3:
                        bool isInt;
                        int quantita;
                        do
                        {
                            Console.WriteLine("Inserisci la quantità in magazzino: ");

                            isInt = int.TryParse(Console.ReadLine(), out quantita);

                        } while (!isInt);
                        pc.Quantity = quantita;
                        break;
                    
                    case 4:
                        Console.WriteLine("Inserisci il Sistema Operativo: 0)Windows, 1)Mac, 2)Linux:");
                        int so = 0;
                        while (!int.TryParse(Console.ReadLine(), out so) || so < 0 || so > 2)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        pc.OS = (OperativeSystem)so;
                        break;
                   
                    case 5:
                        Console.WriteLine("Inserisci 'false' se non è touchscreen, 'true' se lo è:");
                        bool t = true;
                        while (!bool.TryParse(Console.ReadLine(), out t))
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        pc.IsTouch = t;
                        break;
                    case 0:
                        Console.WriteLine("Modifica conclusa");
                        check = false;
                        break;
                }
            } while (check);
            return pc;

        }

        private static Phone ModificaPhone(Phone phone)
        {
            bool check = true;
            int choice;

            do
            {
                Console.WriteLine("Quale dato vuoi modificare? \n1)Brand \n2)Modello \n3)Quantità \n4)Memoria \n0)Per uscire");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserisci il Brand:");
                        phone.Brand = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il Modello:");
                        phone.Model = Console.ReadLine();
                        break;
                    case 3:
                        bool isInt;
                        int quantita;
                        do
                        {
                            Console.WriteLine("Inserisci la quantità in magazzino: ");

                            isInt = int.TryParse(Console.ReadLine(), out quantita);

                        } while (!isInt);
                        phone.Quantity = quantita;
                        break;

                    case 4:
                       
                        int memoria;
                        do
                        {
                            Console.WriteLine("Inserisci la memoria in GB: ");

                            isInt = int.TryParse(Console.ReadLine(), out memoria);

                        } while (!isInt);
                        phone.Memory = memoria;
                        break;


                    case 0:
                        Console.WriteLine("Modifica conclusa");
                        check = false;
                        break;
                }
            } while (check);
            return phone;

        }

        private static TV ModificaTV(TV tv)
        {
            bool check = true;
            int choice;

            do
            {
                Console.WriteLine("Quale dato vuoi modificare? \n1)Brand \n2)Modello \n3)Quantità \n4)Pollici \n0)Per non modificare");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserisci il Brand:");
                        tv.Brand = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il Modello:");
                        tv.Model = Console.ReadLine();
                        break;
                    case 3:
                        bool isInt;
                        int quantita;
                        do
                        {
                            Console.WriteLine("Inserisci la quantità in magazzino: ");

                            isInt = int.TryParse(Console.ReadLine(), out quantita);

                        } while (!isInt);
                        tv.Quantity = quantita;
                        break;

                    case 4:

                        int pollici;
                        do
                        {
                            Console.WriteLine("Inserisci i pollici della TV: ");

                            isInt = int.TryParse(Console.ReadLine(), out pollici);

                        } while (!isInt);
                        tv.Inches = pollici;
                        break;


                    case 0:
                        Console.WriteLine("Modifica conclusa");
                        check = false;
                        break;
                }
            } while (check);
            return tv;

        }

        private static bool InsertTouch()
        {
            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Il PC è touchscreen? Scrivi si o no");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);

            return risposta == "si" ? true : false;
        }

        private static OperativeSystem InsertOS()
        {
            bool isInt = false;
            int os = 0;
            do
            {
                Console.WriteLine("Inserisci il Sistema Operativo");
                foreach (var genere in Enum.GetValues(typeof(OperativeSystem)))
                {
                    Console.WriteLine($"Premi {(int)os} per {(OperativeSystem)os}");
                }

                isInt = int.TryParse(Console.ReadLine(), out os);
            } while (!isInt || os < 0 || os > 2);
            return (OperativeSystem)os;
        }

        private static int InsertQuantity()
        {
            int quantita = 0;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci la quantità");
                isInt = int.TryParse(Console.ReadLine(), out quantita);
            } while (!isInt);
            return quantita;
        }

        private static string InsertModel()
        {
            string model = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il modello");
                model = Console.ReadLine();

            } while (String.IsNullOrEmpty(model));
            return model;
        }

        private static string InsertBrand()
        {
            string brand = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il Brand");
                brand = Console.ReadLine();

            } while (String.IsNullOrEmpty(brand));
            return brand;
        }

        internal static void DeleteProducts()
        {
            int tipoProdotto;
            bool isInt;

            do
            {
                Console.WriteLine("Quale prodotto vuoi eliminare?");
                Console.WriteLine("Premi 1 per eliminare un PC");
                Console.WriteLine("Premi 2 per eliminare un cellulare");
                Console.WriteLine("Premi 3 per eliminare una TV");

                isInt = int.TryParse(Console.ReadLine(), out tipoProdotto);

            } while (!isInt || tipoProdotto <= 0 || tipoProdotto >= 4);

            switch (tipoProdotto)
            {
                case 1:
                    PC pc = ScegliPC();
                    pcRepository.Delete(pc);
                    break;
                case 2:
                    Phone phone = ScegliPhone();
                    phoneRepository.Delete(phone);
                    break;
                case 3:
                    TV tv = ScegliTV();
                    tvRepository.Delete(tv);
                    break;
            }
        }

        private static TV ScegliTV()
        {
            List<TV> tvs = tvRepository.Fetch();

            int i = 1;
            foreach (var tv in tvs)
            {
                Console.WriteLine($"Premi {i} per eliminare {tv.Print()}");
                i++;
            }

            bool isInt;
            int prodottoScelto;
            do
            {
                Console.WriteLine("Quale prodotto vuoi eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > tvs.Count);

            return tvs.ElementAt(prodottoScelto - 1);
        }

        private static Phone ScegliPhone()
        {
            List<Phone> phones = phoneRepository.Fetch();

            int i = 1;
            foreach (var phone in phones)
            {
                Console.WriteLine($"Premi {i} per scegliere {phone.Print()}");
                i++;
            }

            bool isInt;
            int prodottoScelto;
            do
            {
                Console.WriteLine("Quale prodotto vuoi eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > phones.Count);

            return phones.ElementAt(prodottoScelto - 1);
        }

        private static PC ScegliPC()
        {
            List<PC> pcs = pcRepository.Fetch();

            int i = 1;
            foreach (var pc in pcs)
            {
                Console.WriteLine($"Premi {i} per eliminare {pc.Print()}");
                i++;
            }

            bool isInt;
            int prodottoScelto;
            do
            {
                Console.WriteLine("Quale prodotto vuoi eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > pcs.Count);

            return pcs.ElementAt(prodottoScelto - 1);
        }

        private static PC ScegliPCModifica()
        {
            List<PC> pcs = pcRepository.Fetch();

            int i = 1;
            foreach (var pc in pcs)
            {
                Console.WriteLine($"Premi {i} per modificare {pc.Print()}");
                i++;
            }

            bool isInt;
            int prodottoScelto;
            do
            {
                Console.WriteLine("Quale PC vuoi modificare?");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > pcs.Count);

            return pcs.ElementAt(prodottoScelto - 1);
        }

        private static Phone ScegliPhoneModifica()
        {
            List<Phone> phones = phoneRepository.Fetch();

            int i = 1;
            foreach (var phone in phones)
            {
                Console.WriteLine($"Premi {i} per modificare {phone.Print()}");
                i++;
            }

            bool isInt;
            int prodottoScelto;
            do
            {
                Console.WriteLine("Quale prodotto vuoi modificare?");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > phones.Count);

            return phones.ElementAt(prodottoScelto - 1);
        }

        private static TV ScegliTVModifica()
        {
            List<TV> tvs = tvRepository.Fetch();

            int i = 1;
            foreach (var tv in tvs)
            {
                Console.WriteLine($"Premi {i} per modificare {tv.Print()}");
                i++;
            }

            bool isInt;
            int prodottoScelto;
            do
            {
                Console.WriteLine("Quale prodotto vuoi modificare?");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > tvs.Count);

            return tvs.ElementAt(prodottoScelto - 1);
        }
    }
}
