using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormStuSys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //COMMON.SetFormSkin.setSkin(this.skinEngineLogin, @"\Skins\Wave\Wave.ssk");

            //MessageBox.Show(skinEngine1.SkinFile);

            //this.textBoxRealValidateCode.Text = COMMON.ValidateCode.GenerateValidateCode(4);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Common.MD5Handle.HashMD5(this.textBoxPassword.Text.ToLower()));
            //MODEL.CheckInfo checkInfo = new MODEL.CheckInfo();
            //checkInfo.userName = this.textBoxUserName.Text;
            //checkInfo.password = this.textBoxPassword.Text;
            //checkInfo.userVCode = this.textBoxUserValidateCode.Text;
            //checkInfo.realVCode = this.textBoxRealValidateCode.Text;
            string userName = this.textBoxUserName.Text;
            string password = this.textBoxPassword.Text;
            if (userName == "hello" && password == "hello")
            {
               Form_Stu_Info fs= new Form_Stu_Info();
               this.Hide();
               fs.Show();
               
            }
            else
            {
                MessageBox.Show("用户名或者密码错误~");
            }
            //if (!userInfoBll.checkUserLoginInfo(checkInfo))
            //{
            //    this.textBoxRealValidateCode.Text = COMMON.ValidateCode.GenerateValidateCode(4);
            //    return;
            //}

            //UserInfo userInfo = new UserInfo();
            //userInfo.userName = this.textBoxUserName.Text;
            //userInfo.password = COMMON.MD5Handle.MD5Encrypt(this.textBoxPassword.Text.ToLower());

            //if (userInfoBll.QueryUserInfo(userInfo) != null)
            //{
            //    MainForm form = new MainForm();
            //    form.Relogin += new EventHandler(form_Relogin);
            //    form.userName = this.textBoxUserName.Text;
            //    form.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("用户名或密码错误，请重新输入！");
            //    this.textBoxRealValidateCode.Text = COMMON.ValidateCode.GenerateValidateCode(4);
            //}
        }

        void form_Relogin(object sender, EventArgs e)
        {
            this.Show();
            this.textBoxUserName.Text = "";
            this.textBoxPassword.Text = "";
           // this.textBoxUserValidateCode.Text = "";
           // this.textBoxRealValidateCode.Text = COMMON.ValidateCode.GenerateValidateCode(4);
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.buttonLogin.Focus();
                this.buttonLogin.PerformClick();
            }
        }

        private void textBoxValidateCode_MouseClick(object sender, MouseEventArgs e)
        {
         //   this.textBoxRealValidateCode.Text = COMMON.ValidateCode.GenerateValidateCode(4);
        }

        private void textBoxUserValidateCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.buttonLogin.Focus();
                this.buttonLogin.PerformClick();
            }
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            //RegistForm form = new RegistForm();
            //form.Login += new EventHandler(form_Login);
            //form.Show();
            //this.Hide();
        }

        private void form_Login(object sender, EventArgs e)
        {
            this.Show();
            this.textBoxUserName.Text = "";
            this.textBoxPassword.Text = "";
           // this.textBoxUserValidateCode.Text = "";
           // this.textBoxRealValidateCode.Text = COMMON.ValidateCode.GenerateValidateCode(4);
        }
    }
}
