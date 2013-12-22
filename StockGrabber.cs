using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class StockGrabber : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private double ibmPrice;
        private double aaplPrice;
        private double googPrice;

        public void attach(IObserver newObserver)
        {
            observers.Add(newObserver);
        }

        public void detach(IObserver deleteObserver)
        {
            int observerIndex = observers.IndexOf(deleteObserver);
            Console.WriteLine("Observer " + (observerIndex + 1) + " deleted");
            observers.RemoveAt(observerIndex);
        }

        public void notifyObserver()
        {
            foreach (IObserver observer in observers)
            {
                observer.update(ibmPrice, aaplPrice, googPrice);
            }
        }

        public void setIBMPrice(double newIBMPrice)
        {
            this.ibmPrice = newIBMPrice;
            notifyObserver();
        }
        public void setAAPLPrice(double newaaplPrice)
        {
            this.aaplPrice = newaaplPrice;
            notifyObserver();
        }
        public void setGOOGPrice(double newgoogPrice)
        {
            this.googPrice = newgoogPrice;
            notifyObserver();
        }

    }
}
