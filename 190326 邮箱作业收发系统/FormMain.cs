using System;
using EmailHomeworkSystem.Controller;
using System.Windows.Forms;
using EmailHomeworkSystem.Properties;
using System.Drawing;

namespace EmailHomeworkSystem {
    public partial class FormMain : Form {
        private ListViewController listViewController;
        private TreeViewController treeViewController;

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
            treeViewController = new TreeViewController(this);
            listViewController = new ListViewController(this);
            listViewController.test(); //test
        }
        /// <summary>
        /// 初始化已保存的配置
        /// </summary>
        private void InitializeSettings() {
            if(Settings.Default.FolderPath != "") {
                treeViewController.Import(Settings.Default.FolderPath);
            }
        }



        //***************************界面事件****************************

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e) {
            Form settingsForm = new FormSettings();
            settingsForm.Show(this);
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e) {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                string folderPath = folderBrowserDialog.SelectedPath;
                treeViewController.Import(folderPath);
                Settings.Default.FolderPath = folderPath;
                Settings.Default.Save();
            }
        }

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
