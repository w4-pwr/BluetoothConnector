using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluetooth
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.startMenu();
            Console.ReadLine();
        }

        private void startMenu()
        {
            Console.WriteLine("BluetoothConnector 0.1");

            BluetoothConnector bc = new BluetoothConnector();
            int choose;
            bool condition = true;
            do
            {
                Console.Write("*************************************\n");
                Console.WriteLine("Co chesz zrobić? :\n");
                Console.Write(" 1 - Znajdź adaptery bluetooth\n");
                Console.Write(" 2 - Znajdź urządzenia bluetooth\n");
                Console.Write(" 3 - Wyślij plik \n");
                Console.Write(" 4 - Odbierz plik \n");
                Console.Write(" 0 - Zakoñcz\n");
                Console.Write(" Twój wybór: ");

                choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("\nZnajdowanie adapterów...");

                        bc.showAllRadios();
                        break;
                    case 2:
                        Console.WriteLine("\nWyszukiwanie urzadzen...");
                        bc.scanRemoteDevices();
                        bc.showDiscoveredDevices();
                        break;
                    case 3:
                        Console.WriteLine("Wysyłanie pliku");
                        Console.WriteLine("Co wysłać?");
                        FileManager fileManager = new FileManager();
                        fileManager.listFiles();
                        int fileIndex = Convert.ToInt32(Console.ReadLine());
                        string filePath = fileManager.getFilePath(fileIndex);

                        Console.WriteLine("Do kogo?");
                        bc.scanRemoteDevices();
                        bc.showDiscoveredDevices();
                        int deviceIndex = Convert.ToInt32(Console.ReadLine());
                        bc.sendFile(filePath, deviceIndex);
                        break;
                    case 4:
                        Console.WriteLine("Odbieranie pliku");
                        bc.reciveFile();
                        break;

                    case 0:
                        Console.Write("Zakończ program");
                        condition = false;
                        break;
                    default:
                        Console.Write("Niepoprawny wybór \n");
                        Console.Write("Spróbuj ponownie.\n");
                        break;
                }
            } while (condition != false);
        }


    }
}
