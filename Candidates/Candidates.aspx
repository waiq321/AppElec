<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Candidates.aspx.cs" Inherits="Candidates_Candidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Candidates
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
    <fieldset>
        <legend>
            Filter Parameters
        </legend>
        <table class="table-form">
            <tr>
                <td class="label" style="width:10%;">Party:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlParty" runat="server"></asp:DropDownList>
                </td>
                <td class="label"   style="width:10%;">Name:</td>
                <td   style="width:20%;">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
      <div style="padding-top:10px;">
          
                <asp:GridView ID="grdCandidates" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sr #">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party">
                            <ItemTemplate>
                                <asp:Label ID="lblParty" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NIC">
                            <ItemTemplate>
                                <asp:Label ID="lblNIC" runat="server" Text='<%#Bind("NIC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Present Address">
                            <ItemTemplate>
                                 <asp:Label ID="lblPresentAddress" runat="server" Text='<%#Bind("PresentAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Add Relations">
                            <ItemTemplate>
                                   <span class="link"  onclick="lnkClick(this,'Father')">Add Father</span> &nbsp;&nbsp;
                                <span  class="link" onclick="lnkClick(this,'Spouse')">Add Spouse</span>                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Action" HeaderStyle-Width="200px" >
                      <ItemTemplate>
                          <span class="icon-edit" title="Edit" onclick="lnkClick(this,'Edit')"></span>
                          <span class="icon-details" title="Details" onclick="lnkClick(this,'Details')"></span>

                          <%--<asp:LinkButton ID="lnkEdit" CommandArgument='<%#Bind("CandidateId") %>' OnClick="lnkEdit_Click" runat="server">Edit</asp:LinkButton>--%>
                          &nbsp;&nbsp;                                                   
                          <asp:HiddenField ID="hdnCandidateId" runat="server" Value='<%#Bind("CandidateId") %>'></asp:HiddenField>
                      </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              
                    </div>

    <script type="text/javascript">
        function lnkClick(elem,callFrom) {
            
            var candidateId = $.trim($(elem).closest("tr").find("[id*='hdnCandidateId']").val());
            if (callFrom == "Father")
                window.open("../Candidates/Father.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Spouse")
                window.open("../Candidates/Spouse.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Edit")
                window.open("../Candidates/AddCandidates.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Details")
                window.open("../Candidates/CandidateDetails.aspx?CandId=" + candidateId, "_blank");
        }
        
    </script>
</asp:Content>

