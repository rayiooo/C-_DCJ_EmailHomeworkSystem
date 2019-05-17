using EmailHomeworkSystem.BaseLib;
using EmailHomeworkSystem.Controller;
using EmailHomeworkSystem.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace EmailHomeworkSystem {
    public partial class FormGrid : Form {
        private FormMain mFormMain;
        private Dictionary<string, int> colIndex;   //存储列名对应index
        private Dictionary<string, Dictionary<string, Hmwk>> hmwkDict; //存储按作业号分类的文件夹目录
        private Dictionary<string, Dictionary<string, Hmwk>> stuDict; //存储按学生姓名分类的文件夹目录

        //-------------初始化-------------
        public FormGrid(FormMain formMain) {
            mFormMain = formMain;
            //设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.grid.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.grid, true, null);

            //InitializeComponent();
            InitializeGrid();
        }
        
        private void InitializeGrid() {
            hmwkDict = mFormMain.listViewController.hmwkDict;
            stuDict = mFormMain.listViewController.stuDict;
            colIndex = new Dictionary<string, int>();
            int i = 0;

            //添加列
            grid.Columns.Add("sno", "学号");
            colIndex.Add("sno", i++);
            grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns.Add("sname", "姓名");
            colIndex.Add("sname", i++);
            foreach (string str in hmwkDict.Keys) {
                grid.Columns.Add(str, str);
                colIndex.Add(str, i++);
            }
            grid.Columns.Add("average", "平均分");
            colIndex.Add("average", i++);
            //添加行
            foreach (string str in stuDict.Keys) {
                string sno = string.Empty;
                foreach (string str2 in stuDict[str].Keys) {
                    sno = stuDict[str][str2].Sno;
                    break;
                }
                grid.Rows.Add(sno, str);
            }
            //填充数据
            foreach (DataGridViewRow row in grid.Rows) {
                string sname = (string) row.Cells[colIndex["sname"]].Value;
                if (sname == null || !stuDict.ContainsKey(sname))
                    continue;
                foreach (string key in stuDict[sname].Keys) {
                    int score = stuDict[sname][key].Score;
                    string key2 = key.Split('-')[0];
                    if (score >= 0) {
                        try {
                            int oldscore = (int)(row.Cells[key2].Value ?? 0);
                            row.Cells[colIndex[key2]].Value = Math.Max(oldscore, score);
                        } catch (Exception) {
                            row.Cells[colIndex[key2]].Value = score;
                        }
                    } else if (score == -1) {
                        if (row.Cells[colIndex[key2]].Value == null)
                            row.Cells[colIndex[key2]].Value = "未批阅";
                    } else if (score == -2) {
                        if (row.Cells[colIndex[key2]].Value == null) {
                            row.Cells[colIndex[key2]].Value = "没交作业";
                            row.Cells[colIndex[key2]].Style.ForeColor = Color.Red;
                        }
                    }
                }
                int sum = 0;
                foreach (string hno in hmwkDict.Keys) {
                    if (row.Cells[colIndex[hno]].Value == null) {
                        row.Cells[colIndex[hno]].Value = "没交作业";
                        row.Cells[colIndex[hno]].Style.ForeColor = Color.Red;
                    }
                    //为了良好的视觉效果，不显示未批阅
                    else if (row.Cells[colIndex[hno]].Value.GetType() == typeof(string) && (string)row.Cells[colIndex[hno]].Value == "未批阅")
                        row.Cells[colIndex[hno]].Value = null;
                    else if (row.Cells[colIndex[hno]].Value.GetType() == typeof(int)) {
                        sum += (int)row.Cells[colIndex[hno]].Value;
                        row.Cells[colIndex[hno]].Value = row.Cells[colIndex[hno]].Value.ToString();
                    }
                }
                row.Cells[colIndex["average"]].Value = double.Parse(((double)sum / hmwkDict.Keys.Count).ToString("0.00"));
            }
        }
        
        //--------------事件---------------
        private void FormGrid_Load(object sender, EventArgs e) {
            Icon = Resources.homework;
            if (Settings.Default.FormMax) {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
