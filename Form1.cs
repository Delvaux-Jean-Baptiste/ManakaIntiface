using Buttplug.Client;
using Buttplug.Core.Messages;
using ManakaIntiface.Model;
using ManakaIntiface.WebClient;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManakaIntiface
{
    public partial class Form1 : Form
    {
        SexToyFunction[] sexToyFunctions;
        //ButtplugClient client = new ButtplugClient("ButtplugClient");
        IntifaceClient intifaceClient = new IntifaceClient();
        SFMToyWebsocketClient sFMClient = new SFMToyWebsocketClient();

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
            var returnString = await intifaceClient.ConnectIntiface();
            await scanDevicesBPClient();

            await sFMClient.ConnectSFMToyClient();

            intifaceClient.sFMClient = sFMClient;

            return returnString;
        }

        async Task<List<SexToyFunction>> scanDevicesBPClient()
        {
            var devices = await intifaceClient.scanDevicesIntifaceClient();


            sexToyFunctionBindingSource.Clear();
            pistonToyFunctionBindingSource.Clear();
            List<SexToyFunction> listSexToysFunction = new List<SexToyFunction>();
            //Device loop
            foreach (var d in devices)
            {
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

        //private void screenshot_button_Click(object sender, EventArgs e)
        //{
        //    int width = 15;
        //    int height = 5;

        //    Bitmap bitmap = new Bitmap(width, height);
        //    Graphics g = Graphics.FromImage(bitmap);
        //    g.CopyFromScreen(0, Screen.PrimaryScreen.Bounds.Height - height, 0, 0, bitmap.Size);
        //    pictureBox1.Image = bitmap;

        //    Color x = bitmap.GetPixel(1, 1);

        //    toyColorFinal_label.Text = x.ToString();
        //}

        private void multiScreenshot_button_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(intifaceClient.TriggerToys);
            thr.Start();
        }

        private async void connectIntiface_Click(object sender, EventArgs e)
        {
            intifaceStatusFinal_label.Text = await connectBPClient();
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            intifaceClient.DisconnectIntiface();
        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            
            intifaceStatusFinal_label.Text = intifaceClient.ConnectSexToys(dg_sextoys, dg_PistonToy);

        }
    }
}
