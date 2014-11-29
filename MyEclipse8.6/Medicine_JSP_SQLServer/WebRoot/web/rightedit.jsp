<%@ page language="java" contentType="text/html; charset=utf-8"
    pageEncoding="utf-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Insert title here</title>
</head>
<body>
<%@ page import="com.sql.*"  %>
<%@ page import="com.table.*"  %>
<%@ page import="java.util.*"  %>
<%
String a = request.getParameter("a");
String b = request.getParameter("b");
String c = request.getParameter("c");
String d = request.getParameter("d");
String e = request.getParameter("e");
String f = request.getParameter("f");
String g = request.getParameter("g");
String h = request.getParameter("h");
		Medicine medicine=new Medicine();
		medicine.setMedicineName(a);
		medicine.setAbbrebiation(b);
		medicine.setMainContent(c);
		medicine.setEffect(d);
		medicine.setUseMethod(e);
		medicine.setTaboo(f);
		medicine.setFactory(g);
		medicine.setComment(h);
ConnectSqlServer connectSqlServer = new ConnectSqlServer();
connectSqlServer.updateMedicine(medicine,a);
 %>
<form  action="right.jsp" method="get">
<table width="100%" border="10" align="center" cellpadding="0" cellspacing="0">
<tr>
<td>
<div align="center"><input type="submit" value="确定"></div>
</td>
</tr>
</table>
</form>
</body>
</html>