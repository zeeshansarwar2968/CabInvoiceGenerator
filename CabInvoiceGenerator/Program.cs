using System;

namespace CabInvoiceGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t Welcome to Cab Invoice Generator Program!!");
            Console.WriteLine("\t\t------------------------------------------- ");
            Console.ResetColor();
            Console.Write("Please Provide the distance travelled (in km) : ");
            double distance  = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please Provide the time taken for the trip (in minutes) : ");
            int time = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Magenta;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The cost of the trip is : "+invoiceGenerator.CalculateFare(distance,time));
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
