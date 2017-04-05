<%@ Page Title="User Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="CSE345Website.UserInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:TextBox ID="gID" runat="server"></asp:TextBox>
    <asp:TextBox ID="fName" runat="server"></asp:TextBox>
    <asp:TextBox ID="lName" runat="server"></asp:TextBox>
    <asp:TextBox ID="areaCode" runat="server"></asp:TextBox>
    <asp:TextBox ID="phone" runat="server"></asp:TextBox>
    <asp:TextBox ID="email" runat="server"></asp:TextBox>


    <asp:TextBox ID="street" runat="server"></asp:TextBox>
    <asp:TextBox ID="city" runat="server"></asp:TextBox>
    <asp:TextBox ID="state" runat="server"></asp:TextBox>
    <asp:TextBox ID="zipcode" runat="server"></asp:TextBox>
    <asp:TextBox ID="standing" runat="server"></asp:TextBox>
    <asp:TextBox ID="major" runat="server"></asp:TextBox>
   

</asp:Content>
