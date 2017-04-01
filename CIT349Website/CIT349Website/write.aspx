<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="write.aspx.cs" Inherits="CIT349Website.write" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            Title:<asp:TextBox ID="txbxTitle" runat="server"></asp:TextBox>
        </div>
        <div>
            Author:<asp:TextBox ID="txbxAuthor" runat="server"></asp:TextBox>
        </div>
        <div>
            Blog<br />
            <asp:TextBox ID="txbxContent" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    </div>
</asp:Content>
