using CppRunningHelper;
using EmailHomeworkSystem.Controller;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EmailHomeworkSystem {
    public partial class FormCodeView : Form {
        public FolderController folderController;
        public FormMain mFormMain;
        public ListViewController listViewController;
        private FileInfo _fileinfo;
        private Hmwk mHmwk;

        public FormCodeView(FormMain formMain) {
            mFormMain = formMain;
            InitializeComponent();
            InitializeUI();
            InitializeController();
        }

        //----------------------------初始化操作----------------------------

        private void InitializeController() {
            folderController = new FolderController();
            listViewController = new ListViewController(this.fileListView);
        }

        private void InitializeUI() {
            codeEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C++.NET");
            codeEditor.Encoding = Encoding.Default;
            codeEditor.Document.FoldingManager.FoldingStrategy = new CppFolding();
        }

        //----------------------------功能操作----------------------------

        public void LoadHmwk(Hmwk hmwk) {
            mHmwk = hmwk;
        }

        /// <summary>
        /// 打开一个文件并展示在codeEditor中
        /// </summary>
        public void OpenFile(string fileName) {
            string fileFullPath = folderController.GetChildFullPath(fileName);
            this.Text = fileFullPath;
            _fileinfo = new FileInfo(fileFullPath);
            codeEditor.Text = File.ReadAllText(fileFullPath, Encoding.Default);
            codeEditor.Refresh(); //如果不刷新，可能会导致旧文本没有擦干净
            //textEditor.Text = FormatCode(textEditor.Text); //格式化代码
        }

        /// <summary>
        /// 选定一个目录作为项目根目录，加载到编辑器中
        /// </summary>
        /// <param name="fullPath"></param>
        public void OpenFolder(string fullPath) {
            this.folderController.SetRoot(fullPath);
            this.listViewController.Import(folderController.GetRoot());
        }

        //----------------------------界面事件----------------------------

        /// <summary>
        /// 编译运行
        /// </summary>
        private void btnRun_Click(object sender, EventArgs e) {
            if (!CppHelper.Compile(folderController.GetRoot())) {
                MessageBox.Show("编译失败！", "Warning");
            }
            if (!CppHelper.Run(folderController.GetRoot())) {
                MessageBox.Show("运行失败！", "Warning");
            }
            //if (!CppHelper.Clean(fileinfo.Directory.FullName)) {
            //    MessageBox.Show("编译文件清理失败！", "Warning");
            //}
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e) {
            if (_fileinfo == null) {
                MessageBox.Show("当前没有打开任何文件，无法保存。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try {
                File.WriteAllText(_fileinfo.FullName, codeEditor.Text);
            } catch (Exception ex) {
                MessageBox.Show(string.Format("保存文件时发生异常：{0}", ex.Message), "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 评分TODO
        /// </summary>
        private void btnScore_Click(object sender, EventArgs e) {
            var fs = new FormScore(this);
            fs.LoadDetail(mHmwk);
            fs.Show(this);
        }

        private void btnSave_MouseMove(object sender, MouseEventArgs e) {
            btnSave.BackColor = Color.LightBlue;
        }
        private void btnSave_MouseLeave(object sender, EventArgs e) {
            btnSave.BackColor = Color.Transparent;
        }
        private void btnSave_MouseDown(object sender, MouseEventArgs e) {
            btnSave.BackColor = Color.SkyBlue;
        }

        private void btnRun_MouseMove(object sender, MouseEventArgs e) {
            btnRun.BackColor = Color.LightBlue;
        }
        private void btnRun_MouseLeave(object sender, EventArgs e) {
            btnRun.BackColor = Color.Transparent;
        }
        private void btnRun_MouseDown(object sender, MouseEventArgs e) {
            btnRun.BackColor = Color.SkyBlue;
        }

        private void fileListView_MouseDoubleClick(object sender, MouseEventArgs e) {
            ListViewHitTestInfo info = fileListView.HitTest(e.X, e.Y);
            if (info.Item != null) {
                ListViewItem item = info.Item;
                if (item.ImageIndex == 0) { //如果是文件夹
                    folderController.GoChildPath(item.Text);
                    listViewController.Import(folderController.GetFullPath(), !folderController.IsRoot());
                } else { //如果是文件
                    OpenFile(item.Text);
                }
            }
        }

        private void textEditor_TextChanged(object sender, System.EventArgs e) {
            codeEditor.Document.FoldingManager.UpdateFoldings(null, null);
            //if (textEditor.Text.Length <= oldJScodeLength) return;
            //var Line = this.textEditor.ActiveTextAreaControl.Caret.Line;
            //var offset = this.textEditor.ActiveTextAreaControl.Caret.Offset;
            //if (offset == 0) return;
            //var LineSegment = textEditor.ActiveTextAreaControl.TextArea.Document.GetLineSegment(Line);
            //if (offset == LineSegment.Length) return;
            //try {
            //    var charT = textEditor.ActiveTextAreaControl.TextArea.Document.GetText(offset, 1);
            //    var charE = "";
            //    switch (charT) {
            //        case "{":
            //            charE = "}";
            //            break;
            //        case "(":
            //            charE = ")";
            //            break;
            //        case "[":
            //            charE = "]";
            //            break;
            //    }
            //    if (!string.IsNullOrEmpty(charE)) {
            //        textEditor.ActiveTextAreaControl.SelectionManager.RemoveSelectedText();
            //        textEditor.ActiveTextAreaControl.Caret.Column = textEditor.ActiveTextAreaControl.Caret.Column + 1;
            //        textEditor.ActiveTextAreaControl.TextArea.InsertChar(charE[0]);
            //        textEditor.ActiveTextAreaControl.Caret.Column = textEditor.ActiveTextAreaControl.Caret.Column - 2;
            //        this.textEditor.ActiveTextAreaControl.TextArea.ScrollToCaret();
            //    }
            //} catch (Exception) {


            //}
        }

        //----------------------------格式化代码----------------------------
        /// <summary>
        /// 格式化代码
        /// </summary>
        /// <param name="code">原来的代码</param>
        /// <returns>格式化好的代码</returns>
        public static string FormatCode(string code) {
            //去除空白行
            //code = RemoveEmptyLines(code);
            StringBuilder sb = new StringBuilder();
            int count = 4; //缩进空格数
            int times = 0;
            string[] lines = code.Split(Environment.NewLine.ToCharArray());
            foreach (var line in lines) {
                if (line.TrimStart().StartsWith("{") || line.TrimEnd().EndsWith("{")) {
                    sb.AppendLine(Indent(count * times) + line.Trim());
                    times++;
                } else if (line.TrimStart().StartsWith("}")) {
                    times--;
                    if (times <= 0) {
                        times = 0;
                    }
                    sb.AppendLine(Indent(count * times) + line.Trim());
                } else {
                    sb.AppendLine(Indent(count * times) + line.Trim());
                }
            }
            return sb.ToString();
        }
        private static string Indent(int spaceNum) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spaceNum; i++)
                sb.Append(" ");
            return sb.ToString();
        }

        private void FormCodeView_Load(object sender, EventArgs e) {

        }
    }

    /// <summary>
    /// The class to generate the foldings, it implements ICSharpCode.TextEditor.Document.IFoldingStrategy
    /// </summary>
    public class CppFolding : IFoldingStrategy {
        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation) {
            List<FoldMarker> list = new List<FoldMarker>();
            //stack 先进先出
            var startLines = new Stack<int>();
            // Create foldmarkers for the whole document, enumerate through every line.
            for (int i = 0; i < document.TotalNumberOfLines; i++) {
                // Get the text of current line.
                string text = document.GetText(document.GetLineSegment(i));

                if (text.Trim().StartsWith("#region")) { // Look for method starts
                    startLines.Push(i);
                }
                if (text.Trim().StartsWith("#endregion")) { // Look for method endings
                    int start = startLines.Pop();
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 57, FoldType.Region, "..."));
                }
                //支持嵌套 {}
                if (text.Trim().StartsWith("{") || text.Trim().EndsWith("{")) { // Look for method starts
                    startLines.Push(i);
                }
                if (text.Trim().StartsWith("}") || text.Trim().EndsWith("}")) { // Look for method endings
                    if (startLines.Count > 0) {
                        int start = startLines.Pop();
                        list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 57, FoldType.TypeBody, "...}"));
                    }
                }
                // /// <summary>
                if (text.Trim().StartsWith("/// <summary>")) { // Look for method starts
                    startLines.Push(i);
                }
                if (text.Trim().StartsWith("/// <returns>")) { // Look for method endings
                    int start = startLines.Pop();
                    string display = document.GetText(document.GetLineSegment(start + 1).Offset, document.GetLineSegment(start + 1).Length);
                    //remove ///
                    display = display.Trim().TrimStart('/');
                    list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 57, FoldType.TypeBody, display));
                }
            }
            return list;
        }
    }
}
