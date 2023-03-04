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


        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            invoicgGenretor = new InvoiceGenretor(RideType.Normal);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary invoiceSummary =invoicgGenretor.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }
    }
}