<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddCandidates.aspx.cs" EnableViewState="true"  Inherits="Candidates_AddCandidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add/Edit Candidate
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
     <table class="table-form">
        <tr>
            <td class="label">Name:</td>
            <td>
               <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>            
            <td colspan="2" rowspan="3" style="text-align:center">
                <div style="text-align:center;    width: 50%;margin: 0 auto;">
                <%--<img src="../images/dumy.png" runat="server" id="candPic"  class="picture" width="120" height="120" />--%>
                    <asp:Image runat="server" ID="candPic" ImageUrl="~/images/dumy.png" CssClass="picture"  width="120" height="120"  />
                <asp:FileUpload ID="picUpload" runat="server" />                
                    </div>
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
            <td  class="label"  style="width:20%">Education:</td>
            <td  style="width:30%">
                <asp:TextBox ID="txtEdu" runat="server"></asp:TextBox>                
            </td>
            <td  class="label"  style="width:20%">Relation With Military:</td>
            <td  style="width:30%">                
                <asp:TextBox ID="txtRWM" runat="server"></asp:TextBox>
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
            <td  class="label">Relation With Politics:</td>
            <td>
                <asp:TextBox ID="txtRWP" runat="server"></asp:TextBox>
            </td>
            <td  class="label">Moral Characteristics:</td>
            <td>
                <asp:TextBox ID="txtMC" runat="server"></asp:TextBox>
            </td>           
        </tr>
          <tr>
               <td  class="label">Financial Characteristics:</td>
            <td>
                <asp:TextBox ID="txtFC" runat="server"></asp:TextBox>
            </td>
              <td  class="label">View About Establishment:</td>
            <td>
                <asp:TextBox ID="txtVAE" runat="server"></asp:TextBox>
            </td>                    
        </tr>         
         <tr>
              <td  class="label">Important Appointments:</td>
            <td>
                <asp:TextBox ID="txtImpApp" runat="server"></asp:TextBox>
            </td> 
              <td  class="label">Scandles:</td>
            <td>
                <asp:TextBox ID="txtScandles" runat="server"></asp:TextBox>
            </td>
         </tr>
         <tr>
              
            <td  class="label">Present Address:</td>
            <td>
                <asp:TextBox ID="txtPresentAdd" runat="server"></asp:TextBox>
            </td>
            <td  class="label">Permanent Address:</td>
            <td>
                <asp:TextBox ID="txtPermanentAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td  class="label">Other Observations:</td>
            <td colspan="3">
                <asp:TextBox ID="txtObservations" runat="server" style="width:100%; height:100px;"></asp:TextBox>                
            </td>
            
        </tr>
         <tr>
             <td colspan="4" style="text-align:center;">
                 <asp:Button ID="btnSave" runat="server"  CssClass="btn" Text="Save" OnClick="btnSave_Click" />
                 &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnClear" runat="server"  CssClass="btn" Text="Clear" OnClick="btnClear_Click" />
             </td>
         </tr>
    </table>
    <asp:HiddenField  ID="hdnCandidateId" runat="server" Value="0"/>
</asp:Content>

