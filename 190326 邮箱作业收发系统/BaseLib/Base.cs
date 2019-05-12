using System;
using System.Net.NetworkInformation;
using System.Text;

namespace EmailHomeworkSystem.BaseLib {
    class Base {

        /// <summary>
        /// 转中文简体
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertSimplifiedChinese(string str) {
            return Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);
        }
        /// <summary>
        /// 转中文繁体
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertTraditionalChinese(string str) {
            return Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0); ;
        }

        /// <summary>
        /// 转GB2312至UTF-8
        /// </summary>
        public static string ConvertGB2312_UTF8(string str) {
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            byte[] bs = gb2312.GetBytes(str);
            bs = Encoding.Convert(gb2312, utf8, bs);
            return utf8.GetString(bs);
        }

        /// <summary>
        /// 转UTF-8至GB2312
        /// </summary>
        public static string ConvertUTF8_GB2312(string str) {
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            byte[] bs = utf8.GetBytes(str);
            bs = Encoding.Convert(utf8, gb2312, bs);
            return gb2312.GetString(bs);
        }

        /// <summary>
        /// 提取字符串中的中文
        /// </summary>
        public static string GetChinese(string str) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str.ToCharArray()) {
                if (c >= 0x4e00 && c <= 0x9fa5) {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string GetCurrentTime() {
            return DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetMac() {
            try {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces) {
                    string mac = BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                    Log.D("Base.GetMac.mac: " + mac);
                    return mac;
                }
            } catch (Exception) {
                Log.E("Mac address not found.");
            }
            return "00-00-00-00-00-00";
        }

        public static string GetTimeStamp() {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;
            return timeStamp.ToString();
        }

        public static string MD5(string str) {
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
