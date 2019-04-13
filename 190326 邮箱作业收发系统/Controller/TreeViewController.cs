using System.IO;
using System.Windows.Forms;

namespace EmailHomeworkSystem.Controller {
    public class TreeViewController {
        private string folderPath;
        private FormMain form;

        public TreeViewController(FormMain form) {
            this.form = form;
        }
        /// <summary>
        /// 导入文件并在treeView显示
        /// </summary>
        /// <param name="folderPath">根目录路径</param>
        public void Import(string folderPath) {
            this.folderPath = folderPath;
            form.treeView.Nodes.Clear();
            form.treeView.Nodes.Add(this.BuildNode(this.folderPath));
        }
        private TreeNode BuildNode(string folder) {
            TreeNode node = null;
            DirectoryInfo info = new DirectoryInfo(folder);
            if (info.Exists) {
                node = new TreeNode(info.Name) {
                    Tag = info,
                    ImageKey = "folder"
                };
                foreach (DirectoryInfo dir in info.GetDirectories()) {
                    TreeNode child = BuildNode(dir.FullName);
                    if(child != null) {
                        node.Nodes.Add(child);
                    }
                }
            }
            return node;
        }
    }
}
