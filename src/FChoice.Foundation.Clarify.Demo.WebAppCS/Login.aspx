<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="FChoice.Foundation.Clarify.Demo.WebAppCS.Login" %>
<%@ Register TagPrefix="FChoice" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Login</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" Content="C#" />
    <meta name=vs_defaultClientScript content="JavaScript" />
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5" />
    <link rel="stylesheet" type="text/css" href="style.css" />
  </head>
  <body >
    <form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr><td height="50" colspan="2" style="border-bottom:solid 1px darkgray;"><FChoice:Header runat="server" ID="Header1"/></td></tr>
				<tr>
					<td background="images/little_stripes_plus.gif" width="150" valign="top">&nbsp;</td>
					<td valign="top" align="center" class="text">
						
						<br/><br/><br/><br/><br/>
						You are currently not logged in.<br/>Please enter your username and password.<br/><br/>
						<table>
							<tr>
								<td align="right">Username:</td>
								<td><asp:TextBox id=username runat="server" Columns="20"></asp:TextBox>
									<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ErrorMessage="Username is a required field." ControlToValidate="username" Display="Dynamic">*</asp:RequiredFieldValidator></td>
							</tr>
							<tr>
								<td align="right">Password:</td>
								<td><asp:TextBox id=password runat="server" TextMode="Password" Columns="20"></asp:TextBox>
									<asp:RequiredFieldValidator id=RequiredFieldValidator2 runat="server" ErrorMessage="Password is a required field." ControlToValidate="password" Display="Dynamic">*</asp:RequiredFieldValidator></td>
							</tr>
							<tr>
								<td align="right">Login Type:</td>
								<td>
									<asp:RadioButton id=userTypeUser runat="server" Text="User" GroupName="userType" Checked="True"></asp:RadioButton>					
									<asp:RadioButton id=userTypeContact runat="server" Text="Contact" GroupName="userType"></asp:RadioButton>
								</td>
							</tr>
							<tr>
								<td align="center" colspan="2"><br/><asp:Button id=loginButton runat="server" Text="Login"></asp:Button></td>
							</tr>
							<tr>
								<td align="center" colspan="2">
									<asp:Label id=msgLabel runat="server"></asp:Label>
									<asp:ValidationSummary id=ValidationSummary1 runat="server"></asp:ValidationSummary>
								</td>
							</tr>
						</table>
					</td>
				</tr>						
			</table>
     </form>
  </body>
</html>
