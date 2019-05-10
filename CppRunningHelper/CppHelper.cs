using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace CppRunningHelper {
    public static class CppHelper{
        /// <summary>
        /// 获取目录下的唯一exe可执行文件，如果没有或则返回null
        /// </summary>
        private static FileInfo _GetExeFile(string folder) {
            try {
                DirectoryInfo info = new DirectoryInfo(folder);
                List<FileInfo> files = new List<FileInfo>();
                foreach (FileInfo file in info.GetFiles()) {
                    if (file.Name.EndsWith(".exe")) {
                        files.Add(file);
                    }
                }
                if (files.Count != 1) {
                    Console.WriteLine("exe文件缺失或超过1个！");
                    return null;
                }
                return files[0];
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 清理编译出现的程序
        /// </summary>
        public static bool Clean(string folder) {
            try {
                DirectoryInfo info = new DirectoryInfo(folder);
                foreach(FileInfo file in info.GetFiles()) {
                    if(file.Name.EndsWith(".obj") || file.Name.EndsWith(".exe")) {
                        //获得该文件的访问权限
                        FileSecurity fileSecurity = file.GetAccessControl();
                        //添加ereryone用户组的访问权限规则 完全控制权限
                        fileSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                        //添加Users用户组的访问权限规则 完全控制权限
                        fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
                        //设置访问权限
                        file.SetAccessControl(fileSecurity);
                        //删除文件
                        File.Delete(file.FullName);
                    }
                }
                return true;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 编译目录下所有cpp文件
        /// </summary>
        public static bool Compile(string folder) {
            //如果已编译过最新版则不编译
            FileInfo exe = _GetExeFile(folder);
            if(exe != null) {
                DateTime t = exe.LastWriteTime;
                bool isNew = true;
                foreach (FileInfo file in new DirectoryInfo(folder).GetFiles()) {
                    if(file.Name.EndsWith(".cpp") || file.Name.EndsWith(".h")) {
                        DateTime t2 = file.LastWriteTime;
                        if(t2 > t) {
                            isNew = false;
                            break;
                        }
                    }
                }
                if (isNew) {
                    return true;
                }
            }

            //如果未编译最新则编译之
            try {
                //获取cpp文件们名称
                DirectoryInfo info = new DirectoryInfo(folder);
                List<string> files = new List<string>();
                foreach (FileInfo file in info.GetFiles()) {
                    if (file.Name.EndsWith(".cpp")) {
                        files.Add(file.Name);
                    }
                }
                //构建cl命令行命令并cmd执行
                StringBuilder sb = new StringBuilder();
                sb.Append("/EHsc");
                foreach (string str in files) {
                    sb.Append(" ");
                    sb.Append(str);
                }
                Cmd.CL(folder, sb.ToString());
                return true;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 运行文件夹下编译好的程序
        /// </summary>
        public static bool Run(string folder) {
            FileInfo file = _GetExeFile(folder);
            if(file != null) {
                string bat = file.Name + Environment.NewLine + "pause";
                File.WriteAllText(file.DirectoryName + "\\run.bat", bat);
                ProcessStartInfo start = new ProcessStartInfo() {
                    FileName = file.DirectoryName + "\\run.bat",
                    WorkingDirectory = file.DirectoryName,
                };
                Process p = Process.Start(start);
                return true;
            }
            return false;
        }
    }
}
