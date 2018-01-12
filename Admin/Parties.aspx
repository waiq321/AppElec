<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Parties.aspx.cs" Inherits="Admin_Parties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="table-form">

        <tr>
            <td class="label" style="width: 20%">Party Name:</td>
            <td style="width: 30%">
                <asp:TextBox ID="txtPartyName" runat="server"></asp:TextBox>
            </td>
            <td class="label" style="width: 20%">Chairman:</td>
            <td style="width: 30%">
                <asp:TextBox ID="TxtChairman" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="label">Registration Date:</td>
            <td>
                <asp:TextBox ID="txtRegistrationDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td class="label">Reg #:</td>
            <td>
                <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td class="label">Party Off:</td>
            <td>
                <asp:TextBox ID="Partyoff" runat="server"></asp:TextBox>
            </td>
            <td class="label">Logo:</td>
            <td>
                <asp:FileUpload ID="picUpload" runat="server" />
            </td>

        </tr>


        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>

            <td align="center" colspan="4">
                <div style="padding-top:10px;">
                <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr #">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Chairmain">
                            <ItemTemplate>
                                <asp:Label ID="lblChairmain" runat="server" Text='<%#Bind("Chairmain") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Registration Date">
                            <ItemTemplate>
                                <asp:Label ID="lblRegistrationDate" runat="server" Text='<%#Bind("RegistrationDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party No">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyNo" runat="server" Text='<%#Bind("PartyNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party Off">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyOff" runat="server" Text='<%#Bind("PartyOff") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party Logo">
                            <ItemTemplate>
                                <asp:Label ID="lblLogo" runat="server" Text='<%#Bind("Logo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>

