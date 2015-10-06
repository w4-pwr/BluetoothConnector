using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bt
{
    class BluetoothConncector
    {

        // mac is mac address of local bluetooth device
        BluetoothEndPoint localEndpoint = new BluetoothEndPoint(mac, BluetoothService.SerialPort);
        // client is used to manage connections
        BluetoothClient localClient = new BluetoothClient(localEndpoint);
        // component is used to manage device discovery
        BluetoothComponent localComponent = new BluetoothComponent(localClient);

        public String getInfo()
        {
            localComponent.DiscoverDevicesAsync(255, true, true, true, true, null);
            localComponent.DiscoverDevicesProgress += new EventHandler<DiscoverDevicesEventArgs>(component_DiscoverDevicesProgress);
            localComponent.DiscoverDevicesComplete += new EventHandler<DiscoverDevicesEventArgs>(component_DiscoverDevicesComplete);
        }


        private void component_DiscoverDevicesProgress(object sender, DiscoverDevicesEventArgs e)
        {
            // log and save all found devices
            for (int i = 0; i < e.Devices.Length; i++)
            {
                if (e.Devices[i].Remembered)
                {
                    Print(e.Devices[i].DeviceName + " (" + e.Devices[i].DeviceAddress + "): Device is known");
                }
                else
                {
                    Print(e.Devices[i].DeviceName + " (" + e.Devices[i].DeviceAddress + "): Device is unknown");
                }
                this.deviceList.Add(e.Devices[i]);
            }
        }
    }
}
