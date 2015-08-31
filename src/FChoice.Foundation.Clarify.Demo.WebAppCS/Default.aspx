<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="FChoice.Foundation.Clarify.Demo.WebAppCS._Default" %>
<%@ Register TagPrefix="FChoice" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="FChoice" TagName="SideMenu" Src="SideMenu.ascx" %>
<%@ Register TagPrefix="FChoice" TagName="CasesCreatedInLastXDays" Src="CasesCreatedInLastXDays.ascx" %>
<%@ Register TagPrefix="FChoice" TagName="MyOpenCases" Src="MyOpenCases.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Default</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <LINK rel="stylesheet" type="text/css" href="style.css">
  </head>
  <body >
    <form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr><td height="50" colspan="2" style="border-bottom:solid 1px darkgray;"><FChoice:Header runat="server" /></td></tr>
				<tr>
					<td background="images/little_stripes_plus.gif" width="150" valign="top"><FChoice:SideMenu runat="server" /></td>
					<td valign="top" align="center" class="text">
						<h3><asp:Label id=welcomeLabel runat="server"></asp:Label></h3><br/><br/>
						<FChoice:MyOpenCases runat="server" ID="myOpenCases" /><br/>
						<FChoice:CasesCreatedInLastXDays DaysBack="20" runat="server" ID="casesCreatedInLastXDays" />
					</td>
				</tr>
			</table>
    </form>
  </body>
</html>
