<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" %>
    <jsp:useBean id="judge" scope="session" class="com.sql.ConnectSqlServer"/>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<STYLE type=text/css>BODY {
	BACKGROUND-COLOR: #f9f9f9; FONT-FAMILY: tahoma, arial, sans-serif; FONT-SIZE: 14px
}
.msgMain DIV {
	TEXT-ALIGN: center
}
.msgFrame {
	BORDER-BOTTOM: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; BACKGROUND-COLOR: #ffffff; MARGIN: 100px auto; WIDTH: 450px; BORDER-TOP: #cccccc 1px solid; BORDER-RIGHT: #cccccc 1px solid
}
.msgTitle {
	BORDER-BOTTOM: #cccccc 1px solid; PADDING-BOTTOM: 10px; BACKGROUND-COLOR: #eeeeee; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; COLOR: #555555; PADDING-TOP: 10px
}
</STYLE>
<SCRIPT type=text/javascript><!--

  function onFormSubmit() {
    
    history.back();
    return false;
    
  }
  --></SCRIPT>

</head>

<%
request.setCharacterEncoding("UTF-8");
String getusername=null;
String getuserpassword=null;
getusername=request.getParameter("username");
getuserpassword=request.getParameter("password");
if(!judge.judge(getusername,getuserpassword)){
 %>
<BODY>
<FORM class=msgMain onSubmit="return onFormSubmit(this);" method=post action="">
<DIV class=msgFrame>
<DIV class=msgTitle>登录失败</DIV>
<DIV class=msgBody>
<DIV style="MARGIN: 5px 20px 20px">用户名或者密码错误~ </DIV>
<DIV style="MARGIN: 15px"><INPUT value=确认 type=submit> 
</DIV></DIV></DIV></FORM></BODY>
<% 
}else
{
response.sendRedirect("web/main.jsp");
}
%>
<body>

</body>
</html>