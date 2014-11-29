<%@ page language="java" contentType="text/html; charset=utf-8"
	pageEncoding="utf-8"%>
<%@ page import="com.sql.*"%>
<%@ page import="com.table.*"%>
<%@ page import="java.util.*"%>
<%

String chaxun= request.getParameter("chaxun");
List<Medicine> medicineList=new ArrayList<Medicine>();
ConnectSqlServer connectSqlServer = new ConnectSqlServer();
medicineList= connectSqlServer.queryMedicine(chaxun);
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>无标题文档</title>
		<style type="text/css">
<!--
body {
	margin-left: 3px;
	margin-top: 0px;
	margin-right: 3px;
	margin-bottom: 0px;
}

.STYLE1 {
	color: #e1e2e3;
	font-size: 12px;
}

.STYLE6 {
	color: #000000;
	font-size: 12;
}

.STYLE10 {
	color: #000000;
	font-size: 12px;
}

.STYLE19 {
	color: #344b50;
	font-size: 12px;
}

.STYLE21 {
	font-size: 12px;
	color: #3b6375;
}

.STYLE22 {
	font-size: 12px;
	color: #295568;
}
-->
</style>
		<script>
var highlightcolor = '#d5f4fe';
//此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
var clickcolor = '#51b2f6';
function changeto() {
	source = event.srcElement;
	if (source.tagName == "TR" || source.tagName == "TABLE")
		return;
	while (source.tagName != "TD")
		source = source.parentElement;
	source = source.parentElement;
	cs = source.children;
	//alert(cs.length);
	if (cs[1].style.backgroundColor != highlightcolor && source.id != "nc"
			&& cs[1].style.backgroundColor != clickcolor)
		for (i = 0; i < cs.length; i++) {
			cs[i].style.backgroundColor = highlightcolor;
		}
}

function changeback() {
	if (event.fromElement.contains(event.toElement)
			|| source.contains(event.toElement) || source.id == "nc")
		return
	
	


if  (event.toElement!=source&&cs[1].style.backgroundColor!=clickcolor)
//source.style.backgroundColor=originalcolor
for(i=0;i<cs.length;i++){
	cs[i].style.backgroundColor="";
}
}

function  clickto(){
source=event.srcElement;
if  (source.tagName=="TR"||source.tagName=="TABLE")
return;
while(source.tagName!="TD")
source=source.parentElement;
source=source.parentElement;
cs  =  source.children;
//alert(cs.length);
if  (cs[1].style.backgroundColor!=clickcolor&&source.id!="nc")
for(i=0;i<cs.length;i++){
	cs[i].style.backgroundColor=clickcolor;
}
else
for(i=0;i<cs.length;i++){
	cs[i].style.backgroundColor="";
}
}
</script>


	</head>

	<body>
		<table width="100%" border="0" align="center" cellpadding="0"
			cellspacing="0">
			<tr>
				<td height="30">
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td height="24" bgcolor="#353c44">
								<table width="100%" border="0" cellspacing="0" cellpadding="0">
									<tr>
										<td>
											<table width="100%" border="0" cellspacing="0"
												cellpadding="0">
												<tr>
													<td width="6%" height="19" valign="bottom">
														<div align="center">
															<img src="images/tb.gif" width="14" height="14" />
														</div>
													</td>
													<td width="94%" valign="bottom">
														<span class="STYLE1">&nbsp;药品信息管理<br> </span>
													</td>
												</tr>
											</table>
										</td>
										<td>
											<div align="right">
												<span class="STYLE1">&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
													&nbsp;</span><span class="STYLE1">&nbsp; <br> </span>
											</div>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td>
					<form action="right.jsp" method="get">
						<input type="text" value="" name="chaxun">
						<input type="submit" value="查询">
					</form>
				</td>
			</tr>
			<tr>
				<td>
					<table width="100%" border="0" cellpadding="0" cellspacing="1"
						bgcolor="#a8c7ce" onmouseover="changeto()"
						onmouseout="changeback()">
						<tr>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">药品名</span>
								</div>
							</td>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">字母缩写</span>
								</div>
							</td>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">主要成分</span>
								</div>
							</td>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">药效</span>
								</div>
							</td>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">使用方法</span>
								</div>
							</td>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">禁忌事项</span>
								</div>
							</td>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">厂家</span>
								</div>
							</td>
							<td width="10%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">备注</span>
								</div>
							</td>
							<td width="20%" height="20" bgcolor="d3eaef" class="STYLE6">
								<div align="center">
									<span class="STYLE10">基本操作</span>
								</div>
							</td>
						</tr>
						<%
							for (int i = 0; i < medicineList.size(); i++) {
						%>
						<tr>
							<td height="20" bgcolor="#FFFFFF" class="STYLE6">
								<div align="center">
									<span class="STYLE19"> <%=medicineList.get(i).getMedicineName()%></span>
								</div>
							</td>
							<td height="20" bgcolor="#FFFFFF" class="STYLE19">
								<div align="center">
									<%=medicineList.get(i).getAbbrebiation()%></div>
							</td>
							<td height="20" bgcolor="#FFFFFF" class="STYLE19">
								<div align="center">
									<%=medicineList.get(i).getMainContent()%></div>
							</td>
							<td height="20" bgcolor="#FFFFFF" class="STYLE19">
								<div align="center">
									<%=medicineList.get(i).getEffect()%></div>
							</td>
							<td height="20" bgcolor="#FFFFFF" class="STYLE19">
								<div align="center">
									<%=medicineList.get(i).getUseMethod()%></div>
							</td>
							<td height="20" bgcolor="#FFFFFF">
								<div align="center" class="STYLE21">
									<%=medicineList.get(i).getTaboo()%><br>
								</div>
							</td>
							<td height="20" bgcolor="#FFFFFF" class="STYLE19">
								<div align="center">
									<%=medicineList.get(i).getFactory()%></div>
							</td>
							<td height="20" bgcolor="#FFFFFF">
								<div align="center" class="STYLE21">
									<%=medicineList.get(i).getComment()%><br>
								</div>
							</td>
							<td height="20" bgcolor="#FFFFFF">
								<div align="center">
									<span class="STYLE21"><a
										href="rightdelete.jsp?medicineName=<%=medicineList.get(i).getMedicineName()%>">删除</a>
										| <a
										href="righteditInfo.jsp?medicineName=<%=medicineList.get(i).getMedicineName()%>
        &b=<%=medicineList.get(i).getAbbrebiation()%>
        &c=<%=medicineList.get(i).getMainContent()%>
        &d=<%=medicineList.get(i).getEffect()%>
        &e=<%=medicineList.get(i).getUseMethod()%>
        &f=<%=medicineList.get(i).getTaboo()%>
        &g=<%=medicineList.get(i).getFactory()%>
        &h=<%=medicineList.get(i).getComment()%>">
											编辑</a> </span>
								</div>
							</td>
						</tr>
						<%
							}
						%>

					</table>
				</td>
			</tr>
			<tr>
				<td height="30">
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="33%">
								<div align="left">
									<span class="STYLE22">&nbsp;<br> </span>
								</div>
							</td>
							<td width="67%">
								<br>
							</td>
						</tr>
					</table>
				</td>
			</tr>


			<tr>
				<td>
					<div align="center">
						<form action="rightaddInfo.jsp" method="get">
							<input type="submit" value="添加">
						</form>
					</div>
				</td>
			</tr>


		</table>

	</body>
</html>