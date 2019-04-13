using System;
using System.Text;
using System.Windows.Forms;

namespace EmailHomeworkSystem.BaseLib {
    public class Log {
        public static void D(string log) {
            string temp = string.Format("{0} [debug] : {1}", Base.GetCurrentTime(), log);
            Console.WriteLine(temp);
        }
        public static void I(string log) {
            string temp = string.Format("{0} [info] : {1}", Base.GetCurrentTime(), log);
            Console.WriteLine(temp);
        }
        public static void W(string log) {
            string temp = string.Format("{0} [warn] : {1}", Base.GetCurrentTime(), log);
            Console.WriteLine(temp);
        }
        public static void E(string log) {
            string temp = string.Format("{0} [error] : {1}", Base.GetCurrentTime(), log);
            Console.WriteLine(temp);
        }
        public static void F(string log) {
            string temp = string.Format("{0} [fatal] : {1}", Base.GetCurrentTime(), log);
            Console.WriteLine(temp);
            MessageBox.Show(temp, "Fatal!");
        }
    }
}
