namespace EmailHomeworkSystem {
    partial class FormCodeView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCodeView));
            this.fileIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.codeEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBtnSave = new System.Windows.Forms.ToolStripButton();
            this.TSBtnRun = new System.Windows.Forms.ToolStripButton();
            this.TSBtnSetScore = new System.Windows.Forms.ToolStripButton();
            this.fileListView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileIconImageList
            // 
            this.fileIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileIconImageList.ImageStream")));
            this.fileIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileIconImageList.Images.SetKeyName(0, "folder.png");
            this.fileIconImageList.Images.SetKeyName(1, "icon_cpp.png");
            this.fileIconImageList.Images.SetKeyName(2, "icon_h.png");
            this.fileIconImageList.Images.SetKeyName(3, "icon_nani.png");
            this.fileIconImageList.Images.SetKeyName(4, "icon_rar.png");
            this.fileIconImageList.Images.SetKeyName(5, "icon_txt.png");
            this.fileIconImageList.Images.SetKeyName(6, "icon_zip.png");
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33333F));
            this.tableLayoutPanel3.Controls.Add(this.codeEditor, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.fileListView, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1071, 670);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // codeEditor
            // 
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.IsReadOnly = false;
            this.codeEditor.Location = new System.Drawing.Point(181, 34);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(887, 633);
            this.codeEditor.TabIndex = 8;
            this.codeEditor.TextChanged += new System.EventHandler(this.textEditor_TextChanged);
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBtnSave,
            this.TSBtnRun,
            this.TSBtnSetScore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(228, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBtnSave
            // 
            this.TSBtnSave.Image = global::EmailHomeworkSystem.Properties.Resources.save;
            this.TSBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnSave.Name = "TSBtnSave";
            this.TSBtnSave.Size = new System.Drawing.Size(67, 28);
            this.TSBtnSave.Text = "保存";
            this.TSBtnSave.Click += new System.EventHandler(this.TSBtnSave_Click);
            // 
            // TSBtnRun
            // 
            this.TSBtnRun.Image = global::EmailHomeworkSystem.Properties.Resources.run;
            this.TSBtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnRun.Name = "TSBtnRun";
            this.TSBtnRun.Padding = new System.Windows.Forms.Padding(0, 0, 9, 0);
            this.TSBtnRun.Size = new System.Drawing.Size(76, 28);
            this.TSBtnRun.Text = "运行";
            this.TSBtnRun.Click += new System.EventHandler(this.TSBtnRun_Click);
            // 
            // TSBtnSetScore
            // 
            this.TSBtnSetScore.Image = global::EmailHomeworkSystem.Properties.Resources.setscore;
            this.TSBtnSetScore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnSetScore.Name = "TSBtnSetScore";
            this.TSBtnSetScore.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.TSBtnSetScore.Size = new System.Drawing.Size(73, 28);
            this.TSBtnSetScore.Text = "评分";
            this.TSBtnSetScore.Click += new System.EventHandler(this.TSBtnSetScore_Click);
            // 
            // fileListView
            // 
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.Location = new System.Drawing.Point(3, 34);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(172, 633);
            this.fileListView.SmallImageList = this.fileIconImageList;
            this.fileListView.TabIndex = 4;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.SmallIcon;
            this.fileListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileListView_MouseDoubleClick);
            // 
            // FormCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 670);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "FormCodeView";
            this.Text = "FormCodeView";
            this.Load += new System.EventHandler(this.FormCodeView_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ImageList fileIconImageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSBtnSave;
        private System.Windows.Forms.ToolStripButton TSBtnRun;
        private System.Windows.Forms.ToolStripButton TSBtnSetScore;
        private System.Windows.Forms.ListView fileListView;
        private ICSharpCode.TextEditor.TextEditorControl codeEditor;
    }
}