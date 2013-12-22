using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{   /* Each observer monitors all 3 stock prices*/
    public class StockObserver : IObserver
    {
        /*Every instance of a class contains a separate set of all 
         * instance fields of the class.*/
        /* Stock prices */
        private double ibmPrice;
        private double aaplPrice;
        private double googPrice;

        /*A static field identifies exactly one storage location. 
         * No matter how many instances of a class are created, 
         * there is only ever one copy of a static field.*/
        /* Attach a special number to each observer */
        private static int observerIDTracker = 0;

        /* Each individual observer gets a special ID */
        private int observerID;

        /* To make references to the StockGrabber object */
        /* Provides access to this class so can run different methods */
        /* this.stockGrabber */
        private ISubject stockGrabber;

        /* Special constructor takes ISubject.StockGrabber reference */
        public StockObserver(ISubject stockGrabber)
        {
            this.stockGrabber = stockGrabber;
            this.observerID = ++observerIDTracker;//Observers refered to starting with Index 1, List starts at 0
            Console.WriteLine("New Observer " + this.observerID);
            stockGrabber.attach(this);//Add() this. Observer instance to the observers List.
        }

        //set prices to the observer. Default access modifier: public.
        void IObserver.update(double ibmPrice, double aaplPrice, double googPrice)
        {
            this.ibmPrice = ibmPrice;
            this.aaplPrice = aaplPrice;
            this.googPrice = googPrice;

            printThePrices();
        }

        private void printThePrices()
        {
            Console.WriteLine(observerID + "\n IBM: " + ibmPrice +
                "\n AAPL: " + aaplPrice + "\n GOOG: " + googPrice + "\n");
        }
    }
}
