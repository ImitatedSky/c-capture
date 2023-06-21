using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using emgucv = Emgu.CV;
using Emgu.CV.Structure;



namespace _Capture
{
    //test upload github
    public partial class Capture : Form
    {
        SerialPort port;

        emgucv.VideoCapture cap = null;
        emgucv.Mat mat = null;

        public Capture()
        {
            InitializeComponent();
        }

        private void Capture_Load(object sender, EventArgs e)
        {
            RefreshComport();

            port = new SerialPort();
            port.BaudRate = 115200;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;

            if (toolStripComboBox_Com.Items.Count > 0)
            {
                string comSaved = "";

                string filePath = Environment.CurrentDirectory + @"\data.txt";
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string setting = "";
                    while ((setting = sr.ReadLine()) != null)
                    {
                        switch (setting.Split('_')[0])
                        {
                            case "com":
                                comSaved = setting.Split('_')[1];
                                break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(comSaved))
                    toolStripComboBox_Com.SelectedItem = comSaved;
                else
                    toolStripComboBox_Com.SelectedIndex = 0;
            }
            else
                MessageBox.Show("未開啟藍芽通道。\n無法使用裝置Snap功能。", "無法連接藍芽", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            int camIndex = 0;
            for (int i = devices.Length - 1; -1 < i; i--)
            {
                //以裝置名稱取得裝置序號
                if (devices[i].Name == "USB Camera")
                {
                    camIndex = i;
                    break;
                }

                //搜尋後未找到裝置
                if (i == devices.Length - 1)
                {
                    MessageBox.Show("USB未連接", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }

            cap = new emgucv.VideoCapture(camIndex);
            cap.Set(emgucv.CvEnum.CapProp.FrameWidth, 640);
            cap.Set(emgucv.CvEnum.CapProp.FrameHeight, 480);
            cap.Set(emgucv.CvEnum.CapProp.Fps, 30);
            mat = new emgucv.Mat();
            cap.ImageGrabbed += ImageGrabbed;
            cap.Start();
        }

        private void ImageGrabbed(object sender, EventArgs e)
        {
            cap.Retrieve(mat);
            imageBox.Image = mat;
        }

        private void oKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emgu.CV.Image<Rgb, Byte> image;
            image = imageBox.Image.GetInputArray().GetMat().ToImage<Rgb, byte>();

            image.Save("Fvcap.bmp");

            Console.WriteLine("Ok");
            Close();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sETUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cap.Set(emgucv.CvEnum.CapProp.Settings, 1);
        }

        private void nORMALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cap == null)
                return;

            cap.FlipHorizontal = false;
        }

        private void mIRRORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cap == null)
                return;

            cap.FlipHorizontal = true;
        }

        private void toolStripComboBox_Com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string filePath = Environment.CurrentDirectory + @"\data.txt";
                using (StreamWriter sw = File.CreateText(filePath))
                    sw.WriteLine("com_" + (string)toolStripComboBox_Com.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PortConnect();
        }

        private void Capture_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
        }

        private void DataReceived()
        {
            check_DataReceived.Checked = true;
        }

        private void snap()
        {
            check_snap.Checked = true;
        }

        private void RefreshComport()
        {
            //取得通訊埠，並排列順序
            toolStripComboBox_Com.Items.Clear();
            string[] serialPorts = SerialPort.GetPortNames();
            foreach (string serialPort in serialPorts)
                toolStripComboBox_Com.Items.Add(serialPort);
        }

        private void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Invoke(new Action(() => { DataReceived(); }));

            Thread.Sleep(10);
            byte[] receivedData = new byte[5];
            int timeCostCounter = 0;
            while (port.BytesToRead < receivedData.Length)
            {
                if (timeCostCounter <= 200)
                {
                    Thread.Sleep(5);
                    timeCostCounter++;
                }
                else
                    break;
            }

            port.Read(receivedData, 0, receivedData.Length);
            port.DiscardInBuffer();

            if (receivedData[0] == 0x05 && receivedData[1] == 0x02 && receivedData[2] == 0x04 && receivedData[3] == 0x02 && receivedData[4] == 0x00)
            {
                Invoke(new Action(() => { snap(); }));
                Invoke(new Action(() => { oKToolStripMenuItem_Click(sender, new EventArgs()); }));
            }
        }

        private void PortConnect()
        {
            ConnectPort:
            try
            {
                if (port.IsOpen)
                    port.Close();
                port.PortName = (string)toolStripComboBox_Com.SelectedItem;
                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(PortDataReceived);
            }
            catch
            {
                if (toolStripComboBox_Com.SelectedIndex == toolStripComboBox_Com.Items.Count - 1)
                    MessageBox.Show("未開啟藍芽通道或已被其他程式占用。\n無法使用裝置Snap功能。", "無法連接藍芽", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    toolStripComboBox_Com.SelectedIndex++;
                    goto ConnectPort;
                }
            }
        }
    }
}

