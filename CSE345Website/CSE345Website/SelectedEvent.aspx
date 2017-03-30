<%@ Page Title="SelectedEvent" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectedEvent.aspx.cs" Inherits="CSE345Website.SelectedEvent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
    <br />
    <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
    <br />
    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
    <br />
    <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
</asp:Content>
