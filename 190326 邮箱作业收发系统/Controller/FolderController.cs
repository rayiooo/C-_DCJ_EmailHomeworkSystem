using System;
using System.IO;

namespace EmailHomeworkSystem.Controller {
    /// <summary>
    /// 路径控制器，方便对路径的管理
    /// </summary>
    public class FolderController {
        private string _relativePath; //相对根目录的路径
        private string _root;

        public FolderController() {

        }

        public FolderController(string root) {
            _root = root;
            _relativePath = "";
        }

        public string GetChildFullPath(string childName) {
            return string.Format("{0}{1}\\{2}", _root, _relativePath, childName);
        }

        public string GetFullPath() {
            return _root + _relativePath;
        }
        
        public string GetRoot() {
            return _root;
        }

        public string GoChildPath(string folderName) {
            if(folderName == "..") {
                return GoParentPath();
            }
            _relativePath = string.Format("{0}\\{1}", _relativePath, folderName);
            return _root + _relativePath;
        }
        
        public string GoParentPath() {
            if (_relativePath == "")
                return _root;
            _relativePath = Directory.GetParent(_root + _relativePath).FullName.Replace(_root, "");
            return _root + _relativePath;
        }

        public bool IsRoot() {
            if (_relativePath == "")
                return true;
            return false;
        }

        public void SetRoot(string root) {
            _root = root;
            _relativePath = "";
        }
    }
}
