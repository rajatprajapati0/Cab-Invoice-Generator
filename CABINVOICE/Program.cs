using System;
namespace CABINVOICE 
{


    public class Program
    {
    
        public static void Main(string[] args) 
        {
            Console.WriteLine("Welcome To cab Genretor");
            InvoiceGenretor invoiceGenretor = new InvoiceGenretor(RideType.Normal);
            double fare = invoiceGenretor.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare:{fare}");
        }
    }

}
