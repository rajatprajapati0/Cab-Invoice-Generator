  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABINVOICE
{
    public class RideRiposetory
    {
        Dictionary<string, List<Ride>> userRides=null;
        public RideRiposetory()
        { 
        this.userRides=new Dictionary<string,List< Ride>>();  

        }

        public void AddRide(string userID, Ride[]rides) 
        {
        
          bool rideList=this.userRides.ContainsKey(userID);

            try 
            {
            
            if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userID, list);
                }
            
            }
            catch(CabinvoiceException) 
            {
                throw new CabinvoiceException(CabinvoiceException.ExceptionType.Null_Rides, "Rides are Null");
            
            }
        }

        public Ride[]GetRides(string userID)
        {
            try
            {
                return this.userRides[userID].ToArray();

            }
            catch (Exception) 
            {
             throw new CabinvoiceException(CabinvoiceException.ExceptionType.Invailid_User_ID,"invalid user ID");
            
            }
        
        }
    }
}
