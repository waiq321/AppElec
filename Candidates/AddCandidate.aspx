<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddCandidate.aspx.cs" Inherits="Candidates_AddCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>Name:</td>
            <td>
                <input type="text"  id="txtName"/>
            </td>            
            <td colspan="2" rowspan="3">
                <asp:Image ID="picture" runat="server" />
            </td>
        </tr>
        <tr>
            <td>NIC#:</td>
            <td><input type="text"  id="txtNIC"/></td>            
        </tr>
        <tr>
            <td>Party:</td>
            <td>
                <select id="ddlParty"></select>
            </td>   
            <td>Relation With Judiciary:</td>
            <td></td>
        </tr>

    </table>
</asp:Content>


