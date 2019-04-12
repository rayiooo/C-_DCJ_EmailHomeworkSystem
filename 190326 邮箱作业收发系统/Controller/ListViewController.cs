using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailHomeworkSystem.Controller {
    class ListViewController {
        private FormMain form;

        public ListViewController(FormMain form) {
            this.form = form;
        }
        public void test() {
            form.listView.BeginUpdate();
            for(int i=0; i<10; i++) {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = 0;
                item.Text = "学生" + i;
                form.listView.Items.Add(item);
            }

            form.listView.EndUpdate();
        }
    }
}
