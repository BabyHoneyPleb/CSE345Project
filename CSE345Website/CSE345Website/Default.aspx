<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE345Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row row-height">
       <div class="col-md-4 ">
           <asp:Panel ID="pnlLeft" runat="server" CssClass="pnl-left">
               <asp:Panel ID="pnlTitle" runat="server" CssClass="pnl-title">
                   <br />
                   <br />
                   <div class="row">
                       <div class="col-md-4" style="text-align: center;">
                            <asp:Image ID="Image1" runat="server" Height="96px" ImageUrl="~/OaklandGoldenGrizzlies.png" Width="83px" />
                       </div>
                       <div class="col-md-8">
                           <asp:Label ID="lblTitle" runat="server" Text="College<br/>&nbsp;&nbsp;&nbsp;Corner" CssClass="txt-title"></asp:Label>
                       </div>
                   </div>
                  
                 
                   
               </asp:Panel>
               <br />
               <br />
               <asp:Calendar ID="cldEvents" runat="server" BackColor="transparent" BorderColor="#d1c338" BorderWidth="4px" Font-Names="Verdana" Font-Size="9pt" ForeColor="#d1c338" Height="258px" NextPrevFormat="FullMonth" Width="100%" OnSelectionChanged="cldEvents_SelectionChanged">
                   <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                   <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#b7b7b7" VerticalAlign="Bottom" />
                   <OtherMonthDayStyle ForeColor="#b7b7b7" />
                   <SelectedDayStyle BackColor="#d1c338" ForeColor="Black" />
                   <TitleStyle BackColor="transparent" BorderColor="#d1c338" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#d1c338" />
                   <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
               </asp:Calendar>
               <br />
               <asp:Label ID="lblDateSelected" runat="server" CssClass="txt-descrip"></asp:Label>
               <br />
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
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
             
           </asp:Panel>          
       </div>
       
       
       <div class="col-md-4 column-height">
           <br />
           <asp:Panel ID="pnlUpcomingEvent" runat="server" CssClass="pnl-box">
               <asp:Label ID="lblEventTitle" runat="server" Text="Upcoming Events" CssClass="title-box"></asp:Label>
               <br />
               <asp:Panel ID="pnlUp1" runat="server" CssClass="pnl-inside">

                   <div class="col-md-11 pnl-descrip">
                       <asp:Label ID="lblP1Title" runat="server" CssClass="txt-descrip" Text="Title..." Font-Bold="True"></asp:Label>
                       <br />
                       <asp:Label ID="lblP1Location" runat="server" CssClass="txt-descrip" Text="Location"></asp:Label>
                       <br />
                       <asp:Label ID="lblP1Descrip" runat="server" CssClass="txt-descrip" Text="Description..."></asp:Label>
                       <br />
                       <asp:Label ID="lblP1Date" runat="server" CssClass="txt-descrip txt-date" Text="Friday, February 10th, 2017 at 8:00PM" Font-Italic="True"></asp:Label>    
                   </div>
                   <div class="col-sm-1 pnl-descrip">
                       <asp:Button ID="btP1View" runat="server" CssClass="btn-descrip" OnClick="btP1View_Click" Text="" />

                   </div>


               </asp:Panel>
               <br />
               <asp:Panel ID="pnlUp2" runat="server" CssClass="pnl-inside">
                   <div class="col-sm-11 pnl-descrip">
                    <asp:Label ID="lblP2Title" runat="server" CssClass="txt-descrip" Text="Title..." Font-Bold="True"></asp:Label>
                       <br />
                       <asp:Label ID="lblP2Location" runat="server" CssClass="txt-descrip" Text="Location"></asp:Label>
                       <br />
                       <asp:Label ID="lblP2Descrip" runat="server" CssClass="txt-descrip" Text="Description..."></asp:Label>
                       <br />                     
                        <asp:Label ID="lblP2Date" CssClass="txt-descrip" runat="server" Text="Friday, February 10th, 2017 at 8:00PM" Font-Italic="True"></asp:Label>
                   
                   </div>
                   <div class="col-sm-1 pnl-descrip">
                       <asp:Button ID="btnP2View" runat="server" CssClass="btn-descrip" OnClick="btnP2View_Click" Text="" />
                   </div>
               </asp:Panel>
               <br />
               <asp:Panel ID="pnlUp3" runat="server" CssClass="pnl-inside">
                   <div class="col-sm-11 pnl-descrip">
                       <asp:Label ID="lblP3Title" runat="server" CssClass="txt-descrip" Text="Title..." Font-Bold="True"></asp:Label>
                       <br />
                       <asp:Label ID="lblP3Location" runat="server" CssClass="txt-descrip" Text="Location"></asp:Label>
                       <br />
                       <asp:Label ID="lblP3Descrip" runat="server" CssClass="txt-descrip" Text="Description..."></asp:Label>
                       <br />
                       <asp:Label ID="lblP3Date" CssClass="txt-descrip" runat="server" Text="Friday, February 10th, 2017 at 8:00PM" Font-Italic="True"></asp:Label>
                                        
                   </div>
                   <div class="col-sm-1 pnl-descrip">
                       <asp:Button ID="btnP3View" runat="server" CssClass="btn-descrip" OnClick="btnP3View_Click" Text="" />
                   </div>

               </asp:Panel>
               <br />

           </asp:Panel>
           <br />
           <br />
           <asp:Panel ID="pnlFeatured" runat="server" CssClass="pnl-box">
               <asp:Label ID="lblFeaturedTitle" runat="server" Text="Featured" CssClass="title-box"></asp:Label>
               <br />
               <asp:Panel ID="pnlFeat1" runat="server" CssClass="pnl-inside">
               </asp:Panel>
               <br />
               <asp:Panel ID="pnlFeat2" runat="server" CssClass="pnl-inside">
               </asp:Panel>
               <br />
               <asp:Panel ID="pnlFeat3" runat="server" CssClass="pnl-inside">
               </asp:Panel>
               <br />
           </asp:Panel>
           <br />
           <br />
       </div> 
       <div class="col-md-4">
           <asp:Panel ID="pnlRight" runat="server" CssClass="pnl-left">
               <div>
                   <asp:Label ID="lblSaleTitle" runat="server" Text="Items" CssClass="title-default" Font-Underline="True"></asp:Label>
               </div>
               <div class="row">
                   <div class="col-md-4">
                         <asp:Label ID="Label1" runat="server" CssClass="txt-descrip" Text="Item1"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label2" runat="server" CssClass="txt-descrip" Text="Item2"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label3" runat="server" CssClass="txt-descrip" Text="Item3"></asp:Label>
                   </div>
               </div>
               <div class="row">
                   <div class="col-md-4">
                        <asp:Label ID="Label4" runat="server" CssClass="txt-descrip" Text="Item4"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label5" runat="server" CssClass="txt-descrip" Text="Item5"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label6" runat="server" CssClass="txt-descrip" Text="Item6"></asp:Label>
                   </div>
               </div>
               <div class="row">
                   <div class="col-md-4">
                        <asp:Label ID="Label7" runat="server" CssClass="txt-descrip" Text="Item7"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label8" runat="server" CssClass="txt-descrip" Text="Item8"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label9" runat="server" CssClass="txt-descrip" Text="Item9"></asp:Label>
                   </div>
               </div>

               <br />
               <br />
               <br />
               <br />
               <br />
               <div>
                   <asp:Label ID="lblServiceTitle" runat="server" Text="Services" CssClass="title-default" Font-Underline="True"></asp:Label>
               </div>
                <div class="row">
                   <div class="col-md-4">
                         <asp:Label ID="Label10" runat="server" CssClass="txt-descrip" Text="Item1"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label11" runat="server" CssClass="txt-descrip" Text="Item2"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label12" runat="server" CssClass="txt-descrip" Text="Item3"></asp:Label>
                   </div>
               </div>
               <div class="row">
                   <div class="col-md-4">
                        <asp:Label ID="Label13" runat="server" CssClass="txt-descrip" Text="Item4"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label14" runat="server" CssClass="txt-descrip" Text="Item5"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label15" runat="server" CssClass="txt-descrip" Text="Item6"></asp:Label>
                   </div>
               </div>
               <div class="row">
                   <div class="col-md-4">
                        <asp:Label ID="Label16" runat="server" CssClass="txt-descrip" Text="Item7"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label17" runat="server" CssClass="txt-descrip" Text="Item8"></asp:Label>
                   </div>
                   <div class="col-md-4">
                        <asp:Label ID="Label18" runat="server" CssClass="txt-descrip" Text="Item9"></asp:Label>
                   </div>
               </div>
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
           </asp:Panel>
       </div>
   </div>



</asp:Content>
