using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using StudentSys.BLL;
using StudentSys.Models;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FormStuSys
{
    public partial class Form_Stu_Info : Form
    {


        public Form_Stu_Info()
        {
            
            InitializeComponent();
        }

        #region 事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAllStuInfo_Load(object sender, EventArgs e)
        {
            Bound();
        }

        #region 查询按钮
        /// <summary>
        /// 根据条件查询学生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {

            string txtValues = this.txtValues.Text.ToString().Trim();
            if (txtValues == "" || txtValues == null)
            {
                this.Bound();

            }
            else
            {
                //判断是否有非法字符
                if (StudentManager.checkText(txtValues) == false)
                {
                    MessageBox.Show("含有非法字符");

                }
                else
                {
                    try{
                        //获取下拉列表的值
                        string id = this.cboSelectValues.SelectedValue.ToString().Trim();
                        if (id.Trim().Equals("0"))
                        {
                            int no = Convert.ToInt32(txtValues);
                            this.dgvStuInfo.DataSource = StudentManager.GetAllInfoByStuIdAndStuName(no, "").Tables[0];
                        }
                        else
                        {
                            string txt = txtValues;
                            this.dgvStuInfo.DataSource = StudentManager.GetAllInfoByStuIdAndStuName(-1, txt).Tables[0];
                        }
                    
                    }catch{

                        MessageBox.Show("输入格式不正确");
                    }
                   
                }
            }

        }
        #endregion

        #region 右键菜单-->修改
        /// <summary>
        /// 右键菜单-->修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.dgvStuInfo.SelectedRows[0].Cells["StuNo"].Value.ToString());
            Form_Stu_Change sc = new Form_Stu_Change();
            sc.ControlTxt = "修改";
            sc.StuNo = id;
            DialogResult dr = sc.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("修改成功");
                this.Bound();
            }



        }
        #endregion

        #region 右键菜单-->增加
        /// <summary>
        /// 右键菜单-->增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            Form_Stu_Change sc = new Form_Stu_Change();
            sc.ControlTxt = "新增";
            DialogResult dr = sc.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("增加成功");
                this.Bound();
            }
        }
        #endregion

        #region 右键菜单-->删除
        /// <summary>
        /// 右键菜单-->删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.dgvStuInfo.CurrentRow.Cells["StuNo"].Value.ToString());
            DialogResult dr = System.Windows.Forms.DialogResult.None;
            try
            {

                int result = StudentManager.DelStuInfo(id);
                if (result != 0)
                {
                    dr = MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK);
                    this.Bound();
                }
            }
            catch
            {
                dr = MessageBox.Show("删除失败");
            }


        }
        #endregion

        #region 右键单击选中事件
        private void dgvStuInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.RowIndex >= 0)
                {
                    if (!this.dgvStuInfo.Rows[e.RowIndex].Selected)
                    {
                        this.dgvStuInfo.ClearSelection();
                        this.dgvStuInfo.Rows[e.RowIndex].Selected = true;
                    }

                }
                this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }


        #endregion

        #endregion


        #region 方法

        #region 加载数据
        /// <summary>
        /// 绑定学生信息
        /// </summary>
        private void Bound()
        {

            this.BoundDDL();
            this.dgvStuInfo.DataSource = StudentManager.GetAllInfo().Tables[0];
            //通过遍历，设置显示的性别的值
            foreach (DataGridViewRow dgvr in this.dgvStuInfo.Rows)
            {
                if (dgvr.Cells["Sex"].Value != null)
                {

                    if (dgvr.Cells["Sex"].Value.ToString() == "0")
                    {
                        dgvr.Cells["Rsex"].Value = "女";
                    }
                    if (dgvr.Cells["Sex"].Value.ToString() == "1")
                    {
                        dgvr.Cells["Rsex"].Value = "男";
                    }
                }
            }


        }


        //绑定下拉列表
        private void BoundDDL()
        {

            DataTable dtSelect = new DataTable();//新建数据表
            dtSelect.Columns.Add("Value");//设置两个字段
            dtSelect.Columns.Add("Name");
            DataRow drSex = dtSelect.NewRow();
            drSex[0] = "学号";
            drSex[1] = "0";
            dtSelect.Rows.Add(drSex);
            drSex = dtSelect.NewRow();
            drSex[0] = "姓名";
            drSex[1] = "1";
            dtSelect.Rows.Add(drSex);


            this.cboSelectValues.ValueMember = "Name";//设置combox值
            this.cboSelectValues.DisplayMember = "Value";//设置combox显示值
            this.cboSelectValues.DataSource = dtSelect;//将数据表绑定到combox中
            this.cboSelectValues.DropDownStyle = ComboBoxStyle.DropDownList;//设置combox编辑模式


        }
        #endregion

        #endregion



    }
}
