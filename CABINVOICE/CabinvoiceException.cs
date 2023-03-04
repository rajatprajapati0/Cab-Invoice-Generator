using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABINVOICE
{
    internal class CabinvoiceException : Exception
    {

        public enum ExceptionType
        { Invailid_Ride_Type ,
          Invailid_Distance,
          Invailid_Time,
          Null_Rides,
          Invailid_User_ID
        
        
        }
        ExceptionType type;

        public CabinvoiceException(ExceptionType type, string message) : base(message)
         {
            this.type = type;
        }
    }
}
  