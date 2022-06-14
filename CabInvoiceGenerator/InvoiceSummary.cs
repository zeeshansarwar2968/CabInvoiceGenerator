using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        //Declaring the datapoints/variables for further usage
        public int numberOfRides;
        public double totalFare;
        public double averageFare;
        
        //Setting up the class constructor
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

        //Equals method is intended to return true when another object is supplied which is semantically equal to current instance.
        //GetHashCode method is intended to return an integer value which can be used as a hash code,
        //i.e. key that accompanies the object when object is stored in a hashed data structure
        public override bool Equals(object obj)    //originally Determines whether the specified object instances are considered equal.
        {
            if (obj == null) return false;
            if (!(obj is InvoiceSummary)) return false;

            InvoiceSummary inputObject = (InvoiceSummary)obj;
            return this.numberOfRides == inputObject.numberOfRides && this.totalFare == inputObject.totalFare && this.averageFare == inputObject.averageFare;
        }


        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
