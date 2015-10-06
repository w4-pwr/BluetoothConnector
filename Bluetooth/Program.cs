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
            Console.WriteLine("BluetoothConnector 0.1");
            BluetoothConnector bc = new BluetoothConnector();
            bc.getPrimaryRadioAddress();
            Console.WriteLine("\nShow all radios");
            bc.showAllRadios();
            bc.scanRemoteDevices();
            Console.WriteLine("\nScanning...");
            bc.scanAndShow();

            Console.WriteLine("\nWith witch device you want to connect?...");
            int index = Convert.ToInt32(Console.ReadLine());
            bc.pair(index);
            Console.ReadLine();
        }
    }
}
