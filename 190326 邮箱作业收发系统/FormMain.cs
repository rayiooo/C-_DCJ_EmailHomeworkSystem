using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmailHomeworkSystem.Controller;
using System.Data;
using System.Windows.Forms;

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
    }
}
