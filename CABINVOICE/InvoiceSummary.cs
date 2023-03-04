﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABINVOICE
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;
        public InvoiceSummary(int numberOfRides,double totalFare) 
        { 
          this.numberOfRides = numberOfRides;
          this.totalFare = totalFare;
          this.averageFare=this.totalFare/numberOfRides;

        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputobject = (InvoiceSummary)obj;

            return this.numberOfRides==inputobject.numberOfRides&&this.totalFare==inputobject.totalFare&&this.averageFare==inputobject.averageFare;
        }

        public override int GetHashCode() 
        {
         return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        
        }

    }
}