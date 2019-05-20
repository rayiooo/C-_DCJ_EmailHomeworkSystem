using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CppRunningHelper {
    public class Cmd {

        public static void CL(string folder, string arg) {
            string bat = "cl" + arg + Environment.NewLine + "pause";
            File.WriteAllText(folder + "\\run.bat", bat, Encoding.Default);
            ProcessStartInfo start = new ProcessStartInfo() {
                FileName = "run.bat",
                WorkingDirectory = folder,
            };
            using (Process p = Process.Start(start)) {
                p.WaitForExit();
            }
            return;
        }

        public static string CLold(string folder, string arg) {
            ProcessStartInfo start = new ProcessStartInfo {
                Arguments = arg,
                ErrorDialog = true,
                FileName = "cl.exe",
                //RedirectStandardOutput = true,
                UseShellExecute = true,
                WorkingDirectory = folder,
            };
            string output = "";
            using (Process p = Process.Start(start)) {
                //output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            return output;
        }
    }
}
