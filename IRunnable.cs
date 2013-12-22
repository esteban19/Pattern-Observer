using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IRunnable
    {
        void StartThread();/* Must implement System.Threading */
        // {
        //      Thread newThread = new Thread(new ThreadStart(Run));
        //      newThread.Start();
        // }
        //Of course, could have done the above with an abstract class.
        void Run();
    }
}
