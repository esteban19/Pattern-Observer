using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class GetTheStock : IRunnable
    {
        private int startTime;
        private string stock;
        private double price;

        private ISubject stockGrabber;

        public GetTheStock(ISubject stockGrabber, int newStartTime,
            string newStock, double newPrice)
        {
            /* Grab a reference to stockGrabber in StockGrabber.cs */
            this.stockGrabber = stockGrabber;
            startTime = newStartTime;/* in seconds */
            stock = newStock;
            price = newPrice;
        }
        public void StartThread()
        {
            Thread newThread = new Thread(new ThreadStart(Run));
            newThread.Start();
        }
        public void Run()
        {
            int changeprices = 20;
            int pause = 1000;//int pause = 3000;
            Random r = new Random();
            for (int i = 1; i <= changeprices; i++)
            {
                try
                {
                    //Thread.Sleep(pause);
                    Thread.Sleep(startTime * pause);
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

                /* random number between -.03 to +.03 */
                double randNum = ((r.NextDouble() * (.06))-.03);

                double oldprice = 0.0 + price;
                price += Convert.ToDouble(randNum.ToString("F", CultureInfo.InvariantCulture));

                /* Interesting trick, casting implemented interface using a Double Prnths cast */
                if (stock == "IBM") ((StockGrabber)stockGrabber).setIBMPrice(price);
                if (stock == "AAPL") ((StockGrabber)stockGrabber).setAAPLPrice(price);
                if (stock == "GOOG") ((StockGrabber)stockGrabber).setGOOGPrice(price);

                Console.WriteLine(stock + ": " + 
                    /*(price + randNum)*/oldprice.ToString("F", CultureInfo.InvariantCulture) + 
                    " " + randNum.ToString("F", CultureInfo.InvariantCulture));
                Console.WriteLine();
            }
        }
    }
}
