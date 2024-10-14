
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
// using System.IO.Ports;
// using System.Windows;
using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;

namespace OCR.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		private bool redLightActive = false;
		private bool amberLightActive = false;
		private bool greenLightActive = false;
		private bool buzzerActive = false;
		private bool lrPickerActive = false;
		private bool udPickerActive = false;
		private bool jigLockActive = false;
		private bool airBlowActive = false;
		private bool isMaintenance = false;
		// private bool isRunning = true;
		private string recipeFullPath = @"jobs\Custom A.wid";
		private readonly string defaultOcrDump = "C:\\Temp\\OCR\\store.bmp";
		private readonly Dictionary<string, string> plcMonitor = new Dictionary<string, string>();
		private string lastIssuedCommand = string.Empty;

		public MainWindow()
		{
			try
			{
				// InitializeComponent();
				// SerialPortManager.GetInstance().DataReceivedEventHandler += DataReceivedHandler;
				// _ = Enum.TryParse(Ocr.Properties.Settings.Default.SerialParity, out Parity parity);
				// _ = Enum.TryParse(Ocr.Properties.Settings.Default.SerialStopBits, out StopBits stopBits);
				// SerialPortSettings settings = new SerialPortSettings()
				// {
				// 	PortName = Ocr.Properties.Settings.Default.SerialPortName,
				// 	BaudRate = Ocr.Properties.Settings.Default.SerialBaudRate,
				// 	DataBits = Ocr.Properties.Settings.Default.SerialDataBits,
				// 	Parity = parity,
				// 	StopBits = stopBits
				// };
				// SerialPortManager.GetInstance().Initialize(settings);
				// SerialPortManager.GetInstance().StartReaderThread();
			}
			catch (Exception)
            {
				// MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		// private void DataReceivedHandler(object sender, string e)
		// {
		// 	LogActivity(e);

		// 	if (e.Length >= 44)
		// 	{
		// 		if (e.Contains(PlcSettings.READ_HEADER))
		// 		{
		// 			SerialPortManager.GetInstance().PauseMonitoring();

		// 			string dataBlock = e.Substring(e.IndexOf(PlcSettings.READ_HEADER) + 7, 36);
		// 			LogActivity(dataBlock);
		// 			string blockValue;
		// 			string blockName = string.Empty;
		// 			int blockCount = 0;

		// 			plcMonitor.Clear();

		// 			for (int i = 0; i < dataBlock.Length; i += 4)
		// 			{
		// 				blockValue = dataBlock.Substring(i, 4);
		// 				switch(blockCount)
		// 				{
		// 					case 0:
		// 						blockName = PlcSettings.MONITOR_START_DM_ADDRESS;
		// 						break;
        //                     case 1:
        //                         blockName = PlcSettings.RUN_IN_DM_ADDRESS;
        //                         break;
        //                     case 2:
        //                         blockName = PlcSettings.READY_IN_DM_ADDRESS;
        //                         break;
        //                     case 3:
        //                         blockName = PlcSettings.START_IN_DM_ADDRESS;
        //                         break;
        //                     case 4:
        //                         blockName = PlcSettings.RESET_IN_DM_ADDRESS;
        //                         break;
        //                     case 5:
        //                         blockName = PlcSettings.ORIGIN_IN_DM_ADDRESS;
        //                         break;
        //                     case 6:
        //                         blockName = PlcSettings.OCR_IN_DM_ADDRESS;
        //                         break;
        //                     case 7:
        //                         blockName = PlcSettings.PRINT_IN_DM_ADDRESS;
        //                         break;
        //                     case 8:
        //                         blockName = PlcSettings.BARCODE_IN_DM_ADDRESS;
        //                         break;
        //                 }
		// 				plcMonitor.Add(blockName, blockValue);
		// 				LogActivity($"Reading {blockName} data block:" + blockValue);
		// 				blockCount++;
		// 			}

		// 			ProcessIncomingInstruction(plcMonitor);
        //             SerialPortManager.GetInstance().ResumeMonitoring();
        //         }
		// 	}
		// }

		// private void ProcessIncomingInstruction(Dictionary<string, string> instructions)
		// {
		// 	switch (lastIssuedCommand)
		// 	{
		// 		case "":
		// 			if (instructions[PlcSettings.RUN_IN_DM_ADDRESS] == PlcSettings.DEFAULT_OFF_VALUE)
		// 			{
		// 				LogActivity("PLC not running");
		// 			}
		// 			else
		// 			{
        //                 string payload = string.Concat(
		// 					PlcSettings.PREFIX,
		// 					PlcSettings.UNIT_NUMBER,
		// 					PlcSettings.WRITE_COMMAND,
		// 					PlcSettings.RUN_OUT_DM_ADDRESS,
		// 					PlcSettings.DEFAULT_ON_VALUE);
		// 				SerialPortManager.GetInstance().WriteSerialData(payload);
		// 				lastIssuedCommand = PlcSettings.RUN_OUT_DM_ADDRESS;
		// 			}
		// 			break;
		// 		case PlcSettings.RUN_OUT_DM_ADDRESS:
        //             if (instructions[PlcSettings.READY_IN_DM_ADDRESS] == PlcSettings.DEFAULT_OFF_VALUE)
        //             {
        //                 LogActivity("PLC not ready");
        //             }
        //             else
        //             {
        //                 string payload = string.Concat(
        //                     PlcSettings.PREFIX,
        //                     PlcSettings.UNIT_NUMBER,
        //                     PlcSettings.WRITE_COMMAND,
        //                     PlcSettings.READY_OUT_DM_ADDRESS,
        //                     PlcSettings.DEFAULT_ON_VALUE);
        //                 SerialPortManager.GetInstance().WriteSerialData(payload);
        //                 lastIssuedCommand = PlcSettings.READY_OUT_DM_ADDRESS;
        //             }
        //             break;			}
		// }

		private void Start_Click(object sender, RoutedEventArgs e)
		{
			// isRunning = true;
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.START_OUT_DM_ADDRESS,
			// 	PlcSettings.START_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			// Start.IsEnabled = !isRunning;
			// Exit.IsEnabled = !isRunning;
			// Stop.IsEnabled = isRunning;
			// Reset.IsEnabled = !isRunning;
			// LoadRecipe.IsEnabled = !isRunning;
			LogActivity("Job sequence initiated.");
			//loading_lbl.Visible = true;
			//logo_img.Visible = false;
			//bool ok;
			//start_btn.BackColor = System.Drawing.Color.DarkGreen;
			//stp_btn.BackColor = System.Drawing.Color.LightCoral;
			//reset_btn.BackColor = System.Drawing.Color.Bisque;
			//lib = new Wid110Lib();
			//bool con = false;
			//con = lib.FInit(ip);
			//if (path.ToString().Equals(null))
			//{
			//	MessageBox.Show("Load file first!");
			//}
			//else
			//{
			//	if (!con)
			//		error_label.Text = "Fail to connect to reader!";
			//	else
			//	{

			//		error_label.Text = "Successfully connected to the reader!";

			//		if (file_text.Text != null)
			//		{

			//			lib.FLoadRecipes(lastConfPath, lastConfFile);
			//			lib.FProcessRead();
			//			result = lib.FGetWaferId().ToString();
			//			string sep = result.ToString();
			//			string[] seg = sep.Split(':');
			//			ocr_text.Text = seg[1];
			//			lib.FProcessGetImage(lib.getTmpImage(), 0);
			//			string store = "C:\\pictures\\store.bmp";
			//			if (store != null)
			//			{
			//				if (File.Exists("C:\\pictures\\store1.bmp"))
			//				{
			//					File.Delete("C:\\pictures\\store1.bmp");
			//					System.IO.File.Copy("C:\\pictures\\store.bmp", "C:\\pictures\\store1.bmp");
			//				}
			//			}
			//			liveimage.Load(store);
			//			if (liveimage.IsDisposed == true)
			//			{
			//				liveimage.Visible = false;
			//				trigger_img.Visible = true;

			//				trigger_img.Image = liveimage.Image;
			//			}
			//			liveimage.SizeMode = PictureBoxSizeMode.StretchImage;
			//			lib.FExit();
			//			string write = ocr_text.Text;
			//			System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\htt_ocr\ocr_value.txt");
			//			file.WriteLine(write);
			//			file.Close();
			//		}


			//		else
			//		{
			//			error_label.Visible = true;
			//			error_label.Text = "Please Load a file";
			//		}


			//	}
			//}

			//string check = @"C:\\htt_ocr\\ocr_value.txt";
			//if (new FileInfo(check).Length != 0)
			//{
			//	int sec = 10000;
			//	Thread.Sleep(sec);
			//	using (StreamReader reader = File.OpenText(@"C:\label_attach\SAMPLE.txt"))
			//		barcode_text.Text = reader.ReadToEnd();
			//}

			//// sending data to microcontroller
			//try
			//{
			//	sp.Write("S"); // Start the Machine Process
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show("Error in Sending Data ::" + ex.Message, "Error");
			//}
		}

		private void Stop_Click(object sender, RoutedEventArgs e)
		{
			// isRunning = false;
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.STOP_OUT_DM_ADDRESS,
			// 	PlcSettings.STOP_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			// Start.IsEnabled = !isRunning;
			// Exit.IsEnabled = !isRunning;
			// Stop.IsEnabled = isRunning;
			// Reset.IsEnabled = !isRunning;
			// LoadRecipe.IsEnabled = !isRunning;
			LogActivity("Job sequence stopped.");
			//trigger_img.Visible = false;
			//logo_img.Visible = true;
			//liveimage.Visible = false;
			//stp_btn.BackColor = System.Drawing.Color.DarkRed;
			//start_btn.BackColor = System.Drawing.Color.PaleGreen;
			//reset_btn.BackColor = System.Drawing.Color.Bisque;
			//liveimage.Dispose();
			//lib.FExit();
			//ocr_text.Clear();
			//error_label.Text = null;
			//System.IO.File.Delete("C:\\pictures\\store.bmp");
			//try
			//{
			//	sp.Write("P"); // Stop the Machine Process
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show("Error in Sending Data ::" + ex.Message, "Error");
			//}
		}

		private void Reset_Click(object sender, RoutedEventArgs e)
		{
			// isRunning = false;
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.RESET_OUT_DM_ADDRESS,
			// 	PlcSettings.RESET_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			// Start.IsEnabled = !isRunning;
			// Exit.IsEnabled = !isRunning;
			// Stop.IsEnabled = isRunning;
			// Reset.IsEnabled = isRunning;
			LogActivity("Reset initialized.");
			//reset_btn.BackColor = System.Drawing.Color.DarkOrange;
			//start_btn.BackColor = System.Drawing.Color.PaleGreen;
			//stp_btn.BackColor = System.Drawing.Color.LightCoral;
			//trigger_img.Visible = false;
			//logo_img.Visible = true;
			//liveimage.Visible = false;
			//liveimage.Image = null;
			//liveimage.Dispose();
			//lib.FExit();
			//liveimage.SizeMode = PictureBoxSizeMode.StretchImage;
			//ocr_text.Clear();
			//System.IO.File.Delete("C:\\pictures\\store.bmp");
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			// Application.Current.Shutdown();
		}

		private void LoadRecipe_Click(object sender, RoutedEventArgs e)
		{
			// LogActivity("Open dialog...");
			// OpenFileDialog open = new OpenFileDialog();
			// open.Title = "Select recipe...";
			// open.Filter = "Wafer recipe|*.wid";
			// open.InitialDirectory = Environment.CurrentDirectory;
			// open.ShowDialog();
			// recipeFullPath = open.FileName;
			LogActivity("Recipe loaded using " + recipeFullPath);
			//string lastConfPath = getPath(open.FileName, lastConfFile);
			//open.Dispose();
			//string help = lastConfFile;
			//string[] job = help.Split('.');
			//file_text.Text = job[0];
			//error_label.Visible = false;
			//error_label.Text = null;
			//if (usercombo_box.Text == "OPERATOR")
			//{
			//	enablebutton();
			//}
			//else if (usercombo_box.Text == "ENGINEER")
			//{
			//	enablebutton();
			//	utility_box.Enabled = true;
			//}
			//else if (usercombo_box.Text == "ADMINISTRATOR")
			//{
			//	enablebutton();
			//	utility_box.Enabled = true;
			//}
		}

		private void RedLight_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.RED_OUT_DM_ADDRESS,
			// 	redLightActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			redLightActive = !redLightActive;
			LogActivity(string.Format("Red light {0}activated.", redLightActive ? string.Empty : "de"));

			//if (red == false)
			//{
			//	red_btn.BackColor = System.Drawing.Color.IndianRed;
			//	red = true;
			//	try
			//	{
			//		sp.Write("R"); //on red Towerlight                 
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error Sending Data ::" + ex.Message, "Error!");
			//	}
			//}
			//else
			//{
			//	red_btn.BackColor = System.Drawing.Color.White;
			//	red = false;
			//	try
			//	{
			//		sp.Write("D");
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error Sending Data ::" + ex.Message, "Error");
			//	}

			//}
		}

		private void AmberLight_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.AMBER_OUT_DM_ADDRESS,
			// 	amberLightActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			amberLightActive = !amberLightActive;
			LogActivity(string.Format("Amber light {0}activated.", amberLightActive ? string.Empty : "de"));
			//if (amber == false)
			//{
			//	amber_btn.BackColor = System.Drawing.Color.Yellow;
			//	amber = true;
			//	try
			//	{
			//		sp.Write("Y"); // on amber Towerlight
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error Sending Data ::" + ex.Message, "Error");
			//	}
			//}
			//else
			//{
			//	amber_btn.BackColor = System.Drawing.Color.White;
			//	amber = false;
			//	try
			//	{
			//		sp.Write("W"); // off amber Towerlight   
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error Sending Data ::" + ex.Message, "Error");
			//	}
			//}
		}

		private void GreenLight_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.GREEN_OUT_DM_ADDRESS,
			// 	greenLightActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			greenLightActive = !greenLightActive;
			LogActivity(string.Format("Green light {0}activated.", greenLightActive ? string.Empty : "de"));
			//if (green == false)
			//{
			//	green_btn.BackColor = System.Drawing.Color.Green;
			//	green = true;
			//	try
			//	{
			//		sp.Write("G");
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error Sending Data ::" + ex.Message, "Error");
			//	}
			//}
			//else
			//{
			//	green_btn.BackColor = System.Drawing.Color.White;
			//	green = false;
			//	try
			//	{
			//		sp.Write("N");
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error Sending Data ::" + ex.Message, "Error");
			//	}
			//}
		}

		private void Buzzer_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.BUZZER_OUT_DM_ADDRESS,
			// 	buzzerActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			// buzzerActive = !buzzerActive;
			LogActivity(string.Format("Buzzer {0}activated.", buzzerActive ? string.Empty : "de"));
		}

		private void Camera_Click(object sender, RoutedEventArgs e)
		{
			LogActivity("Camera test initiated.");

			var file = new FileInfo(defaultOcrDump);
			if (file?.Directory?.Exists != null && !file.Directory.Exists)
			{
				Directory.CreateDirectory(file.Directory.FullName);
			}

			// ReadAndProcessOCR();

			// ************************************
			//bool con = false;

			//con = lib.FInit(ip);


            //if (!con)
            //	txtStatus.Text = "Connect to Reader failed";
            //else
            //{
            //	txtStatus.Text = "Connect successful";

            //	if (!(txtJob.Text.CompareTo("CURRENT JOB -> EMPTY") == 0))
            //	{

            //		lib.FLoadRecipes(lastConfPath, lastConfFile);
            //		txtStatus.Text = "START READING";
            //		lib.FProcessRead();

            //		if (lib.getReadOK() == 0)
            //		{
            //			txtStatus.Text = "READING FAILED! MANUAL TYPE IN";
            //			lib.FExit();
            //			// CallJava();
            //			lib.FInit(ip);
            //			lib.FProcessRead();
            //			final = lib.FGetWaferId();

            //		}
            //		else
            //			final = lib.FGetWaferId().ToString();

            //		txtStatus.Text = "SENT RESULT: " + final.ToString() + " TO PRINTER";

            //		lib.FProcessGetImage(sample, 0);

            //		pbImage.Load(sample);
            //		pbImage.SizeMode = PictureBoxSizeMode.StretchImage;



            //		lib.FExit();
            //		CallPrinter(final.ToString());
            //	}
            //	else
            //		txtStatus.Text = "Load JOB before";
            //}
            // ************************************


            //if (camera == false)
            //{
            //	loading_lbl.Visible = true;
            //	cam_btn.BackColor = SystemColors.ActiveCaption;
            //	camera = true;
            //	lib = new Wid110Lib();
            //	logo_img.Visible = false;
            //	bool ok;
            //	lib = new Wid110Lib();
            //	bool con = false;
            //	con = lib.FInit(ip);
            //	if (!con)
            //		error_label.Text = "Fail to connect to reader!";
            //	else
            //	{
            //		error_label.Text = "Successfully connected to the reader!";
            //		if (file_text.Text != null)
            //		{
            //			lib.FLoadRecipes(lastConfPath, lastConfFile);
            //			lib.FProcessRead();
            //			result = lib.FGetWaferId().ToString();
            //			string sep = result.ToString();
            //			string[] seg = sep.Split(':');
            //			ocr_text.Text = seg[1];
            //			lib.FProcessGetImage(lib.getTmpImage(), 0);
            //			string store = "C:\\pictures\\store.bmp";
            //			if (store != null)
            //			{
            //				if (File.Exists("C:\\pictures\\store1.bmp"))
            //				{
            //					File.Delete("C:\\pictures\\store1.bmp");
            //					System.IO.File.Copy("C:\\pictures\\store.bmp", "C:\\pictures\\store1.bmp");
            //				}
            //			}
            //			liveimage.Load(store);
            //			if (liveimage.IsDisposed == true)
            //			{
            //				liveimage.Visible = false;
            //				trigger_img.Visible = true;
            //				trigger_img.Image = liveimage.Image;

            //			}
            //			liveimage.SizeMode = PictureBoxSizeMode.StretchImage;
            //			lib.FExit();
            //		}
            //	}
            //}
            //else
            //{
            //	trigger_img.Visible = false;
            //	logo_img.Visible = true;
            //	liveimage.Visible = false;
            //	cam_btn.BackColor = System.Drawing.Color.White;
            //	camera = false;
            //	liveimage.Image = null;
            //	liveimage.Dispose();
            //	lib.FExit();
            //	liveimage.SizeMode = PictureBoxSizeMode.StretchImage;
            //	ocr_text.Clear();
            //	System.IO.File.Delete("C:\\pictures\\store.bmp");
            //}
        }

        // private void ReadAndProcessOCR()
        // {
        //     Wid110LibDev widLib = new Wid110LibDev(new Logger());
        //     bool connected = widLib.init(Ocr.Properties.Settings.Default.WID110IPAddress);
        //     string waferId;

        //     if (connected)
        //     {
        //         widLib.loadRecipes("./",recipeFullPath);

        //         if (widLib.processRead())
        //         {
        //             waferId = widLib.getWaferId();
        //             widLib.processGetImage(defaultOcrDump, 0);

		// 			if (File.Exists(defaultOcrDump))
		// 			{
		// 				// OcrImagePreview.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(defaultOcrDump));
		// 			}

		// 			PrintOCR(waferId);
        //         }
        //         widLib.exit();
        //     }
        // }

        private static void PrintOCR(string waferId)
		{

            // UpcLabel label = new UpcLabel(waferId);
            // label.Print(Ocr.Properties.Settings.Default.PrinterName);
        }

        private void Printer_Click(object sender, RoutedEventArgs e)
		{
			LogActivity("Printer test initiated.");
			// UpcLabel label = new UpcLabel(OcrValue.Text);
			// label.Print(Ocr.Properties.Settings.Default.PrinterName);
			//if (printer == false)
			//{
			//	printer_btn.BackColor = SystemColors.ActiveCaption;
			//	printer = true;
			//	string ocr = ocr_text.Text;
			//	Printer(ocr);
			//}
			//else
			//{
			//	printer_btn.BackColor = System.Drawing.Color.White;
			//	printer = false;
			//}
		}

		private void Settings_Click(object sender, RoutedEventArgs e)
		{
			// Settings settings = new Settings();
			// if (settings?.ShowDialog() == true)
			{
				LogActivity("Serial settings updated.");
			}
		}

		private void ClearMessageLog_Click(object sender, RoutedEventArgs e)
		{
			// MessageLog?.Items.Clear();
		}


		// ref methods
		/// =============================================
		//private void Form1_Load(object sender, EventArgs e)
		//{

		//	trigger_img.Visible = false;
		//	logo_img.Visible = false;
		//	liveimage.Visible = true;
		//	sp.ReadTimeout = 5000;
		//	sp.WriteTimeout = 500;
		//	System.Threading.Thread.Sleep(1000);
		//	File.WriteAllText(@"C:\htt_ocr\ocr_value.txt", string.Empty);
		//	try
		//	{
		//		if (!sp.IsOpen)
		//		{
		//			sp.Open();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("Error Sending/Writing ::" + ex.Message, "Error");
		//	}

		//}

		/// =============================================
		//private void SetText(string text)

		//{

		//	// InvokeRequired required compares the thread ID of the

		//	// calling thread to the thread ID of the creating thread.

		//	// If these threads are different, it returns true.

		//	if (this.textBox2.InvokeRequired)

		//	{

		//		SetTextCallback d = new SetTextCallback(SetText);

		//		this.Invoke(d, new object[] { text });

		//	}

		//	else this.textBox2.Text += text;

		//}

		/// =============================================
		//private void Printer(string result)
		//{

		//	UpcLabel label = new UpcLabel(result);

		//	label.Print("ZDesigner GK420t (Copy 1)");
		//}

		/// =============================================
		/// Manual entry of OCR value
		//private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		//{

		//	if (e.KeyChar == Convert.ToChar(Keys.Enter))

		//	{
		//		string write = textBox2.Text;
		//		System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\ocr_value\ocr_value.txt");
		//		file.WriteLine(write);
		//		file.Close();
		//		// Read Textfile
		//		StreamReader s = new StreamReader(@"C:\label_attach\SAMPLE.txt");
		//		string currentLine;
		//		string searchString = textBox2.Text;
		//		bool foundText = false;

		//		do
		//		{
		//			currentLine = s.ReadLine();
		//			if (currentLine != null)
		//			{
		//				foundText = currentLine.Contains(searchString);
		//			}
		//		}
		//		while (currentLine != null && !foundText);
		//		if (foundText)
		//		{
		//			for (int i = 0; i < currentLine.Length; i++)
		//			{
		//				string[] q = currentLine.Split(' ');
		//				for (int j = 0; j < q.Length; j++)
		//				{
		//					ocr_text.Text = q[0];
		//					textBox1.Text = q[j];
		//					//textBox2.Clear();
		//				}
		//			}
		//			try
		//			{
		//				if (!sp.IsOpen)
		//					sp.Open();
		//				sp.Write(textBox1.Text + "\n");
		//				MessageBox.Show("galing!");
		//			}
		//			catch (Exception ex)
		//			{
		//				MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
		//			}
		//		}
		//		if (e.KeyChar == Convert.ToChar(Keys.Enter))
		//		{

		//			//  System.Threading.Thread.Sleep(500);
		//			//  barcode_text.Text = sp.ReadLine();

		//		}
		//		else
		//		{
		//			MessageBox.Show("NOT FOUND!");
		//		}
		//	}
		//}

		/// =============================================
		//private string getPath(string fqfn, string name)
		//{
		//	int lfn = fqfn.Length;
		//	int lnm = name.Length;
		//	int pos = fqfn.LastIndexOf(name);
		//	string path = ".";

		//	if (pos > 0 && pos == (lfn - lnm))
		//	{
		//		path = fqfn.Substring(0, lfn - lnm - 1);
		//	}
		//	return path;
		//}

		private void LogActivity(string message)
		{
			// MessageLog.Dispatcher.Invoke(new Action(() =>
			// {
			// 	MessageLog.Items.Add(string.Format("[{0}] Incoming: {1}", DateTime.Now.ToString("dd-MMM-yy HH:mm:ss"), message));
			// 	MessageLog.ScrollIntoView(MessageLog.Items[MessageLog.Items.Count - 1]);
			// }));
		}
		private void Window_Closed(object sender, EventArgs e)
		{
			// SerialPortManager.GetInstance().StopReaderThread();
			// SerialPortManager.GetInstance().Dispose();
		}

        private void Maintenance_Click(object sender, RoutedEventArgs e)
        {
            // string payload = string.Concat(
            //     PlcSettings.PREFIX,
            //     PlcSettings.UNIT_NUMBER,
            //     PlcSettings.WRITE_COMMAND,
            //     PlcSettings.MANUAL_OUT_DM_ADDRESS,
            //     isMaintenance ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
            // SerialPortManager.GetInstance().WriteSerialData(payload);
            isMaintenance = !isMaintenance;
            LogActivity(string.Format("Maintenance mode {0}activated.", isMaintenance ? string.Empty : "de"));

			// RedLight.IsEnabled = isMaintenance;
			// AmberLight.IsEnabled = isMaintenance;
			// GreenLight.IsEnabled = isMaintenance;
			// Buzzer.IsEnabled = isMaintenance;
			// Camera.IsEnabled = isMaintenance;
			// Printer.IsEnabled = isMaintenance;
			// NextSet.IsEnabled = isMaintenance;
			// PreviousSet.IsEnabled = isMaintenance;
			// LRPicker.IsEnabled = isMaintenance;
			// UDPicker.IsEnabled = isMaintenance;
			// JigLock.IsEnabled = isMaintenance;
			// AirBlow.IsEnabled = isMaintenance;

			// Start.IsEnabled = !isMaintenance;
			// Stop.IsEnabled = !isMaintenance;
			// Reset.IsEnabled = !isMaintenance;
			// LoadRecipe.IsEnabled = !isMaintenance;
		}

		private void NextSet_Click(object sender, RoutedEventArgs e)
		{
			// MaintenancePanelSet1.Visibility = Visibility.Hidden;
			// MaintenancePanelSet2.Visibility = Visibility.Visible;
		}

		private void PreviousSet_Click(object sender, RoutedEventArgs e)
		{
			// MaintenancePanelSet1.Visibility = Visibility.Visible;
			// MaintenancePanelSet2.Visibility = Visibility.Hidden;
		}

		private void LRPicker_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.LRPICKER_MANUAL_OUT_DM_ADDRESS,
			// 	lrPickerActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			lrPickerActive = !lrPickerActive;
			LogActivity(string.Format("L/R picker {0}activated.", lrPickerActive ? string.Empty : "de"));
		}

		private void UDPicker_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.UDPICKER_MANUAL_OUT_DM_ADDRESS,
			// 	udPickerActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			udPickerActive = !udPickerActive;
			LogActivity(string.Format("U/D picker {0}activated.", udPickerActive ? string.Empty : "de"));
		}

		private void JigLock_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.JIG_LOCK_MANUAL_OUT_DM_ADDRESS,
			// 	jigLockActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			jigLockActive = !jigLockActive;
			LogActivity(string.Format("Jig Lock {0}activated.", jigLockActive ? string.Empty : "de"));
		}

		private void AirBlow_Click(object sender, RoutedEventArgs e)
		{
			// string payload = string.Concat(
			// 	PlcSettings.PREFIX,
			// 	PlcSettings.UNIT_NUMBER,
			// 	PlcSettings.WRITE_COMMAND,
			// 	PlcSettings.AIRBLOW_MANUAL_OUT_DM_ADDRESS,
			// 	airBlowActive ? PlcSettings.DEFAULT_OFF_VALUE : PlcSettings.DEFAULT_ON_VALUE);
			// SerialPortManager.GetInstance().WriteSerialData(payload);
			airBlowActive = !airBlowActive;
			LogActivity(string.Format("Air blow {0}activated.", airBlowActive ? string.Empty : "de"));
		}
	}
}