using System;
using EmailHomeworkSystem.Controller;
using System.Windows.Forms;
using EmailHomeworkSystem.Properties;

namespace EmailHomeworkSystem {
    public partial class FormMain : Form {
        public FolderController folderController;
        public ListViewController listViewController;
        public TreeViewController treeViewController;

        public FormMain() {
            InitializeComponent();
            InitializeController();
            InitializeSettings();
        }

        //**************************初始化******************************

        /// <summary>
        /// 初始化控制器们
        /// </summary>
        private void InitializeController() {
            folderController = new FolderController();
            listViewController = new ListViewController(this.listView);
            treeViewController = new TreeViewController(this);
        }
        /// <summary>
        /// 初始化已保存的配置
        /// </summary>
        private void InitializeSettings() {
            if(Settings.Default.FolderPath != "") {
                folderController.SetRoot(Settings.Default.FolderPath);
                listViewController.Import(folderController.GetFullPath());
            }
        }



        //***************************界面点击事件****************************
        
        private void btnFolderBack_MouseUp(object sender, MouseEventArgs e) {
            listViewController.Import(folderController.GoParentPath());
            this.btnFolderBack.Enabled = folderController.IsRoot() ? false : true;
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ListViewHitTestInfo info = listView.HitTest(e.X, e.Y);
            if (info.Item != null) {
                ListViewItem item = info.Item;
                if (item.ImageIndex == 0) { //如果是文件夹
                    listViewController.Import(folderController.GoChildPath(item.Text));
                } else { //如果是文件
                    FormCodeView formCV = new FormCodeView();
                    formCV.OpenFolder(folderController.GetFullPath());
                    formCV.OpenFile(item.Text);
                    formCV.Show(this);
                }
                this.btnFolderBack.Enabled = folderController.IsRoot() ? false : true;
            }
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e) {
            Form settingsForm = new FormSettings();
            settingsForm.Show(this);
        }
        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e) {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                folderController.SetRoot(folderBrowserDialog.SelectedPath);
                listViewController.Import(folderController.GetFullPath());
                Settings.Default.FolderPath = folderController.GetRoot();
                Settings.Default.Save();
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
        private void btnFolderForward_MouseMove(object sender, MouseEventArgs e) {
            if (btnFolderForward.BackgroundImage != null)
                btnFolderForward.BackgroundImage.Dispose();
            btnFolderForward.BackgroundImage = Resources.folderforward_press;
        }
        private void btnFolderForward_MouseLeave(object sender, EventArgs e) {
            if (btnFolderForward.BackgroundImage != null)
                btnFolderForward.BackgroundImage.Dispose();
            btnFolderForward.BackgroundImage = Resources.folderforward;
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

    }
}
