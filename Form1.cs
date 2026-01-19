namespace QR_scanner__EDR_testing_
{
    using IronQr;
    using IronSoftware.Drawing;
    using System.Runtime.InteropServices;
    using AForge;
    using AForge.Video;
    using AForge.Video.DirectShow;
    using ZXing;
    using ZXing.QrCode;




    //FilterInfoCollection videoDevices;
    //VideoCaptureDevice videoCaptureDevice;


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();

            FilterInfoCollection filterInfoCollection= new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //foreach (FilterInfo Devoce in filterInfoCollection) 
            //    cboCamera.Items.Add(Device.Name);
            //cboCamera.SelectedIndex = 0;
            VideoCaptureDevice videoCaptureDevice = new VideoCaptureDevice();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button1_Click(object sender, EventArgs e)
        {
            using var stream = File.OpenRead("C:\\Users\\willi\\Pictures\\frame.png");
            var bitmapImage = AnyBitmap.FromStream(stream);
            QrImageInput qrImageImput = new QrImageInput(bitmapImage);

            QrReader qrReader = new QrReader();

            try
            {
                IEnumerable<QrResult> results = qrReader.Read(qrImageImput);

                foreach (var result in results)
                {
                    Console.WriteLine("QR Code Value: " + result.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading QR code: " + ex.Message);

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            //videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
            //videoCaptureDevice.Start();
        }

        //private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    // zxing read qr code from image c#
        //    BarcodeReader Reader = new BarcodeReader();
        //    Result result = Reader.Decode((Bitmap)pictureBox1.Image);
        //    if (result != null)
        //        txtResult.Text = result.ToString();
        //}

        //private void btnDecode_Click(object sender, EventArgs e)
        //{
        //    timer1.Start();
        //}

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (videoCaptureDevice.IsRunning == true)
        //        videoCaptureDevice.Stop();
        //}

    }
}
