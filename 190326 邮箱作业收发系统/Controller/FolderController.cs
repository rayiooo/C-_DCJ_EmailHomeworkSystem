
using System;
using System.IO;

namespace EmailHomeworkSystem.Controller {
    /// <summary>
    /// 路径控制器，方便对路径的管理
    /// </summary>
    public class FolderController {
        private FormMain _form;
        private string _relativePath; //相对根目录的路径
        private string _root;
        public string root {
            get { return _root; }
            set { _form.listViewController.Import(value); _form.treeViewController.Import(value); _root = value; }
        }

        public FolderController(FormMain form) {
            _form = form;
        }

        public string GetChildPathFull(string childName) {
            return string.Format("{0}{1}\\{2}", _root, _relativePath, childName);
        }

        /// <summary>
        /// 进入下级目录
        /// </summary>
        /// <param name="folderName">下级目录文件夹名</param>
        public void GoChildPath(string folderName) {
            _relativePath = string.Format("{0}\\{1}", _relativePath, folderName);
            _form.listViewController.Import(_root + _relativePath);

            //刷新返回键可用状态
            if(_relativePath != "" && !_form.btnFolderBack.Enabled) {
                if (_form.InvokeRequired) {
                    _form.Invoke(new Action(() => {
                        _form.btnFolderBack.Enabled = true;
                    }));
                } else {
                    _form.btnFolderBack.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 返回上级目录，如果已到根目录则直接返回
        /// </summary>
        public void GoParentPath() {
            if (_relativePath == "")
                return;
            _relativePath = Directory.GetParent(_root + _relativePath).FullName.Replace(_root, "");
            _form.listViewController.Import(_root + _relativePath);

            //刷新返回键可用状态
            if(_relativePath == "" && _form.btnFolderBack.Enabled) {
                if (_form.InvokeRequired) {
                    _form.Invoke(new Action(() => {
                        _form.btnFolderBack.Enabled = false;
                    }));
                } else {
                    _form.btnFolderBack.Enabled = false;
                }
            }
        }
    }
}
