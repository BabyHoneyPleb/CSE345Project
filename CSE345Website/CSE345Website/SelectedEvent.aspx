<%@ Page Title="SelectedEvent" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectedEvent.aspx.cs" Inherits="CSE345Website.SelectedEvent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="false" Width="100%" GridLines="None">
            <Fields>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <tr>
                            <div>
                                <h2>
                                    <asp:Label ID="lblEventName" runat="server" Text='<%#Eval("EVENT_NAME") %>'></asp:Label></h2>
                                <div>
                                    <span>
                                        <asp:Label ID="lblLocaiton" runat="server" Text='<%#Eval("EVENT_LOCATION") %>'></asp:Label></span>
                                    <span>
                                        <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("FormDate") %>'></asp:Label></span>
                                </div>
                                <div style="text-align: justify;">
                                    <p>
                                        <asp:Label ID="lblDescript" runat="server" Text='<%#Eval("EVENT_DESCRIPT") %>'></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
        <asp:Button ID="btnEnroll" runat="server" Text="Enroll" OnClick="enrollClicked" Visible="false" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="deleteEvent" Visible="false" />
    </div>
   






</asp:Content>
