<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="NA.aspx.cs" Inherits="Elections_NA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>Register national Assembly Constituency </h1>
    <br />

    <table class ="table-form">
       <tr>
            <td class ="label">
                Name :
            </td>
            <td >
                  <asp:TextBox ID ="txt_Name" runat ="server"></asp:TextBox>
            </td>
            <td class ="label">
                Provience :
            </td>
                    
            <td>
                <asp:DropDownList ID="ddl_provence" runat ="server">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class ="label">
                Category :</td>
            <td >
                <asp:DropDownList ID="ddl_provence0" runat ="server">
                    </asp:DropDownList>
            </td>
            <td class ="label">
                District :</td>
            <td>
                <asp:DropDownList ID="ddl_provence1" runat ="server">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class ="label">
                Total Tehsil :</td>
            <td >
                  <asp:TextBox ID ="txt_tehsil" runat ="server"></asp:TextBox>
            </td>
            <td class ="label">
                Polling Station (Male) :</td>
            <td>
                  <asp:TextBox ID ="txt_PSM" runat ="server"></asp:TextBox>
            </td>
        </tr>

          


        <tr>
            <td class ="label">
                Total UC :</td>
            <td >
                  <asp:TextBox ID ="txt_UC" runat ="server"></asp:TextBox>
            </td>
            <td class ="label">
                Polling Station (Female) :</td>
            <td>
                  <asp:TextBox ID ="txt_PSF" runat ="server"></asp:TextBox>
            </td>
        </tr>

          


        <tr>
            <td class ="label">
                Latitute :</td>
            <td >
                  <asp:TextBox ID ="txt_lat" runat ="server"></asp:TextBox>
            </td>
            <td class ="label">
                Famous Place :</td>
            <td>
                  <asp:TextBox ID ="txt_FP" runat ="server"></asp:TextBox>
            </td>
        </tr>

          


        <tr>
            <td class ="label">
                longitute :</td>
            <td >
                  <asp:TextBox ID ="txt_lon" runat ="server"></asp:TextBox>
            </td>
            <td class ="label">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

          


        <tr>
            <td class ="label">
                &nbsp;</td>
            <td colspan="2" style="text-align: center; vertical-align: middle" >
                <asp:Button ID="btn_save" runat="server" Text="Save" />
            </td>
            <td>
                &nbsp;</td>
        </tr>

          


        <tr>
            <td class ="label">
                &nbsp;</td>
            <td colspan="2" style="text-align: center; vertical-align: middle" >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

          


        <tr>
            <td class ="label" colspan="4" style="align:center; text-align: center; vertical-align: middle" >
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found...">
                </asp:GridView>
            </td>
        </tr>

          


    </table>
</asp:Content>

