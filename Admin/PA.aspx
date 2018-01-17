<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="PA.aspx.cs" Inherits="Admin_PA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Add PA
      <span style="padding-left: 100px">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </span>
    </h1>
    <table class="table-form">
        <tr>
            <td class="label" style="width: 10%;">Province:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>

            <td class="label" style="width: 10%;">District:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged1"></asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td class="label" style="width: 10%;">NA:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlNA_SelectedIndexChanged"></asp:DropDownList>
            </td>

            <td class="label" style="width: 10%;">PA Name:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtNAName" runat="server"></asp:TextBox>
            </td>

        </tr>

        <tr>




            <td class="label" style="width: 10%;">Category:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Selected="True" Value="Rural">Rural</asp:ListItem>
                    <asp:ListItem Value="Urban">Urban</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="label" style="width: 10%;">Latitude:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>

            <td class="label" style="width: 10%;">Longitude:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
            </td>
            <td class="label" style="width: 10%;">Famous Place:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtFamousPlace" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>

            <td class="label" style="width: 10%;">Created Date:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtCreatedDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />
                <asp:Button ID="btnUpdate" Visible="false" CssClass="btn" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr #">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPA" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Bind("Category") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Latitude">
                                <ItemTemplate>
                                    <asp:Label ID="lblLatitude" runat="server" Text='<%#Bind("Latitude") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Longitude">
                                <ItemTemplate>
                                    <asp:Label ID="lblLongitude" runat="server" Text='<%#Bind("Longitude") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Famous Place">
                                <ItemTemplate>
                                    <asp:Label ID="lblFamousPlace" runat="server" Text='<%#Bind("FamousPlace") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Bind("CreatedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton CausesValidation="false" CssClass="icon-edit" ID="lnkbtnedit" CommandName='<%# Bind("PAId") %>' runat="server" OnClick="lnkbtnedit_Click"> </asp:LinkButton>
                                    &nbsp;
                                   <asp:LinkButton ID="del" CausesValidation="false" CssClass="icon-delete" CommandName='<%# Bind("PAId") %>' runat="server" OnClick="deleteRecord"> </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hdID" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

