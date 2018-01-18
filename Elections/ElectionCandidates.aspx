<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionCandidates.aspx.cs" Inherits="Candidates_ElectionCandidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Election Candidates
      <span style="padding-left: 100px">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </span>
    </h1>
    <table class="table-form">

       <tr>
            
            <td class="label" style="width: 10%;">Province:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>
           <td class="label" style="width: 10%;">District:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>
           
        </tr>
        <tr>
             
            <td class="label">Party:</td>
            <td>
                <asp:DropDownList ID="ddlParty" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlParty_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label">Candidate:</td>
            <td>
                <asp:DropDownList ID="ddlCandidate" runat="server"></asp:DropDownList>
            </td> 

        </tr>
        <tr>
                     
             
            
                <td>Select Type :</td>
            <td>
                <asp:RadioButtonList ID="rdoType" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoType_SelectedIndexChanged">
                    <asp:ListItem Text="NA" Value="NA" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
               <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr id="trPA" runat="server" style="display:none;">
         
            <td  class="label" >PA:</td>
            <td  id="tdPA" runat="server" >
                <asp:DropDownList ID="ddlPA" runat="server"></asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />

            </td>
        </tr>

        <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="False" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr #">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
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

                           

                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="del" CssClass="icon-delete" CommandName='<%# Bind("Type") %>' CommandArgument='<%# Bind("Id") %>' runat="server" OnClick="deleteRecord"> </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </td>
        </tr>
    </table>
</asp:Content>

