using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentSys.Models
{
    /// <summary>
    /// 学员信息类
    /// </summary>
    [Serializable]
    public class StudentInfo
    {
        public int StuNo { get; set; } //学员编号
        public string StuName { get; set; }  //学生姓名
        public int sex { get; set; }  //性别
        public int tel { get; set; }  //电话
        public string  address { get; set; } //住址
    }
}
