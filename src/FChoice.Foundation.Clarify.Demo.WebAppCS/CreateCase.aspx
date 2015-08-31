<%@ Register TagPrefix="FChoice" TagName="SideMenu" Src="SideMenu.ascx" %>
<%@ Page language="c#" Codebehind="CreateCase.aspx.cs" AutoEventWireup="false" Inherits="FChoice.Foundation.Clarify.Demo.WebAppCS.CreateCase" %>
<%@ Register TagPrefix="FChoice" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <HEAD>
    <title>Create Case</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <LINK rel="stylesheet" type="text/css" href="style.css">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
	
    <form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr><td height="50" colspan="2" style="border-bottom:solid 1px darkgray;"><FChoice:Header runat="server" ID="Header1"/></td></tr>
				<tr>
					<td background="images/little_stripes_plus.gif" width="150" valign="top"><FChoice:SideMenu runat="server" ID="Sidemenu1"/></td>
					<td valign="top" align="center" class="text">
					
						<table>
							<tr><td colspan="2"><h4>Create Case</h4></td></tr>
							<tr><td colspan="2"><asp:Label CssClass="errorMsg" id="message" runat="server"></asp:Label></td></tr>
							<tr><td colspan="2"><asp:ValidationSummary Runat="server" ></asp:ValidationSummary></td></tr>
							<tr><td colspan="2">&nbsp;</td></tr>
							<tr>
								<td>SiteID:</td>
								<td>
									<asp:TextBox id="siteID" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="siteID" ErrorMessage="'SiteID' is a required field.">*</asp:RequiredFieldValidator>
									<asp:CustomValidator Runat="server" OnServerValidate="DoesSiteExist" ControlToValidate="siteID" ErrorMessage="Could not find specified site.">*</asp:CustomValidator>
								</td>
							</tr>
							<tr><td colspan="2">&nbsp;</td></tr>
							<tr>
								<td>Contact First Name:</td>
								<td>
									<asp:TextBox id=firstName runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="firstName" ErrorMessage="'Contact First Name' is a required field." ID="Requiredfieldvalidator1">*</asp:RequiredFieldValidator>
									<asp:CustomValidator Runat="server" OnServerValidate="DoesContactExist" ControlToValidate="firstName" ErrorMessage="Could not find specified contact." ID="contactValidator">&nbsp;</asp:CustomValidator>
								</td>
							</tr>
							<tr>
								<td>Contact Last Name:</td>
								<td>
									<asp:TextBox id=lastName runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="lastName" ErrorMessage="'Contact Last Name' is a required field." ID="Requiredfieldvalidator2">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td>Contact Phone:</td>
								<td>
									<asp:TextBox id=phone runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="phone" ErrorMessage="'Contact Phone' is a required field." ID="Requiredfieldvalidator3">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr><td colspan="2">&nbsp;</td></tr>
							<tr>
								<td>Case Title:</td>
								<td>
									<asp:TextBox id="title" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="title" ErrorMessage="'Case Title' is a required field." ID="Requiredfieldvalidator4">*</asp:RequiredFieldValidator>
								</td>
							</tr>							
							<tr>
								<td valign="top">Case Notes:</td>
								<td>
									<asp:TextBox TextMode=MultiLine Rows=5 id="notes" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="notes" ErrorMessage="'Case Notes' is a required field." ID="Requiredfieldvalidator5">*</asp:RequiredFieldValidator>
								</td>
							</tr>							
						</table>					
						<asp:Button id=createButton runat="server" Text="Create Case"></asp:Button>
					  <input id="resetButton" runat="server" type=button value=Reset onclick="document.forms[0].reset();"/>
					</td>
				</tr>
			</table>
     </form>
  </body>
</html>