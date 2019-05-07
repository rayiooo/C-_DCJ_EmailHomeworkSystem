using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailHomeworkSystem.Database {
    public class DBOptionHelper {
        private string dbPath;
        private string rootPath;

        public DBOptionHelper(string rootPath) {
            this.rootPath = rootPath;
            dbPath = rootPath + "\\sqlite.db";
            if (!File.Exists(dbPath)) {
                //创建文件
                SqLiteHelper.NewDbFile(dbPath);
                //添加表
                SqLiteHelper sh = new SqLiteHelper(dbPath);
                sh.CreateTable("Student", new string[] { "sno", "name" }, new string[] { "text", "text" });
                sh.CloseConnection();
                //读取信息
                ReadStudents();
            }
        }
        private void ReadStudents() {
            if(!File.Exists(rootPath + "\\students.txt")) {
                throw new FileNotFoundException("学生信息文件students.txt不存在！");
            }
            string[] students = File.ReadAllLines(rootPath + "\\students.txt");
            SqLiteHelper sh = new SqLiteHelper(dbPath);
            foreach(string item in students) {
                if (item.Length == 0)
                    continue;
                string[] stu = item.Split('\t');
                if(stu.Length == 2) {
                    sh.InsertValues("student", new string[] { stu[0].Trim(), stu[1].Trim() });
                }
            }
            sh.CloseConnection();
        }
    }
}
