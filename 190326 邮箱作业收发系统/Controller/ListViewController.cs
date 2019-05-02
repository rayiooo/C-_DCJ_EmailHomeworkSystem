using EmailHomeworkSystem.BaseLib;
using System.IO;
using System.Windows.Forms;

namespace EmailHomeworkSystem.Controller {
    public class ListViewController {
        private string _folder;
        private ListView _listView;

        public ListViewController(ListView lv) {
            this._listView = lv;
        }

        /// <summary>
        /// 将路径下的文件和文件夹显示在listView中
        /// </summary>
        /// <param name="folderPath">目录全名</param>
        public void Import(string folder, bool backItem = false) {
            this._folder = folder;
            Log.D(string.Format("当前目录：{0}", folder));
            _listView.BeginUpdate();
            _listView.Items.Clear();
            if (backItem) {
                _listView.Items.Add(new ListViewItem("..", 0));
            }
            DirectoryInfo info = new DirectoryInfo(folder);
            if (info.Exists) {
                foreach (DirectoryInfo dir in info.GetDirectories()) {
                    ListViewItem item = new ListViewItem(dir.Name, 0);
                    _listView.Items.Add(item);
                }
                foreach (FileInfo file in info.GetFiles()) {
                    ListViewItem item = new ListViewItem(file.Name);
                    if (file.Name.EndsWith(".cpp")) {
                        item.ImageIndex = 1;
                    } else if (file.Name.EndsWith(".h")) {
                        item.ImageIndex = 2;
                    } else if (file.Name.EndsWith(".rar")) {
                        item.ImageIndex = 4;
                    } else if (file.Name.EndsWith(".txt")) {
                        item.ImageIndex = 5;
                    } else if (file.Name.EndsWith(".zip")) {
                        item.ImageIndex = 6;
                    } else {
                        item.ImageIndex = 3;
                    }
                    _listView.Items.Add(item);
                }
            }
            _listView.EndUpdate();
        }

        /// <summary>
        /// 仅导入可阅读的代码文件
        /// </summary>
        /// <param name="folder"></param>
        public void ImportOnlyCode(string folder, bool backItem = false) {
            this._folder = folder;
            _listView.BeginUpdate();
            _listView.Items.Clear();
            if (backItem) {
                _listView.Items.Add(new ListViewItem("..", 0));
            }
            DirectoryInfo info = new DirectoryInfo(folder);
            if (info.Exists) {
                foreach (DirectoryInfo dir in info.GetDirectories()) {
                    ListViewItem item = new ListViewItem(dir.Name, 0);
                    _listView.Items.Add(item);
                }
                foreach (FileInfo file in info.GetFiles()) {
                    ListViewItem item = new ListViewItem(file.Name);
                    if (file.Name.EndsWith(".cpp")) {
                        item.ImageIndex = 1;
                    } else if (file.Name.EndsWith(".h")) {
                        item.ImageIndex = 2;
                    } else if (file.Name.EndsWith(".txt")) {
                        item.ImageIndex = 5;
                    } else {
                        continue;
                    }
                    _listView.Items.Add(item);
                }
            }
            _listView.EndUpdate();
        }
    }
}
