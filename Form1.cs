using Buttplug.Client;
using Buttplug.Core.Messages;
using ManakaIntiface.Model;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManakaIntiface
{
    public partial class Form1 : Form
    {
        SexToyFunction[] sexToyFunctions;
        ButtplugClient client = new ButtplugClient("ButtplugClient");

        SexToyFunction vibratorStf;
        SexToyFunction pistonStf;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        async Task<String> connectBPClient()
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
            sexToyFunctions = (await scanDevicesBPClient(client)).ToArray();

            return "Connected";
        }

        async Task<List<SexToyFunction>> scanDevicesBPClient(ButtplugClient client)
        {
            client.DeviceAdded += (aObj, aDeviceEventArgs) =>
                Console.WriteLine($"Device {aDeviceEventArgs.Device.Name} Connected!");

            client.DeviceRemoved += (aObj, aDeviceEventArgs) =>
                Console.WriteLine($"Device {aDeviceEventArgs.Device.Name} Removed!");

            await client.StartScanningAsync();

            List<SexToyFunction> listSexToysFunction = new List<SexToyFunction>();
            sexToyFunctionBindingSource.Clear();

            //Device loop
            foreach (var d in client.Devices)
            {
                //await d.ScalarAsync(new ScalarCmd.ScalarSubcommand(1, 0.5, ActuatorType.Constrict));
                //Function loop
                foreach (GenericDeviceMessageAttributes? s in d.MessageAttributes.ScalarCmd)
                {
                    string name = d.Name + " " + s.ActuatorType.ToString();
                    SexToyFunction sexToyFunction = new SexToyFunction(d, s.Index, name, s.ActuatorType, Convert.ToInt32(s.StepCount));
                    listSexToysFunction.Add(sexToyFunction);
                    sexToyFunctionBindingSource.Add(sexToyFunction);
                    pistonToyFunctionBindingSource.Add(sexToyFunction);
                }
            }


            Thread.Sleep(1000);

            return listSexToysFunction;
        }

        private void screenshot_button_Click(object sender, EventArgs e)
        {
            int width = 15;
            int height = 5;

            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0, Screen.PrimaryScreen.Bounds.Height - height, 0, 0, bitmap.Size);
            pictureBox1.Image = bitmap;

            Color x = bitmap.GetPixel(1, 1);

            toyColorFinal_label.Text = x.ToString();
        }

        private void multiScreenshot_button_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(cap);
            thr.Start();
        }

        private void cap()
        {
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
                    pictureBox1.Image = bitmapSexToy;

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

                    triggerSexToy(vibratorStf, scalar);
                }

                if (pistonStf != null)
                {
                    int width = 15;
                    int height = 5;

                    Bitmap bitmapSexToy = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(bitmapSexToy);
                    g.CopyFromScreen(0, Screen.PrimaryScreen.Bounds.Height - height, 0, 0, bitmapSexToy.Size);
                    pictureBox1.Image = bitmapSexToy;

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

                    triggerSexToy(pistonStf, scalar);
                }

                Thread.Sleep(250);
            }
        }

        private void triggerSexToy(SexToyFunction stf, double scalar)
        {
            stf.device.ScalarAsync(new ScalarCmd.ScalarSubcommand(stf.id, scalar, stf.type));
        }

        private async void connectIntiface_Click(object sender, EventArgs e)
        {
            intifaceStatusFinal_label.Text = await connectBPClient();
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.DisconnectAsync();
        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            Int32 selectedSexToyRowCount =
            dg_sextoys.Rows.GetRowCount(DataGridViewElementStates.Selected);

            Int32 selectedPistonToyRowCount =
            dg_PistonToy.Rows.GetRowCount(DataGridViewElementStates.Selected);

            var sexToyRow = dg_sextoys.SelectedRows[0];
            var pistonToyRow = dg_PistonToy.SelectedRows[0];

            if (selectedSexToyRowCount > 0)
            {
                vibratorStf = sexToyFunctions[sexToyRow.Index];
                intifaceStatusFinal_label.Text = "linked";
            }

            if (selectedPistonToyRowCount > 0)
            {
                pistonStf = sexToyFunctions[pistonToyRow.Index];
                intifaceStatusFinal_label.Text = "linked";
            }


        }
    }
}
