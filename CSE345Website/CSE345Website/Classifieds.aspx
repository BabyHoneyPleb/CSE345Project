<%@ Page Title="Items/Services" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Classifieds.aspx.cs" Inherits="CSE345Website.Classifieds" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView ID="ClassifiedsGrid" runat="server">
        <HeaderStyle BackColor="#CCCCCC" />
    </asp:GridView>

    <br />
    <hr />
    <div runat="server" id="createPosting">
        <asp:Label ID="CreatePostingHeader" runat="server" Font-Size="X-Large" Font-Underline="True" Text="List a posting"></asp:Label>
        <br />
        Category:<br />
        <asp:DropDownList ID="CategorySelector" runat="server">
            <asp:ListItem Selected="True"></asp:ListItem>
            <asp:ListItem>Book</asp:ListItem>
            <asp:ListItem>Computer</asp:ListItem>
            <asp:ListItem>Phone</asp:ListItem>
            <asp:ListItem>Tablet</asp:ListItem>
            <asp:ListItem>Roommate wanted</asp:ListItem>
            <asp:ListItem>Tutoring</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Title:<br />
        <asp:TextBox ID="TitleInput" runat="server" Width="256px"></asp:TextBox>
        <br />
        <br />
        Description:<br />
        <asp:TextBox ID="DescripInput" runat="server" Height="128px" TextMode="MultiLine" Width="256px"></asp:TextBox>
        <br />
        <br />
        Contact Info:<br />
        <asp:TextBox ID="ContactInput" runat="server" Width="256px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>

</asp:Content>

