<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SideMenu.ascx.cs" Inherits="FChoice.Foundation.Clarify.Demo.WebAppCS.SideMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table>
	<tr><td><a href="default.aspx">Home</a></td></tr>
	<tr><td><a href="profile.aspx">My Profile</a></td></tr>
	<tr><td><a href="Family.aspx">Family List</a></td></tr>
	<tr><td><a href="CR_DESC.aspx">CR DESC List</a></td></tr>
	<tr><td><a href="createcase.aspx">Create Case</a></td></tr>
	<tr><td><a href="createsite.aspx">Create Site</a></td></tr>
	<tr><td><asp:LinkButton id=logoutButton runat="server" CausesValidation="False">Logout</asp:LinkButton></td></tr>
</table>
