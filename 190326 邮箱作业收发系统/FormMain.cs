using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmailHomeworkSystem.Controller;
using System.Data;
using System.Windows.Forms;

namespace EmailHomeworkSystem {
    public partial class FormMain : Form {
        private TreeViewController treeViewController;

        public FormMain() {
            InitializeComponent();
            InitializeController();
        }

        private void InitializeController() {
            this.treeViewController = new TreeViewController(this);
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e) {
            Form settingsForm = new FormSettings();
            settingsForm.Show(this);
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e) {
            if(this.folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                string folderPath = folderBrowserDialog.SelectedPath;
                this.treeViewController.Import(folderPath);
            }
        }
    }
}
