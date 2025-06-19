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
    public partial class Login : Form
    {
        private Point offset;        public Login()
        {
            InitializeComponent();
            
            // 设置图标样式
            SetupIconAppearance();
            
            // 为用户名和密码输入框添加回车键事件处理
            user.KeyDown += TextBox_KeyDown;
            password.KeyDown += TextBox_KeyDown;
              // 添加用户输入提示
            SetupPlaceholders();
            
            // 添加悬停效果
            SetupHoverEffects();
        }
        
        /*
         * 设置图标外观
         */
        private void SetupIconAppearance()
        {
            // 设置用户图标
            user_pic.BackColor = Color.FromArgb(16, 110, 190);
            user_pic.BorderStyle = BorderStyle.None;
            user_pic.Size = new Size(43, 31);
            
            // 设置密码图标
            password_pic.BackColor = Color.FromArgb(16, 110, 190);
            password_pic.BorderStyle = BorderStyle.None;
            password_pic.Size = new Size(43, 31);
        }
        
        /*
         * 设置输入框占位符提示
         */
        private void SetupPlaceholders()
        {
            // 用户名输入框占位符
            user.Text = "请输入用户名";
            user.ForeColor = System.Drawing.Color.Gray;
            user.Enter += User_Enter;
            user.Leave += User_Leave;
            
            // 密码输入框占位符
            password.Text = "请输入密码";
            password.ForeColor = System.Drawing.Color.Gray;
            password.UseSystemPasswordChar = false;
            password.Enter += Password_Enter;
            password.Leave += Password_Leave;
        }
        
        /*
         * 用户名输入框获得焦点事件
         */
        private void User_Enter(object sender, EventArgs e)
        {
            if (user.Text == "请输入用户名")
            {
                user.Text = "";
                user.ForeColor = System.Drawing.Color.Black;
            }
        }
        
        /*
         * 用户名输入框失去焦点事件
         */
        private void User_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(user.Text))
            {
                user.Text = "请输入用户名";
                user.ForeColor = System.Drawing.Color.Gray;
            }
        }
        
        /*
         * 密码输入框获得焦点事件
         */
        private void Password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "请输入密码")
            {
                password.Text = "";
                password.ForeColor = System.Drawing.Color.Black;
                password.UseSystemPasswordChar = true;
            }
        }
        
        /*
         * 密码输入框失去焦点事件
         */
        private void Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                password.Text = "请输入密码";
                password.ForeColor = System.Drawing.Color.Gray;
                password.UseSystemPasswordChar = false;
            }
        }
        /*
         * 标题栏鼠标点下事件
         */
        private void login_top_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        /*
         * 标题栏鼠标移动事件
         */
        private void login_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        /*
         * 最小化按钮点击事件
         */
        private void small_Click(object sender, EventArgs e)
        {
            small.BackColor = System.Drawing.Color.Blue;
            this.WindowState = FormWindowState.Minimized;
        }
        /*
         * 最小化按钮鼠标移进事件
         */        private void small_MouseEnter(object sender, EventArgs e)
        {
            small.BackColor = System.Drawing.Color.FromArgb(16, 110, 190); // 深蓝色悬停效果
        }
        /*
         * 最小化按钮鼠标移出事件
         */
        private void small_MouseLeave(object sender, EventArgs e)
        {
            small.BackColor = System.Drawing.Color.FromArgb(0, 120, 215); // 恢复主题蓝色
        }
        /*
         * 关闭按钮点击事件
         */        private void close_Click(object sender, EventArgs e)
        {
            close.BackColor = System.Drawing.Color.FromArgb(139, 0, 0); // 深红色点击效果
            this.Close();
            this.Dispose();
        }
        /*
         * 最小化按钮鼠标移进事件
         */        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.BackColor = System.Drawing.Color.FromArgb(232, 17, 35); // 红色悬停效果
        }
        /*
         * 最小化按钮鼠标移出事件
         */
        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.BackColor = System.Drawing.Color.FromArgb(0, 120, 215); // 恢复主题蓝色
        }
        /*
         * 输入框回车键事件处理
         */
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 按下回车键时执行登录
                login_bt_Click(sender, e);
            }
        }        /*
         * 登陆按钮点击事件
         */
        private void login_bt_Click(object sender, EventArgs e)
        {
            string username = user.Text == "请输入用户名" ? "" : user.Text;
            string userpassword = password.Text == "请输入密码" ? "" : password.Text;
            
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userpassword))
            {
                MessageBox.Show("用户名和密码不能为空！", "提示");
                return;
            }
            if (ConnectDB.getInstance().Login(username, userpassword))
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                MessageBox.Show("用户不存在或密码错误！", "提示");
            }
        }
        /*
         * 用户名输入框鼠标进入事件 - 悬停效果
         */
        private void User_MouseEnter(object sender, EventArgs e)
        {
            user.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
        }
        
        /*
         * 用户名输入框鼠标离开事件 - 悬停效果
         */
        private void User_MouseLeave(object sender, EventArgs e)
        {
            user.BackColor = System.Drawing.Color.White;
        }
        
        /*
         * 密码输入框鼠标进入事件 - 悬停效果
         */
        private void Password_MouseEnter(object sender, EventArgs e)
        {
            password.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
        }
        
        /*
         * 密码输入框鼠标离开事件 - 悬停效果
         */
        private void Password_MouseLeave(object sender, EventArgs e)
        {
            password.BackColor = System.Drawing.Color.White;
        }
        /*
         * 设置悬停效果
         */
        private void SetupHoverEffects()
        {
            // 用户名输入框悬停效果
            user.MouseEnter += User_MouseEnter;
            user.MouseLeave += User_MouseLeave;
            
            // 密码输入框悬停效果
            password.MouseEnter += Password_MouseEnter;
            password.MouseLeave += User_MouseLeave;
        }    }
}
