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
            
            Console.WriteLine("------------------------------------------------");
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3)
            };
            string userId = "12345";
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(userId, rides);
            Ride[] actual = rideRepository.GetRides(userId);
            //foreach (var item in actual)
            //{
            //    Console.WriteLine("item : "+item.distance);
            //}
            if (actual.Equals(rides))
            {
                Console.WriteLine("They are equal");
            }
            Console.ReadKey();
        }
    }
}
