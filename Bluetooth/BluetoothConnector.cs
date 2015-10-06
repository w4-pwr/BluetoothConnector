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

           

        }


        public void component_DiscoverDevicesProgress(object sender, DiscoverDevicesEventArgs e)
        {
            // log and save all found devices
            for (int i = 0; i < e.Devices.Length; i++)
            {
                if (e.Devices[i].Remembered)
                {
                    Console.WriteLine(e.Devices[i].DeviceName + " (" + e.Devices[i].DeviceAddress + "): Device is known");
                }
                else
                {
                    Console.WriteLine(e.Devices[i].DeviceName + " (" + e.Devices[i].DeviceAddress + "): Device is unknown");
                }
                List<BluetoothDeviceInfo> deviceList = new List<BluetoothDeviceInfo>();
                deviceList.Add(e.Devices[i]);
            }
        }

        private void component_DiscoverDevicesComplete(object sender, DiscoverDevicesEventArgs e)
        {
            // log some stuff
        }

        public void scan()
        {
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            BluetoothClient bluetoothClient = new BluetoothClient();
            String authenticated;
            String classOfDevice;
            String connected;
            String deviceAddress;
            String deviceName;
            String installedServices;
            String lastSeen;
            String lastUsed;
            String remembered;
            String rssi;
            foreach (BluetoothDeviceInfo device in devices)
            {
                authenticated = device.Authenticated.ToString();
                classOfDevice = device.ClassOfDevice.ToString();
                connected = device.Connected.ToString();
                deviceAddress = device.DeviceAddress.ToString();
                deviceName = device.DeviceName.ToString();
                installedServices = device.InstalledServices.ToString();
                lastSeen = device.LastSeen.ToString();
                lastUsed = device.LastUsed.ToString();
                remembered = device.Remembered.ToString();
                rssi = device.Rssi.ToString();


                BluetoothSecurity.PairRequest(device.DeviceAddress, Console.ReadLine());

                string[] row = new string[] { authenticated, classOfDevice, connected, deviceAddress, deviceName, installedServices, lastSeen, lastUsed, remembered, rssi };
                foreach(String s in row)
                {
 
                    Console.WriteLine(s);
                }
            }

            BluetoothDeviceInfo[] paired = client.DiscoverDevices(255, false, true, false, false);
            // check every discovered device if it is already paired 
            foreach (BluetoothDeviceInfo device in devices)
            {
                bool isPaired = false;
                for (int i = 0; i < paired.Length; i++)
                {
                    if (device.Equals(paired[i]))
                    {
                        isPaired = true;
                        break;
                    }
                }

                // if the device is not paired, pair it!
                if (!isPaired)
                {
                    // replace DEVICE_PIN here, synchronous method, but fast
                    isPaired = BluetoothSecurity.PairRequest(device.DeviceAddress, "6969");
                    if (isPaired)
                    {
                        // now it is paired
                    }
                    else
                    {
                        // pairing failed
                    }
                }
            }
        }
        
        public String getAddr()
        {
            BluetoothRadio myRadio = BluetoothRadio.PrimaryRadio;
            if (myRadio != null)
            {
                RadioMode mode = myRadio.Mode;
                return myRadio.LocalAddress.ToString();
            }
            else
            {
                throw new Exception("NO BLUETOOTH");
            }

        }
    }
}
