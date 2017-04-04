<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE345Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row">
       <div class="col-md-3-4">
           <asp:Panel ID="pnlLeft" runat="server" CssClass="pnl-left">
               <asp:Panel ID="pnlTitle" runat="server" CssClass="pnl-title">
                   <br />
                   <br />
                   <asp:Label ID="lblTitle" runat="server" Text="College Corner" CssClass="txt-title"></asp:Label>
               </asp:Panel>
               <br />
               <br />
               <asp:Calendar ID="cldEvents" runat="server" BackColor="transparent" BorderColor="#d1c338" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="#d1c338" Height="258px" NextPrevFormat="FullMonth" Width="100%">
                   <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                   <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#b7b7b7" VerticalAlign="Bottom" />
                   <OtherMonthDayStyle ForeColor="#b7b7b7" />
                   <SelectedDayStyle BackColor="#d1c338" ForeColor="Black" />
                   <TitleStyle BackColor="transparent" BorderColor="#d1c338" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#d1c338" />
                   <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
               </asp:Calendar>
               <br />
               <br />
               <div style="text-align: center;">
                   <asp:Button ID="btnOrganize" runat="server" Text="Organize Event" CssClass="btn btn-primary btn-lg" OnClick="On_Click_Events"/>
               </div>           
               <br />
               <br />
               <div style="text-align: center";>
                    <asp:Button ID="btnPostItem" runat="server" Text="Post Item/Service" CssClass="btn btn-primary btn-lg" OnClick="On_Click_Classifieds" />
               </div>
               <br />
               <br />
           </asp:Panel>          
       </div>
       
       
       
       <div class="col-md-8">
           <br />
           <br />
           <asp:Panel ID="pnlUpcomingEvent" runat="server" CssClass="pnl-box">
               <asp:Label ID="lblEventTitle" runat="server" Text="College Corner" CssClass="title-box"></asp:Label>       
           </asp:Panel>
           <br />
           <br />
           <asp:Panel ID="pnlFeatured" runat="server" CssClass="pnl-box">
               <asp:Label ID="lblFeaturedTitle" runat="server" Text="College Corner" CssClass="title-box"></asp:Label>     
           </asp:Panel>
           <br />
           <br />
           <div class="row">
               <div class="col-md-6">
                   <asp:Label ID="lblSaleTitle" runat="server" Text="Label" CssClass="title-default" Font-Underline="True"></asp:Label>
               </div>
               <div class="col-md-6">
                   <asp:Label ID="lblServiceTitle" runat="server" Text="Label" CssClass="title-default" Font-Underline="True"></asp:Label>
               </div>
           </div>      
       </div>
   </div>



</asp:Content>
