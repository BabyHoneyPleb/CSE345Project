<%@ Page Title="User Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="CSE345Website.UserInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <div class="col-md-6 ">
            <br />
            <br />
            <div class="login">
                <asp:Label ID="lblContact" runat="server" Text="Contact Info" CssClass="login-title"></asp:Label>
                
                <asp:TextBox ID="gID" runat="server" placeholder="Grizz ID" Enabled="false"></asp:TextBox>
                 <asp:TextBox ID="fName" runat="server" placeholder="First Name"></asp:TextBox>
                <asp:TextBox ID="lName" runat="server" placeholder="Last Name"></asp:TextBox>
                <asp:TextBox ID="areaCode" runat="server" placeholder="Area Code"></asp:TextBox>
                <asp:TextBox ID="phone" runat="server" placeholder="Phone Number"></asp:TextBox>
                <asp:TextBox ID="email" runat="server" placeholder="Email"></asp:TextBox>
                  <asp:Button ID="btnSubmit" runat="server" OnClick="Contact_Clicked" Text="Submit Changes" CssClass="btn-login"/>
            </div>
        </div>
        
        <div class="col-md-6">
            <br />
            <br />
            <div class="login">
                 <asp:Label ID="lblAbout" runat="server" Text="About"  CssClass="login-title"></asp:Label>
                <asp:TextBox ID="street" runat="server" placeholder="Street"></asp:TextBox>
                <asp:TextBox ID="city" runat="server" placeholder="City"></asp:TextBox>
                <asp:TextBox ID="state" runat="server" placeholder="State"></asp:TextBox>
                <asp:TextBox ID="zipcode" runat="server" placeholder="Zipcode"></asp:TextBox>
                <asp:TextBox ID="standing" runat="server" placeholder="Class Standing"></asp:TextBox>
                <asp:TextBox ID="major" runat="server" placeholder="Major"></asp:TextBox>
                  <asp:Button ID="btnAbout" runat="server" OnClick="About_Clicked" Text="Submit Changes" CssClass="btn-login"/>
            </div>
        </div>
    </div>

</asp:Content>
