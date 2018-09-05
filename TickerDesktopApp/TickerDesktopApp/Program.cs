using Entidades;
using System;
using System.Diagnostics;
using System.Threading;

namespace TickerDesktopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {

                //Console.Write("ESC para salir...");
                Thread t = new Thread(Ticker.TeclaEscape);
                t.Start();

                try
                {
                    Console.Write("BUSCAR TICKER (ESC para salir)>> ");
                    string search = Console.ReadLine().ToUpper();

                    if(search != String.Empty)
                    {
                        Console.Clear();
                        Ticker ticker = new Ticker(search);

                        Console.WriteLine(ticker.MostrarDatos());
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No puede estar vacio.");
                        Console.ReadKey();

                    }
                    Console.Clear();
                }
                catch (NullReferenceException e)
                {
                    Console.Clear();
                    Console.WriteLine(e);
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e);
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
    }
}
