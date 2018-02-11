<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="LBElectionResults.aspx.cs" Inherits="Election_LBElectionResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Local Body Election Results
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">

        
          <tr>
            <td class="label" style="width: 10%;">Election Year:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" style="width: 10%;">Province:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td class="label" style="width: 10%;">District:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>

             <td class="label">Party:</td>
            <td>
                <asp:DropDownList ID="ddlParty" AutoPostBack="true" runat="server" ></asp:DropDownList>
            </td>

        </tr>
        
        
        <tr>
             <td class="label">Type:</td>
            <td>
                <asp:DropDownList ID="ddlType" AutoPostBack="true" runat="server" > 
                     <asp:ListItem Selected="True" Value="Mayer">Mayer</asp:ListItem>
                    <asp:ListItem Value="Dupt Mayer">Dupt Mayer</asp:ListItem>
                    <asp:ListItem Value="Chairman">Chairman</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td class="label" style="width: 10%;">Name:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            

        </tr>
         <tr>
           
           <td class="label" style="width: 10%;">Position:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlPosition" AutoPostBack="true" runat="server" > 
                     <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                  <asp:Button ID="Btn_Save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click"  />
            </td>
        </tr>

        <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Ser">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Election Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblLBElectionYear" runat="server" Text='<%#Bind("LBElectionYear") %>'></asp:Label>
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

                          

                              <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartyTypee" runat="server" Text='<%#Bind("PartyType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Candidate Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Position">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosition" runat="server" Text='<%#Bind("Position") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                     
                        </Columns>
                    </asp:GridView>

                </div>
            </td>
        </tr>
        
    </table>
</asp:Content>

