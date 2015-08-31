<%@ Page language="c#" Codebehind="Family.aspx.cs" AutoEventWireup="false" Inherits="FChoice.Foundation.Clarify.Demo.WebAppCS.Family" %>
<%@ Register TagPrefix="FChoice" TagName="SideMenu" Src="SideMenu.ascx" %>
<%@ Register TagPrefix="FChoice" TagName="Header" Src="Header.ascx" %>
<%@ Register tagprefix="FChoice" Namespace="FChoice.Foundation.Clarify.Demo.WebAppCS" Assembly="FChoice.Foundation.Clarify.Demo.WebAppCS"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
  <head>
    <title>Family List</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <LINK rel="stylesheet" type="text/css" href="style.css">
  </head>
  <body >
    <form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr><td height="50" colspan="2" style="border-bottom:solid 1px darkgray;"><FChoice:Header runat="server" ID="Header1"/></td></tr>
				<tr>
					<td background="images/little_stripes_plus.gif" width="150" valign="top"><FChoice:SideMenu runat="server" ID="Sidemenu1"/></td>
					<td valign="top" class="text">
						<b>FAMILY &amp; LINE Hierarchial List</b><br/>
						Change the <b>Family</b> List, and you'll see the <b>Line</b> List change dynamically.<br/>
						<br/>
						<FChoice:FCCompositeList ID="familyList" runat="server" FCDropDownListIDs="familyListItems,lineListItems" />
						
						<b>Family:</b><br/>
						<FChoice:FCDropDownList runat="server" ID="familyListItems" /><br/>
						<br/>
						<b>Line:</b><br/>
						<FChoice:FCDropDownList runat="server" ID="lineListItems" /><br/>
						<br/>
						<asp:LinkButton Runat="server" ID="postBackButton" >Click here to PostBack the page.</asp:LinkButton><br/>
						<br/>
						The following data was posted to the server:<br/>	
						<table>
							<tr><td>Family :</td><td><asp:Label Runat="server" ID="familyLabel" /></td></tr>
							<tr><td>Line :</td><td><asp:Label Runat="server" ID="lineLabel" /></td></tr>
						</table>						
					</td>
				</tr>
			</table>
     </form>
  </body>
</html>
