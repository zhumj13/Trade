package com.sql;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

import com.table.Medicine;
import com.table.UserInfo;

public class ConnectSqlServer {
	String JDriver = "com.microsoft.sqlserver.jdbc.SQLServerDriver";// SQL数据库引擎
	String connectDB = "jdbc:sqlserver://127.0.0.1:1433;DatabaseName=medicine";// 数据源注意IP地址和端口号，数据库名字！！！
	String user = "sa"; // 你自己创建的用户名字和密码！！！！！！！！！！！！
	String password = "sa";
	Connection con;
	Statement stmt; // 创建SQL命令对象
	ResultSet rs;

	public static void main(String args[]) {
		ConnectSqlServer connectSqlServer = new ConnectSqlServer();
		//connectSqlServer.connenctData();
/*		ResultSet rs = connectSqlServer.query();
		try {
			while (rs.next()) {
				// 输出每个字段
				System.out.println(rs.getString("userName") + "\t"
						+ rs.getString("passWord"));
			}
		} catch (Exception e) {

		}*/
/*		UserInfo userInfo=new UserInfo();
		userInfo.setUserName("6");
		userInfo.setPassWord("6");
		//connectSqlServer.addUser(userInfo);
		connectSqlServer.updateUser(userInfo,"1");*/
		//connectSqlServer.deleteUser("6");
		String t="f";
		Medicine medicine=new Medicine();
		medicine.setMedicineName(t);
		medicine.setAbbrebiation(t);
		medicine.setMainContent(t);
		medicine.setEffect(t);
		medicine.setUseMethod(t);
		medicine.setTaboo(t);
		medicine.setFactory(t);
		medicine.setComment(t);
		//connectSqlServer.addMedicine(medicine);
		connectSqlServer.updateMedicine(medicine, "a");
		//connectSqlServer.deleteMedicine("e");
	}

	public void connenctData() {
		try {
			Class.forName(JDriver);// 加载数据库引擎，返回给定字符串名的类
		} catch (ClassNotFoundException e) {
			System.out.println("加载数据库引擎失败");
			System.exit(0);
		}
		System.out.println("数据库驱动成功");
		try {
			con = DriverManager.getConnection(connectDB, user, password); // 连接数据库对象
			System.out.println("连接数据库成功");
			stmt = con.createStatement();
		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}

	}
	public ResultSet query() {
		try {

			connenctData();
			// 创建表
			System.out.println("查询");
			System.out.println("开始读取数据");
			rs = stmt.executeQuery("select * from userInfo");// 返回SQL语句查询结果集(集合)
			while (rs.next()) {
				// 输出每个字段
				System.out.println(rs.getString("userName") + "\t"
						+ rs.getString("passWord"));
			}
			// 循环输出每一条记录
			System.out.println("读取完毕");
			// 关闭连接
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接

		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}
		return rs;
	}
	public void addUser(UserInfo userInfo)
	{
		connenctData();
		try {
			String sql="insert into userInfo values('"+userInfo.getUserName()+"'"+",'"+userInfo.getPassWord()+"')";
			stmt.execute(sql);
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// 返回SQL语句查询结果集(集合)

	}
	public void addMedicine(Medicine medicine)
	{
		connenctData();
		try {
			String sql="insert into medicine values('"+medicine.getMedicineName()+
			"'"+",'"+medicine.getAbbrebiation()+
			"'"+",'"+medicine.getMainContent()+
			"'"+",'"+medicine.getEffect()+
			"'"+",'"+medicine.getUseMethod()+
			"'"+",'"+medicine.getTaboo()+
			"'"+",'"+medicine.getFactory()+
			"'"+",'"+medicine.getComment()+"')"; 
			stmt.execute(sql);
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// 返回SQL语句查询结果集(集合)
	}
	public void deleteUser(String userName)
	{
		connenctData();
		try {
			String sql="delete from userInfo where userName='"+userName+"'";
			stmt.execute(sql);
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// 返回SQL语句查询结果集(集合)

	}
	public void deleteMedicine(String medicineName)
	{
		connenctData();
		try {
			String sql="delete from medicine where medicineName='"+medicineName+"'";
			stmt.execute(sql);
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// 返回SQL语句查询结果集(集合)		
	}
	public void updateUser(UserInfo userInfo,String userName)
	{
		connenctData();
		try {
			String sql="update  userInfo set userName='"+userInfo.getUserName()+
			"'"+",passWord='"+userInfo.getPassWord()
			+"' where userName='"+userName+"'";
			stmt.execute(sql);
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// 返回SQL语句查询结果集(集合)
	}
	public void updateMedicine(Medicine medicine,String medicineName)
	{
		connenctData();
		try {
			String sql="update medicine set medicineName='"+medicine.getMedicineName()+
			"'"+",abbrebiation='"+medicine.getAbbrebiation()+
			"'"+",mainContent='"+medicine.getMainContent()+
			"'"+",effect='"+medicine.getEffect()+
			"'"+",useMethod='"+medicine.getUseMethod()+
			"'"+",taboo='"+medicine.getTaboo()+
			"'"+",factory='"+medicine.getFactory()+
			"'"+",comment='"+medicine.getComment()+
			"' where medicineName='"+medicineName+"'"; 
			stmt.execute(sql);
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// 返回SQL语句查询结果集(集合)
	}
	public List<UserInfo> queryUserInfo()
	{
		List<UserInfo> userInfoList= new ArrayList<UserInfo>();
		try {
			connenctData();
			rs = stmt.executeQuery("select * from userInfo");// 返回SQL语句查询结果集(集合)
			while (rs.next()) {
				UserInfo userInfo =new UserInfo();
				userInfo.setUserName(rs.getString("userName"));
				userInfo.setPassWord(rs.getString("passWord"));
				userInfoList.add(userInfo);
			}
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接

		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}
		return userInfoList;
	}
	public List<Medicine> queryMedicine()
	{
		List<Medicine> medicineList= new ArrayList<Medicine>();
		try {
			connenctData();
			rs = stmt.executeQuery("select * from medicine");// 返回SQL语句查询结果集(集合)
			while (rs.next()) {
				Medicine medicine = new Medicine();
				medicine.setMedicineName(rs.getString("medicineName"));
				medicine.setAbbrebiation(rs.getString("abbrebiation"));
				medicine.setMainContent(rs.getString("mainContent"));
				medicine.setEffect(rs.getString("effect"));
				medicine.setUseMethod(rs.getString("useMethod"));
				medicine.setTaboo(rs.getString("taboo"));
				medicine.setFactory(rs.getString("factory"));
				medicine.setComment(rs.getString("comment"));
				medicineList.add(medicine);
			}
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接

		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}
		return medicineList;
	}
    public Boolean judge(String username,String password)
    {
    	if(username==null||username.equals(null)||password==null||password.equals(null))
    		return false;
		try {
			connenctData();
			rs = stmt.executeQuery("select * from userInfo");// 返回SQL语句查询结果集(集合)
			while (rs.next()) {
				UserInfo userInfo =new UserInfo();
				userInfo.setUserName(rs.getString("userName"));
				userInfo.setPassWord(rs.getString("passWord"));
				if(username.equals(userInfo.getUserName())&&password.equals(userInfo.getPassWord()))
				{
					return true;
				}
			}
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接

		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}
    	return false;
    }
	public void queryUserInfo(String userName)
	{
		
	}
	public List<Medicine> queryMedicine(String medicineName)
	{
		String sql;
    	if(medicineName==null||medicineName.equals(null))
    	{
    		sql="select * from medicine";
    	}
    	else
    	{
    		sql="select * from medicine where abbrebiation like '%"+medicineName+"%'";
    	}
		List<Medicine> medicineList= new ArrayList<Medicine>();
		try {
			connenctData();
			rs = stmt.executeQuery(sql);// 返回SQL语句查询结果集(集合)
			while (rs.next()) {
				Medicine medicine = new Medicine();
				medicine.setMedicineName(rs.getString("medicineName"));
				medicine.setAbbrebiation(rs.getString("abbrebiation"));
				medicine.setMainContent(rs.getString("mainContent"));
				medicine.setEffect(rs.getString("effect"));
				medicine.setUseMethod(rs.getString("useMethod"));
				medicine.setTaboo(rs.getString("taboo"));
				medicine.setFactory(rs.getString("factory"));
				medicine.setComment(rs.getString("comment"));
				medicineList.add(medicine);
			}
			stmt.close(); // 关闭命令对象连接
			con.close(); // 关闭数据库连接

		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}
		return medicineList;
	}
}
