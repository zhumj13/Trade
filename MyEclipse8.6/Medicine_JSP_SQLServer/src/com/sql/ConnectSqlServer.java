package com.sql;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

import com.table.Medicine;
import com.table.UserInfo;

public class ConnectSqlServer {
	String JDriver = "com.microsoft.sqlserver.jdbc.SQLServerDriver";// SQL���ݿ�����
	String connectDB = "jdbc:sqlserver://127.0.0.1:1433;DatabaseName=medicine";// ����Դע��IP��ַ�Ͷ˿ںţ����ݿ����֣�����
	String user = "sa"; // ���Լ��������û����ֺ����룡����������������������
	String password = "sa";
	Connection con;
	Statement stmt; // ����SQL�������
	ResultSet rs;

	public static void main(String args[]) {
		ConnectSqlServer connectSqlServer = new ConnectSqlServer();
		//connectSqlServer.connenctData();
/*		ResultSet rs = connectSqlServer.query();
		try {
			while (rs.next()) {
				// ���ÿ���ֶ�
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
			Class.forName(JDriver);// �������ݿ����棬���ظ����ַ���������
		} catch (ClassNotFoundException e) {
			System.out.println("�������ݿ�����ʧ��");
			System.exit(0);
		}
		System.out.println("���ݿ������ɹ�");
		try {
			con = DriverManager.getConnection(connectDB, user, password); // �������ݿ����
			System.out.println("�������ݿ�ɹ�");
			stmt = con.createStatement();
		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}

	}
	public ResultSet query() {
		try {

			connenctData();
			// ������
			System.out.println("��ѯ");
			System.out.println("��ʼ��ȡ����");
			rs = stmt.executeQuery("select * from userInfo");// ����SQL����ѯ�����(����)
			while (rs.next()) {
				// ���ÿ���ֶ�
				System.out.println(rs.getString("userName") + "\t"
						+ rs.getString("passWord"));
			}
			// ѭ�����ÿһ����¼
			System.out.println("��ȡ���");
			// �ر�����
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����

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
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// ����SQL����ѯ�����(����)

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
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// ����SQL����ѯ�����(����)
	}
	public void deleteUser(String userName)
	{
		connenctData();
		try {
			String sql="delete from userInfo where userName='"+userName+"'";
			stmt.execute(sql);
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// ����SQL����ѯ�����(����)

	}
	public void deleteMedicine(String medicineName)
	{
		connenctData();
		try {
			String sql="delete from medicine where medicineName='"+medicineName+"'";
			stmt.execute(sql);
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// ����SQL����ѯ�����(����)		
	}
	public void updateUser(UserInfo userInfo,String userName)
	{
		connenctData();
		try {
			String sql="update  userInfo set userName='"+userInfo.getUserName()+
			"'"+",passWord='"+userInfo.getPassWord()
			+"' where userName='"+userName+"'";
			stmt.execute(sql);
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// ����SQL����ѯ�����(����)
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
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}// ����SQL����ѯ�����(����)
	}
	public List<UserInfo> queryUserInfo()
	{
		List<UserInfo> userInfoList= new ArrayList<UserInfo>();
		try {
			connenctData();
			rs = stmt.executeQuery("select * from userInfo");// ����SQL����ѯ�����(����)
			while (rs.next()) {
				UserInfo userInfo =new UserInfo();
				userInfo.setUserName(rs.getString("userName"));
				userInfo.setPassWord(rs.getString("passWord"));
				userInfoList.add(userInfo);
			}
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����

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
			rs = stmt.executeQuery("select * from medicine");// ����SQL����ѯ�����(����)
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
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����

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
			rs = stmt.executeQuery("select * from userInfo");// ����SQL����ѯ�����(����)
			while (rs.next()) {
				UserInfo userInfo =new UserInfo();
				userInfo.setUserName(rs.getString("userName"));
				userInfo.setPassWord(rs.getString("passWord"));
				if(username.equals(userInfo.getUserName())&&password.equals(userInfo.getPassWord()))
				{
					return true;
				}
			}
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����

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
			rs = stmt.executeQuery(sql);// ����SQL����ѯ�����(����)
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
			stmt.close(); // �ر������������
			con.close(); // �ر����ݿ�����

		} catch (SQLException e) {
			e.printStackTrace();
			System.exit(0);
		}
		return medicineList;
	}
}
