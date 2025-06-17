using Buttplug.Client;
using Buttplug.Core.Messages;
using ManakaIntiface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManakaIntiface.WebClient
{

    public class IntifaceClient
    {
        public SexToyFunction[] sexToyFunctions;
        public ButtplugClient client = new ButtplugClient("ButtplugClient");
        public SFMToyWebsocketClient sFMClient = new SFMToyWebsocketClient();

        SexToyFunction vibratorStf;
        SexToyFunction pistonStf;

        public async Task<string> ConnectIntiface()
        {
            CancellationToken cancellationToken = CancellationToken.None;

            var connector = new ButtplugWebsocketConnector(new Uri("ws://127.0.0.1:12345"));
            try
            {
                await client.ConnectAsync(connector);
            }
            catch (ButtplugClientConnectorException ex)
            {
                Console.WriteLine(
                    $"Can't connect, exiting! Message: {ex.InnerException.Message}");
                return "Not Connected";
            }

            Console.WriteLine("Connected! Check Server for Client Name.");
            var devices = await scanDevicesIntifaceClient();

            List<SexToyFunction> listFunction = new List<SexToyFunction>();

            foreach (var d in devices)
            {
                //Function loop
                foreach (GenericDeviceMessageAttributes? s in d.MessageAttributes.ScalarCmd)
                {
                    string name = d.Name + " " + s.ActuatorType.ToString();
                    SexToyFunction sexToyFunction = new SexToyFunction(d, s.Index, name, s.ActuatorType, Convert.ToInt32(s.StepCount));
                    listFunction.Add(sexToyFunction);
                }
            }

            sexToyFunctions = listFunction.ToArray();

            return "Connected";
        }

        public async Task<ButtplugClientDevice[]> scanDevicesIntifaceClient()
        {
            client.DeviceAdded += (aObj, aDeviceEventArgs) =>
                Console.WriteLine($"Device {aDeviceEventArgs.Device.Name} Connected!");

            client.DeviceRemoved += (aObj, aDeviceEventArgs) =>
                Console.WriteLine($"Device {aDeviceEventArgs.Device.Name} Removed!");

            await client.StartScanningAsync();

            List<SexToyFunction> listSexToysFunction = new List<SexToyFunction>();

            return client.Devices;

        }


        public void TriggerToys()
        {

            //if (sFMClient != null)
            //    sFMClient.ReceiveMessages().RunSynchronously();

            if (vibratorStf == null && pistonStf == null)
                return;

            while (true)
            {
                if (vibratorStf != null)
                {
                    int width = 15;
                    int height = 5;

                    Bitmap bitmapSexToy = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(bitmapSexToy);
                    g.CopyFromScreen(0, Screen.PrimaryScreen.Bounds.Height - height, 0, 0, bitmapSexToy.Size);

                    Color x = bitmapSexToy.GetPixel(1, 1);

                    double scalar = 0;


                    if (x.B == 255)
                    {
                        scalar = 0.33;
                    }
                    else if (x.G == 255)
                    {
                        scalar = 0.66;
                    }
                    else if (x.R == 255)
                    {
                        scalar = 1;
                    }
                    else
                    {
                        scalar = 0;
                    }

                    TriggerSexToy(vibratorStf, scalar);
                }

                if (pistonStf != null)
                {
                    int width = 15;
                    int height = 5;

                    Bitmap bitmapSexToy = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(bitmapSexToy);
                    g.CopyFromScreen(0, Screen.PrimaryScreen.Bounds.Height - height, 0, 0, bitmapSexToy.Size);

                    Color x = bitmapSexToy.GetPixel(11, 1);

                    double scalar = 0;

                    if (x.B == 255)
                    {
                        scalar = 0.33;
                    }
                    else if (x.G == 255)
                    {
                        scalar = 0.66;
                    }
                    else if (x.R == 255)
                    {
                        scalar = 1;
                    }
                    else
                    {
                        scalar = 0;
                    }

                    TriggerSexToy(pistonStf, scalar);
                }

                Thread.Sleep(250);
            }
        }

        public void DisconnectIntiface()
        {
            client.DisconnectAsync();
        }

        private void TriggerSexToy(SexToyFunction stf, double scalar)
        {
            stf.device.ScalarAsync(new ScalarCmd.ScalarSubcommand(stf.id, scalar, stf.type));
        }

        public string ConnectSexToys(DataGridView sexToysGrid, DataGridView pistonToysGrid)
        {
            Int32 selectedSexToyRowCount =
            sexToysGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            Int32 selectedPistonToyRowCount =
            pistonToysGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            var sexToyRow = sexToysGrid.SelectedRows[0];
            var pistonToyRow = pistonToysGrid.SelectedRows[0];

            var returnString = new StringBuilder();
            string sexToyStatus = "unlinked";
            string pistonToysStatus = "unlinked";

            if (selectedSexToyRowCount > 0)
            {
                vibratorStf = sexToyFunctions[sexToyRow.Index];
                sexToyStatus = "linked";
            }

            if (selectedPistonToyRowCount > 0)
            {
                pistonStf = sexToyFunctions[pistonToyRow.Index];
                pistonToysStatus = "linked";
            }

            returnString.Append($"Sex Toy Status: {sexToyStatus}");
            returnString.AppendLine($"Sex Toy Status: {pistonToysStatus}");

            return returnString.ToString();
        }

    }
}
