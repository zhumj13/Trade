using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StudentSys.DAL;
using StudentSys.Models;
using System.Text.RegularExpressions;
namespace StudentSys.BLL
{
    public class StudentManager
    {
        #region 判断是否存在非法字符
        /// <summary>
        /// 判断是否存在非法字符
        /// </summary>
        /// <param name="txt">字符串</param>
        /// <returns></returns>
        public static bool checkText(string txt)
        {
            Regex regExp = new Regex("[~!@#$%^&*()=+[\\]{}''\";:/?.,><`|！·￥…—（）\\-、；：。，》《]");
            return !regExp.IsMatch(txt);
        }
        #endregion

        #region 查询学生信息
        /// <summary>
        /// 查询学生基本信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllInfo()
        {
            return StudentService.GetStuInfo();
        }
        #endregion
        public static List<StudentInfo> GetAllStu() {

            return StudentService.GetAllStu();
        }

        #region 通过学号查询对应学生信息
        /// <summary>
        /// 通过学号查询学生基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static StudentInfo GetStuInfoById(int id,string name) {
            return StudentService.getStuInfoById(id,name);
        }
        #endregion

        #region 通过学号或姓名查询学生信息
        /// <summary>
        /// 通过条件进行查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>学生基本信息</returns>
        public static DataSet GetAllInfoByStuIdAndStuName(int id, string txt)
        {
            return StudentService.GetAllInfoByStuIdAndStuName(id, txt);
        }
        #endregion

        #region 添加学生信息
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int AddStudent(StudentInfo st)
        {
            return StudentService.AddStudent(st);

        }
        #endregion

        #region 修改学生信息
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int UpdataStuInfo(StudentInfo student, int id)
        {

            return StudentService.UpdataStuInfo(student, id);
        }
        #endregion

        #region 删除学生信息
        /// <summary>
        /// 根据学号删除学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DelStuInfo(int id)
        {
            return StudentService.DelStuInfo(id);
        }
        #endregion
    }
}
