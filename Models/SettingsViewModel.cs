// using System;
// using System.Collections.Generic;
// using System.IO.Ports;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace OCR.Models
// {
// 	internal class SettingsViewModel
// 	{
// 		public SettingsViewModel() { }

// 		public string PortName { get; set; }
// 		public int BaudRate { get; set; }
// 		public int DataBits { get; set; }
// 		public Parity Parity { get; set; }
// 		public StopBits StopBits { get; set; }
// 		public string ToJsonString()
// 		{
// 			return "{\n" +
// 				"\t\"PortName\": \"" + PortName + "\"\n" +
// 				"\t\"BaudRate\": \"" + BaudRate + "\"\n" +
// 				"\t\"DataBits\": \"" + DataBits + "\"\n" +
// 				"\t\"Parity\": \"" + Parity + "\"\n" +
// 				"\t\"StopBits\": \"" + StopBits + "\"\n" +
// 			"}";
// 		}

// 	}
// }
