<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="NAStatisticsReport.aspx.cs" Inherits="Reports_NAStatisticsReport" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScrptMng" runat="server" ></asp:ScriptManager>
    <h1>Election Candidates
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">

          <tr>
           
            <td class="label" style="width: 10%;">Province:</td>
            <td style="width: 40%;">
                <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>
               <td class="label" style="width: 10%;">District:</td>
            <td style="width: 40%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
           

            <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" runat="server" ></asp:DropDownList>
            </td>  
            <td colspan="2">
                 <asp:Button ID="btn_Search" Text="Search" CssClass="btn" runat="server" OnClick="btn_Search_Click" />
            </td>         
        </tr>
       
        <tr>
            <td colspan="4" style="text-align: center;">
               
               <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
                <br />
                <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server">
                </rsweb:ReportViewer>
            </td>
        </tr>
        
    </table>
    
</asp:Content>

