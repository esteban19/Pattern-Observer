using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public partial class GrabStocks
    {
        public void GrabStocks_1()
        {
            /* The watcher */
            StockGrabber stockGrabber = new StockGrabber();
            /* The watched */
            StockObserver observer1 = new StockObserver(stockGrabber);

            /* Set prices */
            stockGrabber.setIBMPrice(197.00);
            stockGrabber.setAAPLPrice(198.00);
            stockGrabber.setGOOGPrice(199.00);

            /* The watched */
            StockObserver observer2 = new StockObserver(stockGrabber);

            /* Set prices */
            stockGrabber.setIBMPrice(200.00);
            stockGrabber.setAAPLPrice(198.00);
            stockGrabber.setGOOGPrice(201.00);

            stockGrabber.detach(observer1);

            /* Set prices */
            stockGrabber.setIBMPrice(197.00);
            stockGrabber.setAAPLPrice(196.00);
            stockGrabber.setGOOGPrice(195.00);
        }
    }
}
