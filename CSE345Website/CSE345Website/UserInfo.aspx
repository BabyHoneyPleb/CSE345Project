<%@ Page Title="User Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="CSE345Website.UserInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="login-page" runat="server" id="registerBlock">
        <div class="login">
            <div class="login-form">
                <asp:Label ID="lblSignIn" runat="server" Text="Sign In" CssClass="login-title"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtUser" runat="server" placeholder="username"></asp:TextBox>
                <asp:TextBox ID="txtPass" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                <asp:Button ID="btnSignIn" runat="server" OnClick="Register_Clicked" Text="Sign In" />
                <br />
                <asp:Label ID="Label1" runat="server" href="~/UserInfo" Text="Need an account, click here!" CssClass="login-title"></asp:Label>

            </div>
        </div>
    </div>
    <div >

    </div>



</asp:Content>
