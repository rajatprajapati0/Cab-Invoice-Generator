using CABINVOICE;
namespace CabInvoiceGeneratorTEST
{
    public class Tests
    {
        InvoiceGenretor invoicgGenretor;

        [Test] 
        public void givenDistanceAndTimeshouldReturnTotalfear()
        {

            invoicgGenretor = new InvoiceGenretor(RideType.Normal);
            double distance = 2.0;
            int time = 5;

            double fare =invoicgGenretor.CalculateFare(distance, time);
            double expexted = 25;
            Assert.AreEqual(expexted,fare);

        }
    }
}