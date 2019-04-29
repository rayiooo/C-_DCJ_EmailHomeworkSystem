using System;
using System.Diagnostics;

namespace CppRunningHelper {
    public class Cmd {
        public static string Cl(string folder, string arg) {
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
