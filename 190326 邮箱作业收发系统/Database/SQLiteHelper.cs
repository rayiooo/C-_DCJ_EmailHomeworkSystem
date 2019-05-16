using EmailHomeworkSystem.BaseLib;
using System;
using System.Data.SQLite;

namespace EmailHomeworkSystem.Database {
    class SqLiteHelper: IDisposable {

        private static object objLock = new object();   //锁对象
        private SQLiteDataReader dataReader;           //数据读取定义
        private SQLiteCommand dbCommand;                //SQL命令定义
        private SQLiteConnection dbConnection;         //数据库连接定义

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString"></param>
        public SqLiteHelper(string connectionString) {
            try {
                dbConnection = new SQLiteConnection("data source=" + connectionString);
                dbConnection.Open();
                Log.D("SQLiteHelper: db opened.");
            } catch (Exception ex) {
                Log.E("SQLiteHelper: " + ex.Message);
            }
        }

        /// <summary>
        /// 新建数据库文件
        /// </summary>
        /// <param name="dbPath"></param>
        /// <returns></returns>
        public static Boolean NewDbFile(string dbPath) {
            try {
                SQLiteConnection.CreateFile(dbPath);
                return true;
            } catch (Exception ex) {

                throw new Exception("新建数据库文件" + dbPath + "失败：" + ex.Message);
            }

        }


        /// <summary>
        /// 执行SQl命令
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteQuery(string queryString) {
            lock (objLock) {
                Log.D("SQLiteHelper.ExecuteQuery: " + queryString);
                try {
                    dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandText = queryString;
                    dataReader = dbCommand.ExecuteReader();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                return dataReader;
            }
        }

        /// <summary>
        /// 静态执行SQL命令
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static void ExecuteQuery(string dbPath, string query) {
            lock (objLock) {
                Log.D("SQLiteHelper.ExecuteQuery(static): " + query);
                using (var conn = new SQLiteConnection("data source=" + dbPath)) {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(query, conn)) {
                        cmd.ExecuteReader();
                    }
                }
            }
        }
        /// <summary>
        /// 使用委托在SQL命令后执行并返回所需值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbPath"></param>
        /// <param name="query"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T ExecuteQuery<T>(string dbPath, string query, Func<SQLiteDataReader, T> func) {
            lock (objLock) {
                Log.D("SQLiteHelper.ExecuteQuery(static): " + query);
                using (var conn = new SQLiteConnection("data source=" + dbPath)) {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(query, conn)) {
                        using (var dr = cmd.ExecuteReader()) {
                            return func(dr);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnection() {
            Log.D("SQLiteHelper.CloseCOnnection: db closed.");
            //销毁Commend
            if (dbCommand != null) {
                dbCommand.Cancel();
            }
            dbCommand = null;

            //销毁Reader
            if (dataReader != null) {
                dataReader.Close();
            }
            dataReader = null;

            //销毁Connection
            if (dbConnection != null) {
                dbConnection.Close();
                dbConnection.Dispose();
            }
            dbConnection = null;

        }


        /// <summary>
        /// 读取整张数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public SQLiteDataReader ReadFullTable(string tableName) {
            string queryString = "SELECT * FROM " + tableName;

            return ExecuteQuery(queryString);
        }


        /// <summary>
        /// 向指定数据表中插入数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="values">数值</param>
        /// <returns></returns>
        public SQLiteDataReader InsertValues(string tableName, string[] values) {
            //获取数据表中字段数目
            int fieldCount = ReadFullTable(tableName).FieldCount;

            if (values.Length != fieldCount) {
                throw new SQLiteException("Values.Length!=fieldCount");
            }

            string queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";

            for (int i = 1; i < values.Length; i++) {
                queryString += ", " + "'" + values[i] + "'";

            }
            queryString += ")";
            return ExecuteQuery(queryString);

        }


        /// <summary>
        /// 更新指定数据表内的数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colNames"></param>
        /// <param name="colValues"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public SQLiteDataReader UpdateValues(string tableName, string[] colNames, string[] colValues, string key, string value, string operation = "=") {

            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length) {
                throw new SQLiteException("colNames.Length!=colValues.Leght");

            }
            string queryString = "UPDATE" + tableName + " SET " + colNames[0] + "=" + "'" + colValues[0] + "'";

            for (int i = 0; i < colValues.Length; i++) {
                queryString += ", " + colNames[i] + "=" + "'" + colValues[i] + "'";
            }
            queryString += "WHWERE " + key + operation + "'" + value + "'";
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 计数query取到的数据数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int Count(string query) {
            int ret = 0;
            using (var reader = ExecuteQuery(query)) {
                while (reader.Read()) {
                    ret++;
                }
            }
            return ret;
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colNames"></param>
        /// <param name="colValues"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public SQLiteDataReader DeleteValuesOR(string tableName, string[] colNames, string[] colValues, string[] operations) {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length) {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";

            for (int i = 0; i < colValues.Length; i++) {
                queryString += "OR" + colValues[i] + operations[0] + "'" + colValues[i] + "'";
            }

            return ExecuteQuery(queryString);

        }


        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public SQLiteDataReader DeleteValuesAND(string tableName, string[] colNames, string[] colValues, string[] operations) {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length) {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++) {
                queryString += " AND " + colNames[i] + operations[i] + "'" + colValues[i] + "'";
            }
            return ExecuteQuery(queryString);
        }



        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colNames"></param>
        /// <param name="colTypes"></param>
        /// <returns></returns>
        public SQLiteDataReader CreateTable(string tableName, string[] colNames, string[] colTypes) {
            string queryString = "CREATE TABLE IF NOT EXISTS " + tableName + "( " + colNames[0] + " " + colTypes[0];
            for (int i = 1; i < colNames.Length; i++) {
                queryString += ", " + colNames[i] + " " + colTypes[i];
            }
            queryString += "  ) ";
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// Reads the table.
        /// </summary>
        /// <returns>The table.</returns>
        /// <param name="tableName">Table name.</param>
        /// <param name="items">Items.</param>
        /// <param name="colNames">Col names.</param>
        /// <param name="operations">Operations.</param>
        /// <param name="colValues">Col values.</param>
        public SQLiteDataReader ReadTable(string tableName, string[] items, string[] colNames, string[] operations, string[] colValues) {
            string queryString = "SELECT " + items[0];
            for (int i = 1; i < items.Length; i++) {
                queryString += ", " + items[i];
            }
            queryString += " FROM " + tableName + " WHERE " + colNames[0] + " " + operations[0] + " " + colValues[0];
            for (int i = 0; i < colNames.Length; i++) {
                queryString += " AND " + colNames[i] + " " + operations[i] + " " + colValues[0] + " ";
            }
            return ExecuteQuery(queryString);
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                CloseConnection();

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        ~SqLiteHelper() {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(false);
        }

        // 添加此代码以正确实现可处置模式。
        public void Dispose() {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}