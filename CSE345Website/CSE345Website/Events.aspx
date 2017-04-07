<%@ Page Title="Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="CSE345Website.Events" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="row">
        <div class="col-md-8">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" class="gridview" ShowHeader="false" GridLines="None">
                <Columns>
                    <asp:TemplateField ShowHeader="false">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="BlogHead">
                                        <h2><a href='<%# Eval("EVENT_ID", "SelectedEvent.aspx?Id={0}") %>' class="BlogHead">
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EVENT_NAME") %>'></asp:Label></a></h2>

                                    </div>
                                    <div class="post_meta">
                                        <span class="post_author blackLink nocursor">
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("EVENT_LOCATION") %>'></asp:Label>,</span>
                                        <span class="date blackLink nocursor">
                                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("FormDate") %>'></asp:Label></span>
                                    </div>
                                    <br />
                                    <div id="blbodythumb" style="text-align: justify;">
                                        <p>
                                            <asp:Label ID="Label100" runat="server" Text='<%#Eval("EVENT_DESCRIPT") %>'></asp:Label>
                                        </p>
                                    </div>
                                    <hr class="style-one" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div runat="server" id="creatEvent" class="col-md-4">
            <div class="login-page">
                <div class="login">
                    <div class="login-form">
                        <asp:Label ID="lblEvent" runat="server" Text="Create Event" CssClass="login-title"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="txtEventName" runat="server" placeholder="Title"></asp:TextBox>
                        <asp:TextBox ID="txtEventLoc" runat="server" placeholder="Location"></asp:TextBox>
                        <asp:TextBox ID="txtEventDescript" runat="server" placeholder="Description"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Calendar ID="cldEvents" AutoPostBack="false" OnSelectionChanged="didSelectNewDate" runat="server" BackColor="transparent" BorderColor="#d1c338" BorderWidth="4px" Font-Names="Verdana" Font-Size="9pt" ForeColor="#d1c338" Height="258px" NextPrevFormat="FullMonth" Width="100%">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#b7b7b7" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#b7b7b7" />
                            <SelectedDayStyle BackColor="#d1c338" ForeColor="Black" />
                            <TitleStyle BackColor="transparent" BorderColor="#d1c338" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#d1c338" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        </asp:Calendar>
                        <asp:TextBox ID="txtSelectedDate" runat="server" placeholder="Date"></asp:TextBox>
                         <asp:TextBox ID="txtTime" runat="server" placeholder="Start Time"></asp:TextBox>
                         <asp:CheckBox ID="chkEnroll" runat="server" Text="Enroll Required"/>
                         <asp:Button ID="btnSubmit" runat="server" OnClick="Submit_Clicked" Text="Submit" />
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
