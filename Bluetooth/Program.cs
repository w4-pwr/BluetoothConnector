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
         
            Console.WriteLine("Local address, primary radio: " + bc.getPrimaryRadioAddress());
            Console.WriteLine("\nShow all radios");
            bc.showAllRadios();

            Console.WriteLine("\nScanning...");
            bc.scanRemoteDevices();
            bc.showDiscoveredDevices();

//            Console.WriteLine("\nWith witch device you want to connect?...");
//            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Waiting...");
            bc.reciveFile();
            Console.ReadLine();
        }

        private void menu()
        {
            
        }
    }
}
