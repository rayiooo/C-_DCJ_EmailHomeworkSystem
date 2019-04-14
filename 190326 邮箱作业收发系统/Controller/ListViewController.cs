using EmailHomeworkSystem.BaseLib;
using System.IO;
using System.Windows.Forms;

namespace EmailHomeworkSystem.Controller {
    public class ListViewController {
        private string folderPath;
        private FormMain form;

        public ListViewController(FormMain form) {
            this.form = form;
        }

        /// <summary>
        /// 将路径下的文件和文件夹显示在listView中
        /// </summary>
        /// <param name="folderPath">目录全名</param>
        public void Import(string folder) {
            this.folderPath = folder;
            Log.D(string.Format("当前目录：{0}", folder));
            form.listView.BeginUpdate();
            form.listView.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(folder);
            if (info.Exists) {
                foreach (DirectoryInfo dir in info.GetDirectories()) {
                    ListViewItem item = new ListViewItem(dir.Name, 0);
                    form.listView.Items.Add(item);
                }
                foreach (FileInfo dir in info.GetFiles()) {
                    ListViewItem item = new ListViewItem(dir.Name);
                    if (dir.Name.EndsWith(".cpp")) {
                        item.ImageIndex = 1;
                    } else if (dir.Name.EndsWith(".h")) {
                        item.ImageIndex = 2;
                    } else if (dir.Name.EndsWith(".rar")) {
                        item.ImageIndex = 4;
                    } else if (dir.Name.EndsWith(".txt")) {
                        item.ImageIndex = 5;
                    } else if (dir.Name.EndsWith(".zip")) {
                        item.ImageIndex = 6;
                    } else {
                        item.ImageIndex = 3;
                    }
                    form.listView.Items.Add(item);
                }
            }
            form.listView.EndUpdate();
        }
    }
}
