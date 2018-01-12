<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionYears.aspx.cs" Inherits="Admin_ElectionYears" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table class="table-form">  
       
       <tr>
            <td  class="label">Election Year:</td>
            <td colspan="3">
                <asp:TextBox ID="txtElecYear" runat="server"></asp:TextBox>                
            </td>
            
        </tr>

      <tr>
          <td colspan="3" style="text-align:center;">
              <asp:Button ID="btn_save" Text="Save" CssClass="btn"  runat="server" OnClick="btn_save_Click" />
              <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
          </td>
      </tr>
      <tr>
            
          <td align="center" colspan="2">
              <div class="table-bordered">
                <asp:GridView  ID="GridView1" CssClass="table-striped" AutoGenerateColumns="false" runat="server"  Width="100%">
              <Columns>
                  <asp:TemplateField HeaderText="Sr #">
                      <ItemTemplate>
                          <%#Container.DataItemIndex+1 %>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Election Year">
                      <ItemTemplate>
                          <asp:Label ID="lblid" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField >
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Bind("ElectionId") %>' OnClick="LinkButton1_Click" runat="server">Delete</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
            </asp:GridView>
                  </div>
</td>
                
  </table> 
</asp:Content>

