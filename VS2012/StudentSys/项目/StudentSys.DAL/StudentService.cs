using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentSys.Models;
namespace StudentSys.DAL
{
    public static class StudentService
    {

        #region 查询学生信息

        #region 通过学号查询学生信息
        /// <summary>
        /// 通过学号查询学生信息
        /// </summary>
        /// <param name="id">学号</param>
        /// <param name="name">姓名</param>
        /// <returns>各个属性值</returns>
        public static StudentInfo getStuInfoById(int id, string name)
        {
            string sqlWhere = "";

            if (id != -1)
            {
                sqlWhere = "  StuNo=@Id";
            }
            else
            {
                sqlWhere = "  StuName=@name";
            }
            string sql = "select * from StudentInfo where" + sqlWhere;
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",id),
                new SqlParameter("@name",name)
            };

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, para))
            {
                StudentInfo stu = null;
                while (dr.Read())
                {

                    stu = new StudentInfo();
                    stu.StuName = dr["StuName"].ToString();
                    stu.sex = Convert.ToInt32(dr["Sex"]);
                    stu.tel = Convert.ToInt32(dr["Tel"]);
                    stu.address = dr["Address"].ToString();


                }
                return stu;
            }


        }
        #endregion

        #region 通过学号或姓名查询学生信息
        /// <summary>
        /// 通过学号或姓名查询学生信息
        /// </summary>
        /// <param name="id">学号</param>
        /// <param name="txt">姓名</param>
        /// <returns>符合要求的学生信息</returns>
        public static DataSet GetAllInfoByStuIdAndStuName(int id, string txt)
        {
            string sql = "";
            sql = "select * from StudentInfo";

            if (id != -1)
            {
                sql += " where  StuNo=@id";
            }
            else if (txt.Trim() != "" || txt != null)
            {
                sql += " where  StuName like '%'+@text+'%' ";
            }


            SqlParameter[] para = new SqlParameter[]{
                 new SqlParameter("@id",id),
                 new SqlParameter("@text",txt)
            };

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql, para);
            return ds;
        }
        #endregion

        #region 查询学生基本信息
        /// <summary>
        /// 查询所有学生基本信息
        /// </summary>
        /// <returns>学生基本信息集合</returns>
        public static DataSet GetStuInfo()
        {
            string sql = "select * from StudentInfo";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql, null);
            return ds;
        }

        public static List<StudentInfo> GetAllStu()
        {
            List<StudentInfo> listu = new List<StudentInfo>();
            string sql = "select * from StudentInfo";
           
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {

                while (dr.Read())
                {
                    StudentInfo stu = new StudentInfo();
                    stu.StuNo = Convert.ToInt32(dr["StuNo"]);
                    stu.StuName = dr["StuNo"].ToString()+ "-->" +dr["StuName"].ToString()  ;
                    listu.Add(stu);
                }

            }

            return listu;
        }
        #endregion

        #endregion

        #region 增加学生信息
        /// <summary>
        /// 增加学生信息
        /// </summary>
        /// <param name="student">实体类</param>
        /// <returns>影响的条数</returns>
        public static int AddStudent(StudentInfo student)
        {
            int result = 0;
            string sql = "";
            sql = @"insert into [StudentInfo]( StuName,Sex ,Tel , Address)
                  values('{0}',{1},{2},'{3}')";


            sql = String.Format(sql, student.StuName, student.sex, student.tel, student.address);

            result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, null);

            return result;
        }
        #endregion

        #region 修改学生信息
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="student">学生类</param>
        /// <param name="id">学号</param>
        /// <returns>受影响的行数</returns>
        public static int UpdataStuInfo(StudentInfo student, int id)
        {
            int result = 0;
            string sql = "";
            sql = "update StudentInfo set StuName=@stuName,Sex=@sex,Tel=@tel, Address=@address where StuNo=@id ";

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@stuName",student.StuName),
                new SqlParameter("@sex",student.sex),
                new SqlParameter("@tel",student.tel),
                new SqlParameter("@address",student.address),
                new SqlParameter("@id",id)   
            };


            result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, para);

            return result;

        }
        #endregion

        #region 根据学号删除学生信息
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id">学号</param>
        /// <returns>受影响的行数</returns>
        public static int DelStuInfo(int id)
        {

            int result = 0;
            string sql = "";
            sql = "delete from StudentInfo where StuNo=@id ";

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@id",id)

            };
            result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, para);

            return result;

        }
        #endregion

    }
}
