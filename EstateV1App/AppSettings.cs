using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateV1App
{
    public class AppSettings
    {
        public static string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5299/" : "http://localhost:5299/";
        //public static string ApiUrl = "https://127.0.0.1:7020/";
        //public static string ApiUrl = "https://192.168.0.45:7020/";
    }
}
