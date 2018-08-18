using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikBDCheckTool
{
    public class CamInfo :IComparable
    {
        string _ipaddress;
        string _model;
        string _macAddress;
        string _userList;
        string _deviceID;
        string _firwVersion;


        public string Ipaddress { get => _ipaddress; set => _ipaddress = value; }
        public string UserList { get => _userList; set => _userList = value; }
        public string FirewVersion { get => _firwVersion; set => _firwVersion = value; }
        public string Model { get => _model; set => _model = value; }
        public string MacAddress { get => _macAddress; set => _macAddress = value; }
        public string DeviceID { get => _deviceID; set => _deviceID = value; }

        public int CompareTo(object obj)
        {
            CamInfo camInfo = obj as CamInfo;
            int c = int.Parse(Ipaddress.Split('.')[3]);
            int c1 = int.Parse(camInfo.Ipaddress.Split('.')[3]);
            if (c>c1)
            { return 1; }
            else
            { return -1; }
        }
    }
}
