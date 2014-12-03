using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentSys.Models;
using StudentSys.BLL;
namespace FormStuSys
{
    public partial class Form_Stu_Change : Form
    {
        public string ControlTxt { get; set; }
        public int StuNo { get; set; }

        public Form_Stu_Change()
        {
            InitializeComponent();
        }
        #region 事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddStuInfo_Load(object sender, EventArgs e)
        {
            if (ControlTxt != "新增")
            {
                this.Bound();
            }

        }

        #region 取消事件按钮
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        #endregion

        #region 确定按钮
        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (ControlTxt.Trim() == "新增")
            {

                AddStuInfo();
            }
            else
            {
                UpdateStuInfo();
            }


        }
        #endregion

        #endregion

        #region 方法

        #region 增加学生信息方法
        /// <summary>
        /// 新增学生信息
        /// </summary>
        private void AddStuInfo()
        {
            try
            {

                string Name = this.txtName.Text.Trim();
                int sex = this.rdoMan.Checked == true ? 1 : 0;

                int tel = 0;
                if (this.txtTel.Text.Trim() == "" || this.txtTel.Text.Trim() == null)
                {
                    tel = 0;
                }
                else
                {
                    tel = Convert.ToInt32(this.txtTel.Text.Trim());
                }
                string address = this.txtAddress.Text.Trim();
                if (StudentManager.checkText(Name) == false || StudentManager.checkText(tel.ToString()) == false || StudentManager.checkText(address) == false)
                {
                    MessageBox.Show("含有非法字符");

                }
                else
                {
                    StudentInfo stu = new StudentInfo();
                    stu.StuName = Name;
                    stu.sex = sex;
                    stu.tel = tel;
                    stu.address = address;

                    int addResult = StudentManager.AddStudent(stu);
                    if (addResult != 0)
                    {


                        this.DialogResult = System.Windows.Forms.DialogResult.OK;


                    }
                }
            }
            catch
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MessageBox.Show("输入格式不正确");
            }

        }
        #endregion

        #region 修改学生信息方法
        /// <summary>
        /// 修改学生信息
        /// </summary>
        private void UpdateStuInfo()
        {
            try
            {
                string Name = this.txtName.Text.Trim();
                int sex = this.rdoMan.Checked == true ? 1 : 0;

                int tel = 0;
                if (this.txtTel.Text.Trim() == "" || this.txtTel.Text.Trim() == null)
                {
                    tel = 0;
                }
                else
                {
                    tel = Convert.ToInt32(this.txtTel.Text.Trim());
                }
                string address = this.txtAddress.Text.Trim();

                StudentInfo stu = new StudentInfo();
                stu.StuName = Name;
                stu.sex = sex;
                stu.tel = tel;
                stu.address = address;

                int addResult = StudentManager.UpdataStuInfo(stu, StuNo);
                if (addResult != 0)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MessageBox.Show("修改失败");
            }

        }
        #endregion

        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void Bound()
        {

            StudentInfo stu = StudentManager.GetStuInfoById(StuNo, "");
            this.txtName.Text = stu.StuName;
            if (stu.sex == 1)
            {
                this.rdoMan.Checked = true;
            }
            else
            {
                this.rdoWomen.Checked = true;
            }
            this.txtTel.Text = stu.tel.ToString();
            this.txtAddress.Text = stu.address;

        }
        #endregion

        #endregion


    }
}
