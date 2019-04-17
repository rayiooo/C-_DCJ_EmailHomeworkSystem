using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EmailHomeworkSystem {
    public partial class FormCodeView : Form {
        public FormCodeView() {
            InitializeComponent();
            InitializeUI();
        }

        //----------------------------初始化操作----------------------------

        private void InitializeUI() {
            this.splitContainer1.SplitterDistance = (int)(splitContainer1.Height * 0.1667);

            textEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C++.NET");
            textEditor.Encoding = Encoding.Default;
            textEditor.Document.FoldingManager.FoldingStrategy = new CppFolding();
        }

        //----------------------------功能操作----------------------------

        public void OpenFile(string filePath) {
            textEditor.Text = File.ReadAllText(filePath, System.Text.Encoding.Default);
        }

        //----------------------------界面事件----------------------------
        private void textEditor_TextChanged(object sender, System.EventArgs e) {
            textEditor.Document.FoldingManager.UpdateFoldings(null, null);
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
        /// <summary>
        /// 格式化JS代码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //public static string FormatJSCode(string code) {
        //    //去除空白行
        //    code = RemoveEmptyLines(code);
        //    StringBuilder sb = new StringBuilder();
        //    int count = 2;
        //    int times = 0;
        //    string[] lines = code.Split('\n');
        //    foreach (var line in lines) {
        //        if (line.TrimStart().StartsWith("{") || line.TrimEnd().EndsWith("{")) {
        //            sb.Append(Indent(count * times) + line.TrimStart() + "\r\n");
        //            times++;

        //        } else if (line.TrimStart().StartsWith("}")) {
        //            times--;
        //            if (times <= 0) {
        //                times = 0;
        //            }
        //            sb.Append(Indent(count * times) + line.TrimStart() + "\r\n");
        //        } else {
        //            sb.Append(Indent(count * times) + line.TrimStart() + "\r\n");
        //        }
        //    }
        //    return sb.ToString();
        //}
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
                if (text.Trim().StartsWith("{")) { // Look for method starts
                    startLines.Push(i);
                }
                if (text.Trim().StartsWith("}")) { // Look for method endings
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
                    //获取注释文本（包括空格）
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
