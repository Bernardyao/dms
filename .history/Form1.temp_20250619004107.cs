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
        private Point offset;//鼠标拖动的位移量
        public static int power = 0;//登陆的权限
        public static int admin_id = 0;//登陆的用户
        public static string admin_name = "";//登陆的用户
        private DataTable dat;//记录查询到的结果表
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
            
            // 在这里我们将添加原始Form1.cs中的其他方法
        }
          // 以下是从Form1.cs中提取的关键方法
        
        private bool ExecuteNonQuery(string sqlStr, string successMessage = null)
        {
            try
            {
                int result = ConnectDB.getInstance().Change(sqlStr);
                if (result > 0 && !string.IsNullOrEmpty(successMessage))
                {
                    MessageBox.Show(successMessage, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"执行操作时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
        
        private void SetActivePanel(Control activeControl, bool showDataGrid = true)
        {
            var buttons = new[] { d_m, s_m, i_o, i_c, high };
            foreach (var btn in buttons)
            {
                btn.BackColor = System.Drawing.Color.PaleGoldenrod;
            }

            if (activeControl != null)
            {
                activeControl.BackColor = System.Drawing.Color.DeepSkyBlue;
            }

            D_m(activeControl == d_m);
            S_m(activeControl == s_m);
            I_o(activeControl == i_o);
            I_c(activeControl == i_c);
            High(activeControl == high);

            dat = null;
            dataGridView0.DataSource = null;
            dataGridView0.Visible = showDataGrid;
        }

        private void d_m_Click(object sender, EventArgs e)
        {
            SetActivePanel(d_m);
            SetDormitory(lou, "select ch+cast(num as varchar(2)) d_id from dormitory");
        }        private void s_m_Click(object sender, EventArgs e)
        {
            SetActivePanel(s_m);
            SetDormitory(do_c, "select ch+cast(num as varchar(2)) d_id from dormitory");
        }
        
        private void i_o_Click(object sender, EventArgs e)
        {
            SetActivePanel(i_o);
            if (power == 0)
            {
                SetDormitory(d, "select ch+cast(num as varchar(2)) d_id from dormitory where a_id=" + admin_id);

                string sqlStr = "select student.sname name from in_out left join student on in_out.s_id=student.id where in_date is null";
                try
                {
                    DataTable dt = ConnectDB.getInstance().GetData(sqlStr).Tables[0];
                    s_name_c.ValueMember = "name";
                    DataRow dr = dt.NewRow();
                    dr["name"] = " ";
                    dt.Rows.InsertAt(dr, 0);
                    s_name_c.DataSource = dt;
                }
                catch (Exception)
                {
                    s_name_c.DataSource = null;
                }
            }
            else
            {
                SetDormitory(d, "select ch+cast(num as varchar(2)) d_id from dormitory");
            }
        }

        private void i_c_Click(object sender, EventArgs e)
        {
            SetActivePanel(i_c);
            if (power == 0)
            {
                SetDormitory(v_d, "select ch+cast(num as varchar(2)) d_id from dormitory where a_id=" + admin_id);

                string sqlStr = "select name from visit where out_date is null";
                try
                {
                    DataTable dt = ConnectDB.getInstance().GetData(sqlStr).Tables[0];
                    v_name_c.ValueMember = "name";
                    DataRow dr = dt.NewRow();
                    dr["name"] = " ";
                    dt.Rows.InsertAt(dr, 0);
                    v_name_c.DataSource = dt;
                }
                catch (Exception)
                {
                    v_name_c.DataSource = null;
                }
            }
            else
            {
                SetDormitory(v_d, "select ch+cast(num as varchar(2)) d_id from dormitory");
            }
        }
        
        private void high_Click(object sender, EventArgs e)
        {
            SetActivePanel(high);
            CheckAllAdmin();
        }
        
        private void label5_Click(object sender, EventArgs e)
        {
        }
        
        private void s_name_label1_Click(object sender, EventArgs e)
        {
        }
    }
}
