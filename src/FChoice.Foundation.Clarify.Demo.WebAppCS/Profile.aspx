<%@ Register TagPrefix="FChoice" TagName="SideMenu" Src="SideMenu.ascx" %>
<%@ Page language="c#" Codebehind="Profile.aspx.cs" AutoEventWireup="false" Inherits="FChoice.Foundation.Clarify.Demo.WebAppCS.Profile" %>
<%@ Register TagPrefix="FChoice" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Profile</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" Content="C#" />
    <meta name=vs_defaultClientScript content="JavaScript" />
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5" />
    <LINK rel="stylesheet" type="text/css" href="style.css" />
  </head>
  <body MS_POSITIONING="GridLayout">
    <form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr><td height="50" colspan="2" style="border-bottom:solid 1px darkgray;"><FChoice:Header runat="server" ID="Header1"/></td></tr>
				<tr>
					<td background="images/little_stripes_plus.gif" width="150" valign="top"><FChoice:SideMenu runat="server" ID="Sidemenu1"/></td>
					<td valign="top" align="center" class="text">
						<table>
							<tr><td colspan="2"><h4>Current Info</h4></td></tr>
							<tr>
								<td>First Name:</td>
								<td><asp:Label id=firstNameLabel runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>Last Name:</td>
								<td><asp:Label id=lastNameLabel runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>Phone:</td>
								<td><asp:Label id=phoneLabel runat="server"></asp:Label></td>
							</tr>
							<tr><td colspan="2">&nbsp;<br/><br/></td></tr>
							<tr><td colspan="2"><h4>New Info</h4></td></tr>
							<tr>
								<td>First Name:</td>
								<td><asp:TextBox id=firstName runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<td>Last Name:</td>
								<td><asp:TextBox id=lastName runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<td>Phone:</td>
								<td><asp:TextBox id=phone runat="server"></asp:TextBox></td>
							</tr>
						</table>					
						<asp:Button id=modifyButton runat="server" Text="Modify Profile"></asp:Button>
					  <input type=button value=Reset onclick="document.forms[0].reset();" />
					</td>
				</tr>
			</table>
     </form>
  </body>
</html>
