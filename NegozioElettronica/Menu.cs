using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Premi 1 per vedere tutti i prodotti");        //ok
                Console.WriteLine("Premi 2 per vedere tutti i cellulari");       //ok
                Console.WriteLine("Premi 3 per vedere tutti i PC");              //ok
                Console.WriteLine("Premi 4 per vedere tutte le TV");             //ok
                Console.WriteLine("Premi 5 per inserire un nuovo prodotto");     //ok
                Console.WriteLine("Premi 6 per modificare un prodotto");         //ok
                Console.WriteLine("Premi 7 per eliminare un prodotto");          //ok
                Console.WriteLine("Premi 8 per filtrare i cellulari per memoria superiore a quella scelta");  //ok
                Console.WriteLine("Premi 9 per filtrare i pc per sistema operativo scelto");
                Console.WriteLine("Premi 10 per filtrare le tv per pollici uguali a quelli scelti");
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        DealerManager.ShowProducts();
                        break;
                    case "2":
                        DealerManager.ShowPhones();
                        break;
                    case "3":
                        DealerManager.ShowPC();
                        break;
                    case "4":
                        DealerManager.ShowTV();
                        break;
                    case "5":
                        DealerManager.InsertProducts();
                        break;
                    case "6":
                        DealerManager.UpdateProducts();
                        break;
                    case "7":
                        DealerManager.DeleteProducts();
                        break;
                    case "8":
                        DealerManager.FiltraMemoria();

                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Inserisci un valore valido");
                        break;
                }
            } while (continuare);
        }
    }
}