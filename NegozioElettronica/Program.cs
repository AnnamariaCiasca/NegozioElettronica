/*Scrivere un programma che gestisca un negozio di elettronica:

I prodotti hanno
- Marca
- Modello
- Quantità in magazzino

I cellulari hanno:
- Marca
- Modello
- Quantità in magazzino
- Memoria in GB

I pc hanno:
- Marca
- Modello
- Quantità in magazzino
- Sistema operativo(Windows, Mac, Linux)
- se sono o no touch screen

Le tv hanno:
- Marca
- Modello
- Quantità in magazzino
- Pollici

L'utente può
- visualizzare tutti i prodotti
- visualizzare tutti i cellulari
- visualizzare tutti i pc
- visualizzare tutte le tv
- inserire un nuovo prodotto(fare a piacere o un unico metodo di inserimenti che chiede quale entità modificare o tre metodi separati)
- modificare un prodotto(fare a piacere o un unico metodo di inserimenti che chiede quale entità modificare o tre metodi separati)
- eliminare un prodotto(fare a piacere o un unico metodo di eliminazione che chiede quale entità modificare o tre metodi separati)
- filtrare i cellulari per memoria superiore a quella scelta
- filtrare i pc per sistema operativo scelto dall'utente
- filtrare le tv per pollici uguali a quelli scelti dell'utente

Note:
-rispettare la corretta struttura(Ogni classe e ogni metodo hanno uno e un solo scopo)
-creare un repository fittizio (quindi anche le interfacce)
-salvare i dati su sql server tramite ado
*/


using System;

namespace NegozioElettronica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto");
            Menu.Start();
        }
    }
}
