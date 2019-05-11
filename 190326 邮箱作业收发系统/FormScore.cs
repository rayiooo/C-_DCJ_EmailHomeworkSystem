using EmailHomeworkSystem.Controller;
using EmailHomeworkSystem.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailHomeworkSystem {
    public partial class FormScore : Form {
        private Hmwk mHmwk;

        public FormScore() {
            InitializeComponent();
        }

        /// <summary>
        /// 打分按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetScore_Click(object sender, EventArgs e) {
            int score = -1;
            try {
                score = int.Parse(TextScore.Text);
            } catch (Exception ex) {
                MessageBox.Show("错误的分数格式：" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBOptionHelper.SetScore(mHmwk, score);
        }

        /// <summary>
        /// 载入学生详情
        /// </summary>
        /// <param name="sname"></param>
        /// <param name="hno"></param>
        public void LoadDetail(Hmwk hmwk) {
            mHmwk = hmwk;
            Sno.Text = mHmwk.Sno;
            Sname.Text = mHmwk.Sname;
            Hno.Text = mHmwk.Hno;
            Score.Text = mHmwk.Score >= 0 ? mHmwk.Score.ToString() : "暂未打分";
            TextScore.Text = "";
        }
    }
}
