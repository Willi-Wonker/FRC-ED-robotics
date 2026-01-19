using Emgu.CV;



namespace QR_scan_webcam_.net_9._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoCapture capture = new VideoCapture();
            Bitmap image = capture.QueryFrame().Bitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
