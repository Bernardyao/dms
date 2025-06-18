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
        private Point offset = new Point(0, 0);
        public static int power = 0;
        public static int admin_id = 0;
        public static string admin_name = "";
        private DataTable dat;
        private dms.DataAccess dataAccess;

        public Form1()
        {
            InitializeComponent();
            
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
            
            dataAccess = new dms.DataAccess();
        }
    }
}
