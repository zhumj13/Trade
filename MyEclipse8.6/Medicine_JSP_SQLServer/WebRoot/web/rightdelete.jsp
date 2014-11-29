<%@ page language="java" contentType="text/html; charset=utf-8"
    pageEncoding="utf-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Insert title here</title>
</head>
<%@ page import="com.sql.*"  %>
<%@ page import="com.table.*"  %>
<%@ page import="java.util.*"  %>
<%
String medicineName = request.getParameter("medicineName");
ConnectSqlServer connectSqlServer = new ConnectSqlServer();
connectSqlServer.deleteMedicine(medicineName);
 %>
<body>
<form  action="right.jsp" method="get">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td>
<div align="center">
                <input type="submit" value="确定"></div>
</td>
</tr>
</table>
</form>
</body>
</html>