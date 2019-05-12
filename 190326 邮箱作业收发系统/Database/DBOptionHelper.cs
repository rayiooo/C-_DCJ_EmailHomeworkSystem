﻿using EmailHomeworkSystem.BaseLib;
using EmailHomeworkSystem.Controller;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace EmailHomeworkSystem.Database {
    public class DBOptionHelper {
        private static string dbPath;
        private static string rootPath;

        /// <summary>
        /// 初始化数据库路径，如果没有就创建一个
        /// </summary>
        /// <param name="root">数据库根目录文件夹</param>
        public static void Initialize(string root) {
            rootPath = root;
            dbPath = root + "\\sqlite.db";
            if (!File.Exists(dbPath)) {
                Log.D("DBOptionHelper.Initialize: initializing db.");
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
                ReadAndStoreStudents();
            }
        }

        /// <summary>
        /// 从students.txt中读取学生信息并写入到数据库中
        /// </summary>
        private static void ReadAndStoreStudents() {
            if (!File.Exists(rootPath + "\\students.txt")) {
                throw new FileNotFoundException("学生信息文件students.txt不存在！");
            }
            Log.D("DBOptionHelper.ReadAndStoreStudents: storing students' information.");
            string[] students = File.ReadAllLines(rootPath + "\\students.txt", Encoding.Default);
            SqLiteHelper sh = new SqLiteHelper(dbPath);
            foreach (string item in students) {
                if (item.Length == 0)
                    continue;
                string[] stu = item.Split('\t');
                if (stu.Length == 2) {
                    string sno = stu[0].Trim(), sname = Base.ConvertSimplifiedChinese(stu[1].Trim());
                    int count = sh.Count(string.Format("SELECT * FROM student WHERE sno='{0}'", sno));
                    if (count == 0)
                        sh.InsertValues("student", new string[] { sno, sname }); //sno, sname
                }
            }
            sh.CloseConnection();
        }

        /// <summary>
        /// 获取某学生某次作业分数
        /// </summary>
        /// <param name="sname">学生姓名</param>
        /// <param name="hno">作业号</param>
        /// <returns>返回分数，如果无记录返回-2</returns>
        public static int GetScore(string sname, string hno) {
            if (dbPath == null) {
                throw new FileNotFoundException("不存在DB文件sqlite.db！");
            }
            string sql = string.Format("SELECT score FROM score " +
                "WHERE sno=(SELECT sno FROM student WHERE sname=\"{0}\") AND hno=\"{1}\"", Base.ConvertSimplifiedChinese(sname), hno);
            int ret = -2;
            SqLiteHelper sh = new SqLiteHelper(dbPath);
            using(SQLiteDataReader dr = sh.ExecuteQuery(sql)) {
                while (dr.Read()) {
                    try {
                        ret = int.Parse(dr["score"].ToString());
                    } catch (Exception ex) {
                        Log.E("获取作业分数时发生异常：" + ex.Message);
                    }
                }
            }
            sh.CloseConnection();
            return ret;
        }

        /// <summary>
        /// 获取整张score表
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string, int>> GetScores() {
            if (dbPath == null) {
                throw new FileNotFoundException("不存在DB文件sqlite.db！");
            }
            var ret = new List<Tuple<string, string, int>>();
            var sh = new SqLiteHelper(dbPath);
            using(SQLiteDataReader dr = sh.ReadFullTable("score")) {
                while (dr.Read()) {
                    string sname = dr["sname"].ToString();
                    string hno = dr["hno"].ToString();
                    int score = -1;
                    try {
                        score = int.Parse(dr["score"].ToString());
                    } catch (Exception ex) {
                        Log.E("获取作业分数时发生异常：" + ex.Message);
                    }
                    ret.Add(new Tuple<string, string, int>(sname, hno, score));
                }
            }
            sh.CloseConnection();
            return ret;
        }

        /// <summary>
        /// 获取学生信息列表Dict<sname, sno>
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetStudents() {
            if (dbPath == null) {
                throw new FileNotFoundException("不存在DB文件sqlite.db！");
            }
            var ret = new Dictionary<string, string>();
            var sh = new SqLiteHelper(dbPath);
            using (SQLiteDataReader dr = sh.ReadFullTable("student")) {
                while (dr.Read()) {
                    string sname = dr["sname"].ToString();
                    string sno = dr["sno"].ToString();
                    ret.Add(sname, sno);
                }
            }
            sh.CloseConnection();
            return ret;
        }

        /// <summary>
        /// 置分数（待验）
        /// </summary>
        public static void SetScore(Hmwk h, int score) {
            if (dbPath == null) {
                throw new FileNotFoundException("不存在DB文件sqlite.db！");
            }

            Log.D("DBOptionHelper.SetScore: start.");
            int oldScore = h.Score;
            var sh = new SqLiteHelper(dbPath);
            if (oldScore < 0) { //不存在的分数条目
                Log.D("DBOptionHelper.SetScore: score info not exist, creating...");
                sh.InsertValues("score", new string[]{ h.Sno, h.Hno, "0", score.ToString()});
            } else {
                Log.D("DBOptionHelper.SetScore: score info exist, updating...");
                sh.ExecuteQuery(string.Format("UPDATE score SET score={0} WHERE sno='{1}' AND hno='{2}'",
                    score.ToString(), h.Sno, h.Hno));
            }
            sh.CloseConnection();
        }
    }
}
