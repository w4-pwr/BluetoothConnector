using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brecham.Obex;

namespace Bluetooth
{

    class BluetoothConnector
    {
        BluetoothDeviceInfo[] _devices;

        public BluetoothConnector()
        {
        }

        public void scanRemoteDevices()
        {
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            _devices = client.DiscoverDevices();

        }

        public void showDiscoveredDevices()
        {
            if (_devices == null)
            {
                Console.Write("Should be scanned first");
            }
            int i = 0;
            foreach (BluetoothDeviceInfo device in _devices)
            {
                Console.WriteLine("***********| " + i++ + " |***********");
                Console.WriteLine("Authenticated: " + device.Authenticated.ToString());
                Console.WriteLine("Class of Device: " + device.ClassOfDevice.ToString());
                Console.WriteLine("Connected: " + device.Connected.ToString());
                Console.WriteLine("Device Address: " + device.DeviceAddress.ToString());
                Console.WriteLine("Device Name: " + device.DeviceName.ToString());
                Console.WriteLine("InstalledServices: " + device.InstalledServices.ToString());
                Console.WriteLine("Last seen: " + device.LastSeen.ToString());
                Console.WriteLine("Last used: " + device.LastUsed.ToString());
                Console.WriteLine("Remembered: " + device.Remembered.ToString());
                Console.WriteLine("RSSI: " + device.Rssi.ToString());
            }

        }

        public void sendFile(String pathToFile, int index)
        {
            if (inRangeIndex(index))
            {
                var file = @pathToFile;
                var uri = new Uri("obex://" + _devices[index].DeviceAddress + "/" + file);
                var request = new ObexWebRequest(uri);
                request.ReadFile(file);
                var response = (ObexWebResponse) request.GetResponse();
                Console.WriteLine(response.StatusCode.ToString());
                response.Close();
            }
        }

        private bool inRangeIndex(int index)
        {
            bool correctRange = (index >=0 && index < _devices.Length);
            if (!correctRange)
            {
                Console.WriteLine("Zły przedział");
            }
            return correctRange;
        }

        public void reciveFile()
        {
            var listener = new ObexListener(ObexTransport.Bluetooth);
            listener.Start();
            ObexListenerContext context = listener.GetContext();
            ObexListenerRequest request = context.Request;
            String[] pathSplits = request.RawUrl.Split('/');
            String filename = pathSplits[pathSplits.Length - 1];
            request.WriteFile(filename);
            listener.Stop();
        }


        public void showAllRadios()
        {
            BluetoothRadio[] radios = BluetoothRadio.AllRadios;
            foreach (BluetoothRadio btradio in radios)
            {
                showRadioInfo(btradio);
            }

        }

        public void showRadioInfo(BluetoothRadio radio = null)
        {
            if (radio == null)
            {
                radio = BluetoothRadio.PrimaryRadio;
            }

            if (radio != null)
            {
                RadioMode mode = radio.Mode;
                Console.WriteLine("***************************");
                Console.WriteLine("Name: " + radio.Name);
                Console.WriteLine("Manufacturer: " + radio.Manufacturer);
                Console.WriteLine("Class of device: " + radio.ClassOfDevice);
                Console.WriteLine("Hardware status: " + radio.HardwareStatus);
                Console.WriteLine("Local address: " + radio.LocalAddress);
                Console.WriteLine("Software Manufacturer: " + radio.SoftwareManufacturer);
            }
            else
            {
                Console.WriteLine("No primary radio");
            }
        }

        public String getPrimaryRadioAddress()
        {
            BluetoothRadio primaryRadio = BluetoothRadio.PrimaryRadio;
            if (primaryRadio != null)
            {
                RadioMode mode = primaryRadio.Mode;
                return primaryRadio.LocalAddress.ToString();
            }
            else
            {
                throw new Exception("No primary radio");
            }
        }
    }
}
