using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABINVOICE
{
    public class InvoiceGenretor
    {
         RideType ridetype;
         private RideRiposetory rideRiposetory;

        public readonly double Minumum_Cost_Per_KM;
        public readonly int Cost_Per_Time;
        public readonly double Minimum_Fare;

        public InvoiceGenretor(RideType ridetype)
        {
            this.ridetype = ridetype;
            this.rideRiposetory = new RideRiposetory();
            try {

                if (ridetype.Equals(RideType.Premium))
                {
                    this.Minumum_Cost_Per_KM = 15;
                    this.Cost_Per_Time = 2;
                    this.Minimum_Fare = 20;
                }
                else if (ridetype.Equals(RideType.Normal))
                {
                    this.Minumum_Cost_Per_KM = 10;
                    this.Cost_Per_Time = 1;
                    this.Minimum_Fare = 5;

                }

            }
            catch (CabinvoiceException)
            {
                throw new CabinvoiceException(CabinvoiceException.ExceptionType.Invailid_Ride_Type, "Invalid Ride type");
            }
        
        }

        public double CalculateFare(double distance, int time) 
        {
            double totalFare = 0;

            try 
            { 
                totalFare = distance * Minumum_Cost_Per_KM + time * Cost_Per_Time; 
            }
            catch(CabinvoiceException)
            {
                if (ridetype.Equals(null)) 
                {
                 throw new CabinvoiceException(CabinvoiceException.ExceptionType.Null_Rides,"invalid ride type");
                }
                if(distance<=0) 
                {
                    throw new CabinvoiceException(CabinvoiceException.ExceptionType.Invailid_Distance, "invalid distanc");
                }
                if (time < 0) 
                {
                throw new CabinvoiceException(CabinvoiceException.ExceptionType.Invailid_Time,"invalid time");
                }
            
            }

            return Math.Max(totalFare, Minimum_Fare);
        }
        

        public InvoiceSummary CalculateFare(Ride[] rides) 
        {
          double totalFare= 0;
            try 
            {
            foreach(Ride ride in rides) 
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            
            }
             catch (CabinvoiceException) 
            {
                if (rides == null) 
                {
                throw new CabinvoiceException(CabinvoiceException.ExceptionType.Null_Rides,"Rides are null");
                
                }
            
            }
            return new InvoiceSummary(rides.Length, totalFare);
        
        }


        public void AddRides(string userID, Ride[]rides) 
        {
            try 
            { 
             
                rideRiposetory.AddRide(userID,rides);
            }
            catch (CabinvoiceException)
            {
             
            if(rides == null) 
               {
                    throw new CabinvoiceException(CabinvoiceException.ExceptionType.Null_Rides, "rides are null");
                
               }
            }

        }
        public InvoiceSummary GetInvoiceSummary(string userID) 
        {
            try 
            {
                return this.CalculateFare(rideRiposetory.GetRides(userID));
            }
            catch 
            {
              throw new CabinvoiceException(CabinvoiceException.ExceptionType.Invailid_User_ID,"invailid User id");
            }
        }


    }

   
}
