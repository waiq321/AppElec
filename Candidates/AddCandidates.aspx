<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddCandidates.aspx.cs" Inherits="Candidates_AddCandidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add/Edit Candidate</h1>
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
            <td  class="label">Relation With Judiciary:</td>
            <td>
                <asp:TextBox ID="txtRWJ" runat="server"></asp:TextBox>
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
          <tr>
              <td  class="label">View About Establishment:</td>
            <td>
                <asp:TextBox ID="txtVAE" runat="server"></asp:TextBox>
            </td>
            <td  class="label">Important Appointments:</td>
            <td>
                <asp:TextBox ID="txtImpApp" runat="server"></asp:TextBox>
            </td>           
        </tr>
         <tr>
            <td  class="label">Present Address:</td>
            <td>
                <asp:TextBox ID="txtPresentAdd" runat="server"></asp:TextBox>
            </td>
            <td  class="label">Permanent :</td>
            <td>
                <asp:TextBox ID="txtPermanentAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
              <td  class="label">Scandles:</td>
            <td>
                <asp:TextBox ID="txtScandles" runat="server"></asp:TextBox>
            </td>
         </tr>
         <tr>
            <td  class="label">Other Observations:</td>
            <td colspan="3">
                <asp:TextBox ID="TextBox1" runat="server" style="width:100%; height:100px;"></asp:TextBox>                
            </td>
            
        </tr>
         <tr>
             <td colspan="4" style="text-align:center;">
                 <asp:Button ID="btnSave" runat="server"  CssClass="btn" Text="Save" OnClick="btnSave_Click" />
             </td>
         </tr>
    </table>
</asp:Content>

