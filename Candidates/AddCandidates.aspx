<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddCandidates.aspx.cs" Inherits="Candidates_AddCandidates" %>

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
            <td>
                <asp:TextBox ID="txtRWJ" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="label">Relation With Military:</td>
            <td>
                <asp:TextBox ID="txtRWM" runat="server"></asp:TextBox>
            </td>
            <td  class="label">Relation With Politics:</td>
            <td>
                <asp:TextBox ID="txtRWP" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="label">Relation With Bureaucracy:</td>
            <td>
                <asp:TextBox ID="txtRWB" runat="server"></asp:TextBox>
            </td>
            <td  class="label">View About Establishment:</td>
            <td>
                <asp:TextBox ID="txtVAE" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="label">Moral Characteristics:</td>
            <td>
                <asp:TextBox ID="txtMC" runat="server"></asp:TextBox>
            </td>
            <td  class="label">Financial Characteristics:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>

