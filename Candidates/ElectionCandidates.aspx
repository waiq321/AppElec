<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionCandidates.aspx.cs" Inherits="Candidates_ElectionCandidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <h1>Election Candidates
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
         <table class="table-form">

             <tr>
                 <td class="label" style="width:10%;">Year:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlElectionYear" runat="server"></asp:DropDownList>
                </td>
               <td class="label" style="width:10%;">Province:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlProvince" runat="server"></asp:DropDownList>
                </td>
             
              
 
        </tr>
               <tr>
                    <td class="label" style="width:10%;">District:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlDistrict" runat="server"></asp:DropDownList>
                </td>
               <td class="label" style="width:10%;">NA:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlNA" runat="server"></asp:DropDownList>
                </td>
                    
              
             
               
        </tr>

             <tr>
                   <td class="label" style="width:10%;">Party:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlParty" runat="server"></asp:DropDownList>
                </td>
              
                   <td class="label" style="width:10%;">Candidate:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlCandidate" runat="server"></asp:DropDownList>
                </td>
               </tr>
             <tr>
                 <td class="label" style="width:10%;">Type:</td>
                <td  style="width:20%;">
                    <asp:TextBox ID="txtCandidateType" runat="server"></asp:TextBox>
                </td>
             </tr>
                  <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />
                <asp:Button CausesValidation="false"  ID="btnUpdate" Visible="false" ValidationGroup="validate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
        </tr>

                   <tr>

            <td align="center" colspan="4">
                <div style="padding-top:10px;">
                <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr #">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Election Year">
                            <ItemTemplate>
                                <asp:Label ID="lblElectionYear" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Province Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProvinceName" runat="server" Text='<%#Bind("ProvinceName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="District Name">
                            <ItemTemplate>
                                <asp:Label ID="lblDistrictName" runat="server" Text='<%#Bind("District") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        
                         <asp:TemplateField HeaderText="Party Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Candidate">
                            <ItemTemplate>
                                <asp:Label ID="lblCandidate" runat="server" Text='<%#Bind("Candidate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Candidate Type">
                            <ItemTemplate>
                                <asp:Label ID="lblCandidateType" runat="server" Text='<%#Bind("CandidateType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                       

                        
                         <asp:TemplateField HeaderText="Edit Record">
                               <ItemTemplate>
                                 <asp:LinkButton CausesValidation="false" ID="lnkbtnedit" Text="Edit" CommandName='<%# Bind("Id") %>' runat="server" OnClick="lnkbtnedit_Click" > </asp:LinkButton>
                           </ItemTemplate>
                              </asp:TemplateField>
           
                               <asp:TemplateField HeaderText="Delete Record">
                  <ItemTemplate>
                    <asp:LinkButton ID="del" CausesValidation="false" Text="Delete" CommandName='<%# Bind("Id") %>' runat="server" OnClick="deleteRecord" > </asp:LinkButton>
                </ItemTemplate>
           
                 </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    <asp:HiddenField ID="hdID" runat="server" />
                    </div>
            </td>
        </tr>
         </table>
</asp:Content>

