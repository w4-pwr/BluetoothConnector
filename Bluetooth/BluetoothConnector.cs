using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluetooth
{
    class BluetoothConnector
    {
        public BluetoothConnector()
        {
            //todo
        }

        private BluetoothDeviceInfo[] scanRemoteDevices()
        {
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            return client.DiscoverDevices();
        }

        public void scanAndShow()
        {
            BluetoothDeviceInfo[] devices = scanRemoteDevices();
            foreach (BluetoothDeviceInfo device in devices)
            {
                Console.WriteLine("***************************");
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

        public void pair(BluetoothDeviceInfo device)
        {
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
