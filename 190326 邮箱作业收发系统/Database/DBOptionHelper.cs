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
                StringBuilder query = new StringBuilder();
                query.AppendLine("CREATE TABLE \"student\" (");
                query.AppendLine("    \"sno\" TEXT(32) NOT NULL,");
                query.AppendLine("    \"sname\" TEXT(32) NOT NULL,");
                query.AppendLine("    PRIMARY KEY(\"sno\"),");
                query.AppendLine("    FOREIGN KEY(\"sno\") REFERENCES \"score\"(\"sno\")");
                query.AppendLine(");");
                query.AppendLine("CREATE TABLE \"homework\"(");
                query.AppendLine("    \"hno\" TEXT(32) NOT NULL,");
                query.AppendLine("    \"publishTime\" INTEGER,");
                query.AppendLine("    \"endingTime\" INTEGER NOT NULL,");
                query.AppendLine("    \"content\" TEXT,");
                query.AppendLine("    PRIMARY KEY(\"hno\"),");
                query.AppendLine("    FOREIGN KEY(\"hno\") REFERENCES \"score\"(\"hno\")");
                query.AppendLine(");");
                query.AppendLine("CREATE TABLE \"score\"(");
                query.AppendLine("    \"sno\" TEXT(32) NOT NULL,");
                query.AppendLine("    \"hno\" TEXT(32) NOT NULL,");
                query.AppendLine("    \"commitTime\" INTEGER,");
                query.AppendLine("    \"score\" INTEGER DEFAULT 0,");
                query.AppendLine("    PRIMARY KEY(\"sno\", \"hno\")");
                query.AppendLine(");");
                sh.ExecuteQuery(query.ToString());
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
