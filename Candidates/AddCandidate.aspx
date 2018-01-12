<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddCandidate.aspx.cs" Inherits="Candidates_AddCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="table-form">
        <tr>
            <td class="label">Name:</td>
            <td>
               <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>            
            <td colspan="2" rowspan="3">
                <asp:FileUpload ID="picUpload" runat="server" />
                <asp:Image ID="picture" runat="server" />
            </td>
        </tr>
        <tr>
            <td  class="label">NIC#:</td>
            <td>
                <asp:TextBox ID="txtNic" runat="server"></asp:TextBox>

            </td>            
        </tr>
        <tr>
            <td  class="label">Party:</td>
            <td>
                <asp:DropDownList ID="ddlParty" runat="server"></asp:DropDownList>
                
            </td>   
            <td  class="label">Relation With Judiciary:</td>
            <td></td>
        </tr>

    </table>
</asp:Content>


