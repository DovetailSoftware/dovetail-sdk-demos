<%@ Register TagPrefix="FChoice" TagName="SideMenu" Src="SideMenu.ascx" %>
<%@ Page language="c#" Codebehind="CreateSite.aspx.cs" AutoEventWireup="false" Inherits="FChoice.Foundation.Clarify.Demo.WebAppCS.CreateSite" %>
<%@ Register TagPrefix="FChoice" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Create Site</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <LINK rel="stylesheet" type="text/css" href="style.css">
  </head>
  <body MS_POSITIONING="GridLayout">
	
    <form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr><td height="50" colspan="2" style="border-bottom:solid 1px darkgray;"><FChoice:Header runat="server" ID="Header1"/></td></tr>
				<tr>
					<td background="images/little_stripes_plus.gif" width="150" valign="top"><FChoice:SideMenu runat="server" ID="Sidemenu1"/></td>
					<td valign="top" align="center" class="text">
					
						<table>
							<tr><td colspan="2"><h4>Create Site</h4></td></tr>
							<tr><td colspan="2"><asp:Label CssClass="errorMsg" id="message" runat="server"></asp:Label></td></tr>
							<tr><td colspan="2"><asp:ValidationSummary Runat="server" ></asp:ValidationSummary></td></tr>
							<tr><td colspan="2">&nbsp;</td></tr>
							<tr>
								<td>Site Name:</td>
								<td>
									<asp:TextBox id="siteName" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="siteName" ErrorMessage="'Site Name' is a required field.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr><td colspan="2">&nbsp;</td></tr>
							<tr>
								<td>Address 1:</td>
								<td>
									<asp:TextBox id=address1 runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="address1" ErrorMessage="'Address 1' is a required field." ID="Requiredfieldvalidator1">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td>Address 2:</td>
								<td>
									<asp:TextBox id=address2 runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="address2" ErrorMessage="'Address 2' is a required field." ID="Requiredfieldvalidator2">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td>City:</td>
								<td>
									<asp:TextBox id=city runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="city" ErrorMessage="'City' is a required field." ID="Requiredfieldvalidator3">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td>Zip:</td>
								<td>
									<asp:TextBox id="zip" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="zip" ErrorMessage="'zip' is a required field." ID="Requiredfieldvalidator7">*</asp:RequiredFieldValidator>
								</td>
							</tr>							
							<tr>
								<td>Country:</td>
								<td>
									<asp:DropDownList ID="country" Runat=server AutoPostBack="True" Width="150px"></asp:DropDownList>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="country" ErrorMessage="'Country' is a required field." ID="Requiredfieldvalidator4">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td>State:</td>
								<td>
									<asp:DropDownList ID="state" Runat=server Width="150px"></asp:DropDownList>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="state" ErrorMessage="'State' is a required field." ID="Requiredfieldvalidator5">*</asp:RequiredFieldValidator>
								</td>
							</tr>							
							<tr>
								<td>Time Zone:</td>
								<td>
									<asp:DropDownList ID="timeZone" Runat=server Width="150px"></asp:DropDownList>
									<asp:RequiredFieldValidator Runat="server" ControlToValidate="timeZone" ErrorMessage="'Time Zone' is a required field." ID="Requiredfieldvalidator6">*</asp:RequiredFieldValidator>
								</td>
							</tr>								
						
						</table>					
						<asp:Button id=createButton runat="server" Text="Create Site"></asp:Button>
					  <input id="resetButton" runat="server" type=button value=Reset onclick="document.forms[0].reset();" />
					</td>
				</tr>
			</table>
     </form>
  </body>
</html>
