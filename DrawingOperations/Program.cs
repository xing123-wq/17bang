using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrawingOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() => Verification.GenerateRandomNumber(4));
            thread.IsBackground = true;
            thread.Start();
            Verification.Code();
        }
    }
}
