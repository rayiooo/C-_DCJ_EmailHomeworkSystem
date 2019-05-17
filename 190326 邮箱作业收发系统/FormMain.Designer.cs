namespace EmailHomeworkSystem {
    partial class FormMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenGrid = new System.Windows.Forms.Button();
            this.btnHaveNotRead = new System.Windows.Forms.Button();
            this.btnHmwk = new System.Windows.Forms.Button();
            this.btnStu = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView = new System.Windows.Forms.ListView();
            this.fileIconImageList64 = new System.Windows.Forms.ImageList(this.components);
            this.fileIconImageList32 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFolderRefresh = new System.Windows.Forms.PictureBox();
            this.btnFolderBack = new System.Windows.Forms.PictureBox();
            this.LabelPath = new System.Windows.Forms.Label();
            this.comboListViewView = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFolderRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFolderBack)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1071, 28);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip2";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1071, 642);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnOpenGrid, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.btnHaveNotRead, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnHmwk, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnStu, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 12;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(179, 642);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnOpenGrid
            // 
            this.btnOpenGrid.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpenGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenGrid.Location = new System.Drawing.Point(3, 586);
            this.btnOpenGrid.Name = "btnOpenGrid";
            this.btnOpenGrid.Size = new System.Drawing.Size(173, 53);
            this.btnOpenGrid.TabIndex = 3;
            this.btnOpenGrid.Text = "查看成绩表";
            this.btnOpenGrid.UseVisualStyleBackColor = false;
            this.btnOpenGrid.Click += new System.EventHandler(this.btnOpenGrid_Click);
            // 
            // btnHaveNotRead
            // 
            this.btnHaveNotRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHaveNotRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHaveNotRead.Location = new System.Drawing.Point(3, 109);
            this.btnHaveNotRead.Name = "btnHaveNotRead";
            this.btnHaveNotRead.Size = new System.Drawing.Size(173, 47);
            this.btnHaveNotRead.TabIndex = 2;
            this.btnHaveNotRead.Text = "仅查看未批改";
            this.btnHaveNotRead.UseVisualStyleBackColor = true;
            this.btnHaveNotRead.Click += new System.EventHandler(this.btnHaveNotRead_Click);
            // 
            // btnHmwk
            // 
            this.btnHmwk.BackColor = System.Drawing.SystemColors.Window;
            this.btnHmwk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHmwk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHmwk.Location = new System.Drawing.Point(3, 56);
            this.btnHmwk.Name = "btnHmwk";
            this.btnHmwk.Size = new System.Drawing.Size(173, 47);
            this.btnHmwk.TabIndex = 1;
            this.btnHmwk.Text = "按作业分类";
            this.btnHmwk.UseVisualStyleBackColor = false;
            this.btnHmwk.Click += new System.EventHandler(this.btnHmwk_Click);
            // 
            // btnStu
            // 
            this.btnStu.BackColor = System.Drawing.SystemColors.Window;
            this.btnStu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStu.Location = new System.Drawing.Point(3, 3);
            this.btnStu.Name = "btnStu";
            this.btnStu.Size = new System.Drawing.Size(173, 47);
            this.btnStu.TabIndex = 0;
            this.btnStu.Text = "按学生分类";
            this.btnStu.UseVisualStyleBackColor = false;
            this.btnStu.Click += new System.EventHandler(this.btnStu_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 642);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.LargeImageList = this.fileIconImageList64;
            this.listView.Location = new System.Drawing.Point(0, 53);
            this.listView.Margin = new System.Windows.Forms.Padding(0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(888, 589);
            this.listView.SmallImageList = this.fileIconImageList32;
            this.listView.TabIndex = 25;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // fileIconImageList64
            // 
            this.fileIconImageList64.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileIconImageList64.ImageStream")));
            this.fileIconImageList64.TransparentColor = System.Drawing.Color.Transparent;
            this.fileIconImageList64.Images.SetKeyName(0, "folder.png");
            this.fileIconImageList64.Images.SetKeyName(1, "icon_cpp.png");
            this.fileIconImageList64.Images.SetKeyName(2, "icon_h.png");
            this.fileIconImageList64.Images.SetKeyName(3, "icon_nani.png");
            this.fileIconImageList64.Images.SetKeyName(4, "icon_rar.png");
            this.fileIconImageList64.Images.SetKeyName(5, "icon_txt.png");
            this.fileIconImageList64.Images.SetKeyName(6, "icon_zip.png");
            // 
            // fileIconImageList32
            // 
            this.fileIconImageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileIconImageList32.ImageStream")));
            this.fileIconImageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.fileIconImageList32.Images.SetKeyName(0, "folder.png");
            this.fileIconImageList32.Images.SetKeyName(1, "icon_cpp.png");
            this.fileIconImageList32.Images.SetKeyName(2, "icon_h.png");
            this.fileIconImageList32.Images.SetKeyName(3, "icon_nani.png");
            this.fileIconImageList32.Images.SetKeyName(4, "icon_rar.png");
            this.fileIconImageList32.Images.SetKeyName(5, "icon_txt.png");
            this.fileIconImageList32.Images.SetKeyName(6, "icon_zip.png");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnFolderRefresh, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFolderBack, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LabelPath, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboListViewView, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(888, 53);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // btnFolderRefresh
            // 
            this.btnFolderRefresh.BackgroundImage = global::EmailHomeworkSystem.Properties.Resources.folderrefresh;
            this.btnFolderRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFolderRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolderRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFolderRefresh.Location = new System.Drawing.Point(50, 3);
            this.btnFolderRefresh.Name = "btnFolderRefresh";
            this.btnFolderRefresh.Size = new System.Drawing.Size(41, 47);
            this.btnFolderRefresh.TabIndex = 2;
            this.btnFolderRefresh.TabStop = false;
            this.btnFolderRefresh.Click += new System.EventHandler(this.btnFolderRefresh_Click);
            this.btnFolderRefresh.MouseLeave += new System.EventHandler(this.btnFolderRefresh_MouseLeave);
            this.btnFolderRefresh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFolderRefresh_MouseMove);
            // 
            // btnFolderBack
            // 
            this.btnFolderBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnFolderBack.BackgroundImage = global::EmailHomeworkSystem.Properties.Resources.folderback;
            this.btnFolderBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFolderBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolderBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFolderBack.Enabled = false;
            this.btnFolderBack.Location = new System.Drawing.Point(3, 3);
            this.btnFolderBack.Name = "btnFolderBack";
            this.btnFolderBack.Size = new System.Drawing.Size(41, 47);
            this.btnFolderBack.TabIndex = 0;
            this.btnFolderBack.TabStop = false;
            this.btnFolderBack.MouseLeave += new System.EventHandler(this.btnFolderBack_MouseLeave);
            this.btnFolderBack.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFolderBack_MouseMove);
            this.btnFolderBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFolderBack_MouseUp);
            // 
            // LabelPath
            // 
            this.LabelPath.AutoSize = true;
            this.LabelPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelPath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelPath.Location = new System.Drawing.Point(97, 0);
            this.LabelPath.Name = "LabelPath";
            this.LabelPath.Size = new System.Drawing.Size(552, 53);
            this.LabelPath.TabIndex = 8;
            this.LabelPath.Text = "path:\\hello\\world";
            this.LabelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListViewView
            // 
            this.comboListViewView.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboListViewView.FormattingEnabled = true;
            this.comboListViewView.Items.AddRange(new object[] {
            "大图标",
            "详细信息",
            "小图标",
            "列表",
            "Tile"});
            this.comboListViewView.Location = new System.Drawing.Point(754, 14);
            this.comboListViewView.Margin = new System.Windows.Forms.Padding(14);
            this.comboListViewView.Name = "comboListViewView";
            this.comboListViewView.Size = new System.Drawing.Size(120, 26);
            this.comboListViewView.TabIndex = 9;
            this.comboListViewView.SelectedIndexChanged += new System.EventHandler(this.comboListViewView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(655, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 53);
            this.label1.TabIndex = 10;
            this.label1.Text = "图标样式：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 670);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "作业系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFolderRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFolderBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ImageList fileIconImageList64;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.PictureBox btnFolderRefresh;
        public System.Windows.Forms.PictureBox btnFolderBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnHmwk;
        private System.Windows.Forms.Button btnStu;
        private System.Windows.Forms.Button btnHaveNotRead;
        private System.Windows.Forms.Label LabelPath;
        private System.Windows.Forms.Button btnOpenGrid;
        private System.Windows.Forms.ComboBox comboListViewView;
        public System.Windows.Forms.ImageList fileIconImageList32;
        private System.Windows.Forms.Label label1;
    }
}

