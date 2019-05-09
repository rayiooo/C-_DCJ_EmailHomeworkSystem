using EmailHomeworkSystem.BaseLib;
using EmailHomeworkSystem.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EmailHomeworkSystem.Controller {
    public class ListViewController {
        private bool haveSearchedChildAndGroup;
        private string _folder;
        private ListView lv;
        public Dictionary<string, List<Hmwk>> hmwkDict = new Dictionary<string, List<Hmwk>>(); //存储按作业号分类的文件夹目录
        public Dictionary<string, List<Hmwk>> stuDict = new Dictionary<string, List<Hmwk>>(); //存储按学生姓名分类的文件夹目录

        public ListViewController(ListView lv) {
            this.lv = lv;
            this.haveSearchedChildAndGroup = false;
            //设置列头
            ColumnHeader[] chs = new ColumnHeader[] {
                new ColumnHeader() {
                    Text = "Title",
                    Name = "Title",
                    Width = 200,
                },
                new ColumnHeader() {
                    Text = "Name",
                    Name = "Name",
                    Width = 100,
                },
                new ColumnHeader() {
                    Text = "Homework",
                    Name = "Homework",
                    Width = 100,
                },
                new ColumnHeader() {
                    Text = "Score",
                    Name = "Score",
                    Width = 100,
                },
                new ColumnHeader() {
                    Text = "Path",
                    Name = "Path",
                    Width = 300,
                },
            };
            lv.Columns.AddRange(chs);
        }
        
        /// <summary>
        /// 将路径下的文件和文件夹显示在listView中
        /// </summary>
        /// <param name="folderPath">目录全名</param>
        public void Import(string folder, bool backItem = false) {
            this._folder = folder;
            Log.D(string.Format("当前目录：{0}", folder));
            lv.BeginUpdate();
            lv.Items.Clear();
            if (backItem) {
                lv.Items.Add(new ListViewItem("..", 0));
            }
            DirectoryInfo info = new DirectoryInfo(folder);
            if (info.Exists) {
                foreach (DirectoryInfo dir in info.GetDirectories()) {
                    ListViewItem item = new ListViewItem(new string[] { dir.Name , "", "", "", dir.FullName}, 0);
                    lv.Items.Add(item);
                }
                foreach (FileInfo file in info.GetFiles()) {
                    ListViewItem item = new ListViewItem(new string[] { file.Name , "", "", "", file.FullName});
                    if (file.Name.EndsWith(".cpp")) {
                        item.ImageIndex = 1;
                    } else if (file.Name.EndsWith(".h")) {
                        item.ImageIndex = 2;
                    } else if (file.Name.EndsWith(".rar")) {
                        item.ImageIndex = 4;
                    } else if (file.Name.EndsWith(".txt")) {
                        item.ImageIndex = 5;
                    } else if (file.Name.EndsWith(".zip")) {
                        item.ImageIndex = 6;
                    } else if (file.Name.EndsWith(".obj") || file.Name.EndsWith(".exe") || file.Name.Equals("ut")) {
                        continue;
                    } else {
                        item.ImageIndex = 3;
                    }
                    lv.Items.Add(item);
                }
            }
            lv.EndUpdate();
        }

        /// <summary>
        /// 搜索子文件夹并分类存储至HashMap
        /// </summary>
        public void SearchChildAndGroup() {
            DirectoryInfo rootInfo = new DirectoryInfo(_folder);
            foreach(DirectoryInfo i in rootInfo.GetDirectories()) { //按姓名
                string sname = Base.GetChinese(i.Name);
                foreach (DirectoryInfo j in i.GetDirectories()) { //按作业
                    Hmwk homework = new Hmwk(sname, j.Name, j);
                    if (!stuDict.ContainsKey(sname)) {
                        stuDict.Add(sname, new List<Hmwk>());
                    }
                    if (!hmwkDict.ContainsKey(j.Name)) {
                        hmwkDict.Add(j.Name, new List<Hmwk>());
                    }
                    stuDict[sname].Add(homework);
                    hmwkDict[j.Name].Add(homework);
                }
            }
            haveSearchedChildAndGroup = true;
        }

        /// <summary>
        /// 按分类路径展示出来
        /// </summary>
        /// <param name="path"></param>
        /// <param name="hideSeen">TODO</param>
        public void Show(string path = "group:\\sname", bool hideSeen = false) {
            if (!path.StartsWith("group:\\")) {
                Log.W("路径格式错误！必须以“group:\\”格式开头。");
                return;
            }
            if (!haveSearchedChildAndGroup) {
                SearchChildAndGroup();
            }

            Log.D(string.Format("当前目录：{0}", path));
            //开始刷新lv
            lv.BeginUpdate();
            lv.Items.Clear();
            //解析目录
            string[] menu = path.Replace("group:\\", "").Split('\\');
            if (menu[0] == "sname") {
                if (menu.Length == 1) {
                    foreach(string str in stuDict.Keys) { //按学生分类
                        var item = new ListViewItem(new string[] {
                            str,
                            str,
                            "",
                            "",
                            path + "\\" + str
                        }, 0);
                        lv.Items.Add(item);
                    }
                } else if (menu.Length == 2) {
                    foreach(Hmwk h in stuDict[menu[1]]) { //按学生分类二级目录
                        var item = new ListViewItem(new string[] {
                            h.Hno,
                            h.Sname,
                            h.Hno,
                            h.Score == -1 ? "" : h.Score.ToString(),
                            "project:\\" + h.Dir.FullName
                        }, 0);
                        lv.Items.Add(item);
                    }
                }
            } else if (menu[0] == "hno") {
                if (menu.Length == 1) { //按作业号分类
                    foreach (string str in hmwkDict.Keys) {
                        var item = new ListViewItem(new string[] {
                            str,
                            "",
                            str,
                            "",
                            path + "\\" + str
                        }, 0);
                        lv.Items.Add(item);
                    }
                } else if (menu.Length == 2) {
                    foreach (Hmwk h in hmwkDict[menu[1]]) { //按作业号分类二级目录
                        var item = new ListViewItem(new string[] {
                            h.Sname,
                            h.Sname,
                            h.Hno,
                            h.Score == -1 ? "" : h.Score.ToString(),
                            "project:\\" + h.Dir.FullName
                        }, 0);
                        lv.Items.Add(item);
                    }
                }
            } else {
                throw new Exception("Wrong group path : " + path);
            }
            lv.EndUpdate();
        }
    }

    public class Hmwk {
        public int Score { get; set; }
        public string Hno { get; set; }
        public string Sname { get; set; }
        public DirectoryInfo Dir { get; set; }

        public Hmwk(string name, string hno, DirectoryInfo dir) {
            this.Hno = hno;
            this.Sname = name;
            this.Dir = dir;
            this.Score = DBOptionHelper.GetScore(Sname, Hno);
        }
    }
}
