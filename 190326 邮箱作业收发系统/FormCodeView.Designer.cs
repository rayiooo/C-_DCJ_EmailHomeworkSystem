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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRun = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.codeEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.fileListView = new System.Windows.Forms.ListView();
            this.fileIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1071, 670);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 999F));
            this.tableLayoutPanel2.Controls.Add(this.btnRun, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1071, 42);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.BackgroundImage = global::EmailHomeworkSystem.Properties.Resources.run;
            this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Location = new System.Drawing.Point(45, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(36, 34);
            this.btnRun.TabIndex = 1;
            this.btnRun.TabStop = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            this.btnRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRun_MouseDown);
            this.btnRun.MouseLeave += new System.EventHandler(this.btnRun_MouseLeave);
            this.btnRun.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRun_MouseMove);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::EmailHomeworkSystem.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseDown);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            this.btnSave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseMove);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel3.Controls.Add(this.codeEditor, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.fileListView, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1065, 622);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // codeEditor
            // 
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.IsReadOnly = false;
            this.codeEditor.Location = new System.Drawing.Point(177, 0);
            this.codeEditor.Margin = new System.Windows.Forms.Padding(0);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(888, 622);
            this.codeEditor.TabIndex = 3;
            this.codeEditor.Text = "#include <iostream>;\r\nusing namespace std;\r\nint main(){\r\n    cout << \"hello world" +
    "!\" << endl;\r\n}";
            // 
            // fileListView
            // 
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.Location = new System.Drawing.Point(3, 3);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(171, 616);
            this.fileListView.SmallImageList = this.fileIconImageList;
            this.fileListView.TabIndex = 4;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.SmallIcon;
            this.fileListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileListView_MouseDoubleClick);
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
            // FormCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 670);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCodeView";
            this.Text = "FormCodeView";
            this.Load += new System.EventHandler(this.FormCodeView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox btnRun;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ICSharpCode.TextEditor.TextEditorControl codeEditor;
        private System.Windows.Forms.ListView fileListView;
        public System.Windows.Forms.ImageList fileIconImageList;
    }
}