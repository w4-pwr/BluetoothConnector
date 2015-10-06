using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluetooth
{
    class Program
    {
        static void Main(string[] args)
        {
            BluetoothConnector bc = new BluetoothConnector();
            bc.getAddr();
            bc.scan();
            Console.WriteLine("Testy");
            Console.ReadLine();
        }
    }
}
