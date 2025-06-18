using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            
            // 应用简易现代化UI
            ApplySimpleUI();
        }

        /// <summary>
        /// 应用简易现代化UI
        /// </summary>
        private void ApplySimpleUI()
        {
            // 窗体样式
            this.BackColor = Color.FromArgb(245, 245, 245);
            
            // 隐藏团队照片
            HideTeamPhotos();
            
            // 美化按钮
            BeautifyButtons();
            
            // 美化数据表格
            BeautifyDataGrid();
            
            // 美化标题栏
            BeautifyTitleBar();
        }

        /// <summary>
        /// 隐藏团队照片
        /// </summary>
        private void HideTeamPhotos()
        {
            if (pictureBox1 != null) pictureBox1.Visible = false;
            if (pictureBox2 != null) pictureBox2.Visible = false;
            if (pictureBox3 != null) pictureBox3.Visible = false;
            if (pictureBox4 != null) pictureBox4.Visible = false;
            if (pictureBox5 != null) pictureBox5.Visible = false;
            if (label1 != null) label1.Visible = false;
            if (label2 != null) label2.Visible = false;
            if (label3 != null) label3.Visible = false;
            if (label4 != null) label4.Visible = false;
            if (label9 != null) label9.Visible = false;
        }

        /// <summary>
        /// 美化按钮
        /// </summary>
        private void BeautifyButtons()
        {
            // 宿舍管理按钮
            if (d_m != null)
            {
                d_m.FlatStyle = FlatStyle.Flat;
                d_m.FlatAppearance.BorderSize = 0;
                d_m.BackColor = Color.FromArgb(52, 152, 219);
                d_m.ForeColor = Color.White;
                d_m.Font = new Font("微软雅黑", 10F);
            }

            // 学生管理按钮
            if (s_m != null)
            {
                s_m.FlatStyle = FlatStyle.Flat;
                s_m.FlatAppearance.BorderSize = 0;
                s_m.BackColor = Color.FromArgb(46, 125, 50);
                s_m.ForeColor = Color.White;
                s_m.Font = new Font("微软雅黑", 10F);
            }

            // 出入登记按钮
            if (i_o != null)
            {
                i_o.FlatStyle = FlatStyle.Flat;
                i_o.FlatAppearance.BorderSize = 0;
                i_o.BackColor = Color.FromArgb(255, 152, 0);
                i_o.ForeColor = Color.White;
                i_o.Font = new Font("微软雅黑", 10F);
            }

            // 来访登记按钮
            if (i_c != null)
            {
                i_c.FlatStyle = FlatStyle.Flat;
                i_c.FlatAppearance.BorderSize = 0;
                i_c.BackColor = Color.FromArgb(156, 39, 176);
                i_c.ForeColor = Color.White;
                i_c.Font = new Font("微软雅黑", 10F);
            }

            // 高级功能按钮
            if (high != null)
            {
                high.FlatStyle = FlatStyle.Flat;
                high.FlatAppearance.BorderSize = 0;
                high.BackColor = Color.FromArgb(244, 67, 54);
                high.ForeColor = Color.White;
                high.Font = new Font("微软雅黑", 10F);
            }
        }

        /// <summary>
        /// 美化数据表格
        /// </summary>
        private void BeautifyDataGrid()
        {
            if (dataGridView0 != null)
            {
                // 基础样式
                dataGridView0.BackgroundColor = Color.White;
                dataGridView0.BorderStyle = BorderStyle.None;
                dataGridView0.RowHeadersVisible = false;
                dataGridView0.AllowUserToAddRows = false;
                
                // 标题样式
                dataGridView0.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
                dataGridView0.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView0.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
                dataGridView0.ColumnHeadersHeight = 35;
                
                // 行样式
                dataGridView0.DefaultCellStyle.BackColor = Color.White;
                dataGridView0.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                dataGridView0.DefaultCellStyle.Font = new Font("微软雅黑", 9F);
                dataGridView0.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
                dataGridView0.RowTemplate.Height = 30;
                
                // 交替行
                dataGridView0.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            }
        }

        /// <summary>
        /// 美化标题栏
        /// </summary>
        private void BeautifyTitleBar()
        {
            if (main_top != null)
            {
                main_top.BackColor = Color.FromArgb(44, 62, 80);
                main_top.ForeColor = Color.White;
                main_top.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            }

            if (close != null)
            {
                close.BackColor = Color.Transparent;
                close.ForeColor = Color.White;
                close.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
                close.Text = "×";
            }

            if (small != null)
            {
                small.BackColor = Color.Transparent;
                small.ForeColor = Color.White;
                small.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
                small.Text = "－";
            }

            if (down != null)
            {
                down.BackColor = Color.Transparent;
                down.ForeColor = Color.White;
                down.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
                down.Text = "↓";
            }
        }

        // 原有的事件处理方法保持不变
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
                if (high != null) high.Visible = (power == 2);
                this.Visible = true;
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }
    }
}
