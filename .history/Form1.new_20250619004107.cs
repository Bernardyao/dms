using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dms
{
    public partial class Form1 : Form
    {
        private Point offset;
        public static int power = 0;
        public static int admin_id = 0;
        public static string admin_name = "";
        private DataTable dat;
        private dms.DataAccess dataAccess;

        public Form1()
        {
            InitializeComponent();
            dataAccess = new dms.DataAccess();
            
            // 隐藏团队成员照片和信息
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label9.Visible = false;
        }

        private void main_top_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void main_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void small_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        
        private void down_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login l = new Login();
            l.ShowDialog();
            if (l.DialogResult == DialogResult.OK)
            {
                high.Visible = (power == 2);
                this.Visible = true;
            }
            else
            {
                this.Close();
                this.Dispose();
            }
            n.Text = admin_name;
            SetActivePanel(d_m);
        }
    }
}
