<%@ page language="java" contentType="text/html; charset=utf-8"
    pageEncoding="utf-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	overflow:hidden;
}
.STYLE3 {font-size: 12px; color: #adc9d9; }
-->
</style></head>
<script type="text/javascript">
	function checkUser(){
		if($.trim($("#username").val())==""&&$.trim($("#password").val())==""){
			alert("请您输入用户名和密码!");
			return false;
		}
		if($.trim($("#username").val())==""){
			alert("请您输入用户名!");
			return false;
		}
		if($.trim($("#password").val())==""){
			alert("请您输入密码!");
			return false;
		}
		else {
    	userList = userDAO.findByUserName(username);
    	if(userList.equals("")){  //你这个感觉有问题 不知道findByUserName 是怎么写的 
    	 return "error";  //if(userList.equals("")) 改成这if( userList==null |userList.isEmpty()|) )
                                          //  试试
    	}
		
		return true;
	}
	</script>
<body>
<form  action="loginAccess.jsp" method="get">
<table width="100%"  height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td bgcolor="#1075b1">&nbsp;</td>
  </tr>
  <tr>
    <td height="608" background="images/login_03.gif"><table width="847" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="318" background="images/login_04.gif">&nbsp;</td>
      </tr>
      <tr>
        <td height="84"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="381" height="84" background="images/login_06.gif">&nbsp;</td>
            <td width="162" valign="middle" background="images/login_07.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="44" height="24" valign="bottom"><div align="right"><span class="STYLE3">用户</span></div></td>
                <td width="10" valign="bottom">&nbsp;</td>
                <td height="24" colspan="2" valign="bottom">
                  <div align="left">
                    <input type="text" name="username" id="username" style="width:100px; height:17px; background-color:#87adbf; border:solid 1px #153966; font-size:12px; color:#283439; ">
                  </div></td>
              </tr>
              <tr>
                <td height="24" valign="bottom"><div align="right"><span class="STYLE3">密码</span></div></td>
                <td width="10" valign="bottom">&nbsp;</td>
                <td height="24" colspan="2" valign="bottom"><input type="password" name="password" id="password" style="width:100px; height:17px; background-color:#87adbf; border:solid 1px #153966; font-size:12px; color:#283439; "></td>
              </tr>
              <tr></tr>
            </table></td>
            <td width="26"><img src="images/login_08.gif" width="26" height="84"></td>
            <td width="67" background=""><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="25"><div align="center">
                <input type="submit" value="登录"></div></td>
              </tr>
              <tr>
                <td height="25"><div align="center"></div></td>
              </tr>
            </table></td>
            <td width="211" background="images/login_10.gif">&nbsp;
            </td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="206" background="images/login_11.gif">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td bgcolor="#152753">&nbsp;</td>
  </tr>
</table>
</form>
</body>
</html>