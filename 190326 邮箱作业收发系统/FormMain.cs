using System;
using EmailHomeworkSystem.Controller;
using System.Windows.Forms;
using EmailHomeworkSystem.Properties;
using EmailHomeworkSystem.Database;
using System.Drawing;
using EmailHomeworkSystem.BaseLib;
using System.IO;

namespace EmailHomeworkSystem {
    public partial class FormMain : Form {
        public DBOptionHelper dboh;
        public FolderController folderController;
        public ListViewController listViewController;
        //public TreeViewController treeViewController;
        private bool mHideSeen = false;

        public FormMain() {
            InitializeComponent();
            InitializeLogSettings();
            InitializeController();
            InitializeSettings();
            comboListViewView.SelectedIndex = Settings.Default.ComboIndex;
        }

        //**************************初始化******************************

        /// <summary>
        /// 初始化控制器们
        /// </summary>
        private void InitializeController() {
            folderController = new FolderController();
            listViewController = new ListViewController(this.listView);
            //treeViewController = new TreeViewController(this);
        }
        /// <summary>
        /// 输出设置以便查看
        /// </summary>
        private void InitializeLogSettings() {
            Log.I(string.Format("FormMain.InitializeLogSettings: FolderPath={0}", Settings.Default.FolderPath));
            Log.I(string.Format("FormMain.InitializeLogSettings: FormMax={0}", Settings.Default.FormMax));
            Log.I(string.Format("FormMain.InitializeLogSettings: ComboIndex={0}", Settings.Default.ComboIndex));
        }
        /// <summary>
        /// 初始化已保存的配置
        /// </summary>
        private void InitializeSettings() {
            if(Settings.Default.FolderPath != "") {
                try {
                    DirectoryInfo dir = new DirectoryInfo(Settings.Default.FolderPath); //检查路径合法性
                    folderController.SetRoot(Settings.Default.FolderPath);
                    DBOptionHelper.Initialize(folderController.GetRoot());
                    listViewController.Import(folderController.GetRoot());
                    btnStu_Click(null, null);
                } catch (Exception ex) {
                    Log.E("FormMain.InitializeSettings: " + ex.Message);
                }
            }
        }

        //***************************界面点击事件****************************

        /// <summary>
        /// 返回键
        /// </summary>
        private void btnFolderBack_MouseUp(object sender, MouseEventArgs e) {
            if (folderController.GetRoot().StartsWith("group:\\")) {
                listViewController.Show(folderController.GoParentPath(), mHideSeen);
            } else {
                listViewController.Import(folderController.GoParentPath());
            }
            LabelPath.Text = folderController.GetFullPath();
            this.btnFolderBack.Enabled = folderController.IsRoot() ? false : true;
        }
        /// <summary>
        /// 刷新键
        /// </summary>
        private void btnFolderRefresh_Click(object sender, EventArgs e) {
            listViewController.Refresh();
        }
        /// <summary>
        /// 按学生分类
        /// </summary>
        /// 
        private void btnStu_Click(object sender, EventArgs e) {
            btnStu.BackColor = SystemColors.Menu;
            btnHmwk.BackColor = SystemColors.Window;
            folderController.SetRoot("group:\\sname");
            listViewController.Show("group:\\sname", mHideSeen);
            LabelPath.Text = folderController.GetFullPath();
        }
        /// <summary>
        /// 按作业分类
        /// </summary>
        private void btnHmwk_Click(object sender, EventArgs e) {
            btnStu.BackColor = SystemColors.Window;
            btnHmwk.BackColor = SystemColors.Menu;
            folderController.SetRoot("group:\\hno");
            listViewController.Show("group:\\hno", mHideSeen);
            LabelPath.Text = folderController.GetFullPath();
        }
        /// <summary>
        /// 仅查看未批改
        /// </summary>
        private void btnHaveNotRead_Click(object sender, EventArgs e) {
            if (btnHaveNotRead.Text.StartsWith("√")) {
                btnHaveNotRead.Enabled = false;
                mHideSeen = false;
                listViewController.RefreshHide(mHideSeen);
                btnHaveNotRead.Text = "仅查看未批改";
                btnHaveNotRead.Enabled = true;
            } else {
                btnHaveNotRead.Enabled = false;
                mHideSeen = true;
                listViewController.RefreshHide(mHideSeen);
                btnHaveNotRead.Text = "√ 仅查看未批改";
                btnHaveNotRead.Enabled = true;
            }
        }
        /// <summary>
        /// 查看成绩表
        /// </summary>
        private void btnOpenGrid_Click(object sender, EventArgs e) {
            FormGrid fg = new FormGrid(this);
            fg.Show(this);
        }
        /// <summary>
        /// 更改listView的View样式
        /// </summary>
        private void comboListViewView_SelectedIndexChanged(object sender, EventArgs e) {
            int index = comboListViewView.SelectedIndex;
            switch (index) {
                case 0:
                    listView.View = View.LargeIcon;
                    break;
                case 1:
                    listView.View = View.Details;
                    break;
                case 2:
                    listView.View = View.SmallIcon;
                    break;
                case 3:
                    listView.View = View.List;
                    break;
                case 4:
                    listView.View = View.Tile;
                    break;
            }
        }
        /// <summary>
        /// 双击listview中的item
        /// </summary>
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ListViewHitTestInfo info = listView.HitTest(e.X, e.Y);
            if (info.Item != null) {
                ListViewItem item = info.Item;
                if (item.ImageIndex == 0) { //如果是文件夹
                    if (item.SubItems[4].Text.StartsWith("group:\\")) {
                        //分类展示
                        string childpath = folderController.GoChildPath(item.SubItems[4].Text.Replace(folderController.GetFullPath() + "\\", ""));
                        LabelPath.Text = childpath;
                        listViewController.Show(childpath, mHideSeen);
                    } else if (item.SubItems[4].Text.StartsWith("project:\\")) {
                        //打开项目
                        FormCodeView formCV = new FormCodeView(this);
                        formCV.LoadHmwk(listViewController.stuDict[item.SubItems[1].Text][item.SubItems[2].Text]);
                        formCV.OpenFolder(item.SubItems[4].Text.Replace("project:\\", ""));
                        formCV.Show(this);
                    } else {
                        //仅仅打开目录
                        string childpath = folderController.GoChildPath(item.Text);
                        LabelPath.Text = childpath;
                        listViewController.Import(childpath);
                    }
                } else { //如果是文件
                    FormCodeView formCV = new FormCodeView(this);
                    formCV.OpenFolder(folderController.GetFullPath());
                    formCV.OpenFile(item.Text);
                    formCV.Show(this);
                }
                this.btnFolderBack.Enabled = folderController.IsRoot() ? false : true;
            }
        }
        
        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e) {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                folderController.SetRoot(folderBrowserDialog.SelectedPath);
                DBOptionHelper.Initialize(folderController.GetRoot());
                listViewController.Import(folderController.GetFullPath());
                Settings.Default.FolderPath = folderController.GetRoot();
                Settings.Default.Save();
                btnStu_Click(null, null);
            }
        }

        //***************************界面ui事件****************************

        private void btnFolderBack_MouseMove(object sender, MouseEventArgs e) {
            if(btnFolderBack.BackgroundImage != null)
                btnFolderBack.BackgroundImage.Dispose();
            btnFolderBack.BackgroundImage = Resources.folderback_press;
        }
        private void btnFolderBack_MouseLeave(object sender, EventArgs e) {
            if (btnFolderBack.BackgroundImage != null)
                btnFolderBack.BackgroundImage.Dispose();
            btnFolderBack.BackgroundImage = Resources.folderback;
        }
        private void btnFolderRefresh_MouseMove(object sender, MouseEventArgs e) {
            if (btnFolderRefresh.BackgroundImage != null)
                btnFolderRefresh.BackgroundImage.Dispose();
            btnFolderRefresh.BackgroundImage = Resources.folderrefresh_press;
        }
        private void btnFolderRefresh_MouseLeave(object sender, EventArgs e) {
            if (btnFolderRefresh.BackgroundImage != null)
                btnFolderRefresh.BackgroundImage.Dispose();
            btnFolderRefresh.BackgroundImage = Resources.folderrefresh;
        }

        private void FormMain_Load(object sender, EventArgs e) {
            if (Settings.Default.FormMax) {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// 关闭前
        /// </summary>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            Settings.Default.FormMax = this.WindowState == FormWindowState.Maximized ? true : false;
            Settings.Default.ComboIndex = comboListViewView.SelectedIndex;
            Settings.Default.Save();
        }
    }
}
