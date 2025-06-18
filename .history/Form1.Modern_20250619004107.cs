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
        
        // 现代化主题相关字段
        private bool isDarkTheme = false;

        public Form1()
        {
            InitializeComponent();
            dataAccess = new dms.DataAccess();
            
            // 应用现代化UI设计
            ApplyModernUI();
            
            // 隐藏团队成员照片和信息
            HideTeamPhotos();
        }

        /// <summary>
        /// 应用现代化UI设计
        /// </summary>
        private void ApplyModernUI()
        {
            // 设置窗体现代化样式
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 240, 240); // 浅灰色背景
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // 现代化菜单按钮样式
            StyleMenuButtons();
            
            // 现代化标题栏
            StyleTitleBar();
            
            // 现代化数据网格
            StyleDataGridView();
        }

        /// <summary>
        /// 现代化菜单按钮样式
        /// </summary>
        private void StyleMenuButtons()
        {
            var menuButtons = new[] { d_m, s_m, i_o, i_c, high };
            
            foreach (Button btn in menuButtons)
            {
                if (btn != null)
                {
                    // 现代化按钮样式
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(52, 152, 219); // 现代蓝色
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    btn.Cursor = Cursors.Hand;
                    
                    // 添加鼠标悬停效果
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(41, 128, 185); // 深蓝色
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.BackColor != Color.FromArgb(230, 126, 34))
            {
                btn.BackColor = Color.FromArgb(52, 152, 219);
            }
        }

        /// <summary>
        /// 现代化标题栏样式
        /// </summary>
        private void StyleTitleBar()
        {
            if (main_top != null)
            {
                main_top.BackColor = Color.FromArgb(44, 62, 80); // 深色标题栏
                main_top.ForeColor = Color.White;
                main_top.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                main_top.TextAlign = ContentAlignment.MiddleLeft;
                main_top.Padding = new Padding(15, 0, 0, 0);
            }

            // 现代化关闭和最小化按钮
            var controlButtons = new[] { close, small, down };
            foreach (Label btn in controlButtons)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Cursor = Cursors.Hand;
                    
                    btn.MouseEnter += ControlButton_MouseEnter;
                    btn.MouseLeave += ControlButton_MouseLeave;
                }
            }
        }

        private void ControlButton_MouseEnter(object sender, EventArgs e)
        {
            Label btn = sender as Label;
            if (btn != null)
            {
                if (btn == close)
                    btn.BackColor = Color.FromArgb(231, 76, 60); // 红色
                else
                    btn.BackColor = Color.FromArgb(52, 73, 94); // 深灰色
            }
        }

        private void ControlButton_MouseLeave(object sender, EventArgs e)
        {
            Label btn = sender as Label;
            if (btn != null)
            {
                btn.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// 现代化数据网格样式
        /// </summary>
        private void StyleDataGridView()
        {
            if (dataGridView0 != null)
            {
                // 现代化DataGridView样式
                dataGridView0.BackgroundColor = Color.White;
                dataGridView0.BorderStyle = BorderStyle.None;
                dataGridView0.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView0.RowHeadersVisible = false;
                dataGridView0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView0.MultiSelect = false;
                dataGridView0.AllowUserToAddRows = false;
                dataGridView0.AllowUserToDeleteRows = false;
                dataGridView0.ReadOnly = true;
                
                // 列标题样式
                dataGridView0.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
                dataGridView0.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView0.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dataGridView0.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
                dataGridView0.ColumnHeadersHeight = 40;
                
                // 行样式
                dataGridView0.DefaultCellStyle.BackColor = Color.White;
                dataGridView0.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                dataGridView0.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                dataGridView0.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 230);
                dataGridView0.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
                dataGridView0.RowTemplate.Height = 35;
                
                // 交替行颜色
                dataGridView0.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            }
        }

        /// <summary>
        /// 隐藏团队成员照片和信息
        /// </summary>
        private void HideTeamPhotos()
        {
            var teamControls = new Control[] 
            { 
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                label1, label2, label3, label4, label9
            };
            
            foreach (var control in teamControls)
            {
                if (control != null)
                    control.Visible = false;
            }
        }

        /// <summary>
        /// 设置按钮激活状态
        /// </summary>
        private void SetActiveButton(Button activeButton)
        {
            var menuButtons = new[] { d_m, s_m, i_o, i_c, high };
            
            foreach (Button btn in menuButtons)
            {
                if (btn != null)
                {
                    if (btn == activeButton)
                    {
                        // 激活状态 - 橙色
                        btn.BackColor = Color.FromArgb(230, 126, 34);
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        // 非激活状态
                        btn.BackColor = Color.FromArgb(52, 152, 219);
                        btn.ForeColor = Color.White;
                    }
                }
            }
        }

        /// <summary>
        /// 切换深色/浅色主题
        /// </summary>
        public void ToggleTheme()
        {
            isDarkTheme = !isDarkTheme;
            ApplyTheme();
        }

        /// <summary>
        /// 应用主题颜色
        /// </summary>
        private void ApplyTheme()
        {
            if (isDarkTheme)
            {
                // 深色主题
                this.BackColor = Color.FromArgb(32, 32, 32);
                
                if (main_top != null)
                {
                    main_top.BackColor = Color.FromArgb(24, 24, 24);
                    main_top.ForeColor = Color.White;
                }
                
                if (menu_panel != null)
                {
                    menu_panel.BackColor = Color.FromArgb(40, 40, 40);
                }
                
                // 深色主题按钮颜色
                var menuButtons = new[] { d_m, s_m, i_o, i_c, high };
                foreach (Button btn in menuButtons)
                {
                    if (btn != null)
                    {
                        btn.BackColor = Color.FromArgb(70, 70, 70);
                        btn.ForeColor = Color.White;
                    }
                }
                
                if (dataGridView0 != null)
                {
                    dataGridView0.BackgroundColor = Color.FromArgb(45, 45, 45);
                    dataGridView0.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    dataGridView0.DefaultCellStyle.ForeColor = Color.White;
                    dataGridView0.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
                    dataGridView0.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(55, 55, 55);
                }
            }
            else
            {
                // 浅色主题
                this.BackColor = Color.FromArgb(240, 240, 240);
                
                if (main_top != null)
                {
                    main_top.BackColor = Color.FromArgb(44, 62, 80);
                    main_top.ForeColor = Color.White;
                }
                
                if (menu_panel != null)
                {
                    menu_panel.BackColor = Color.FromArgb(250, 250, 250);
                }
                
                // 浅色主题按钮颜色
                var menuButtons = new[] { d_m, s_m, i_o, i_c, high };
                foreach (Button btn in menuButtons)
                {
                    if (btn != null)
                    {
                        btn.BackColor = Color.FromArgb(52, 152, 219);
                        btn.ForeColor = Color.White;
                    }
                }
                
                if (dataGridView0 != null)
                {
                    dataGridView0.BackgroundColor = Color.White;
                    dataGridView0.DefaultCellStyle.BackColor = Color.White;
                    dataGridView0.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                    dataGridView0.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
                    dataGridView0.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
                }
            }
        }
    }
}
