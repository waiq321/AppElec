<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionRecommendation.aspx.cs" Inherits="Election_ElectionRecommendation" %>

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
            <td class="label" style="width: 10%;">Year:</td>
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

            <td class="label">Select Type :</td>
            <td>
                <asp:RadioButtonList ID="rdoType" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoType_SelectedIndexChanged">
                    <asp:ListItem Text="NA" Value="NA" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                </asp:RadioButtonList>
            </td>

        </tr>

        <tr>

            <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlNA_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" id="tdPA1" runat="server" style="display: none;">PA:</td>
            <td id="tdPA2" runat="server" style="display: none;">
                <asp:DropDownList ID="ddlPA" runat="server"></asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="label">Likely Winning Party:</td>
            <td>
                <asp:DropDownList ID="ddlLWParty" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlLWParty_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label">Candidate:</td>
            <td>
                <asp:DropDownList ID="ddlCandidate1" runat="server"></asp:DropDownList>
            </td>

        </tr>

         <tr>
             
             <td class="label" style="width: 10%;">Factor/Remarks:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtLWFactor" runat="server" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>
                <tr>
            <td>&nbsp;</td>
        </tr>
           <tr>
            <td class="label">Other Likely Party:</td>
            <td>
                <asp:DropDownList ID="ddlOLWParty" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlOLWParty_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label">Candidate:</td>
            <td>
                <asp:DropDownList ID="ddlCandidate2" runat="server"></asp:DropDownList>
            </td>

        </tr>

         <tr>
             
             <td class="label" style="width: 10%;">Factor/Remarks:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtOLWFactor" runat="server" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
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
                            <asp:TemplateField HeaderText="Ser">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="First Wining Party">
                                <ItemTemplate>
                                    <asp:Label ID="lblFWParty" runat="server" Text='<%#Bind("FWParty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Candidate">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstWiningCandidate" runat="server" Text='<%#Bind("FirstWiningCandidate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Factors">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstFactors" runat="server" Text='<%#Bind("FirstFactors") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Second Wining Party">
                                <ItemTemplate>
                                    <asp:Label ID="lblSWParty" runat="server" Text='<%#Bind("SWParty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Candidate">
                                <ItemTemplate>
                                    <asp:Label ID="lblSecondWiningCandidate" runat="server" Text='<%#Bind("SecondWiningCandidate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Factors">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSecondFactors" runat="server" Text='<%#Bind("SecondFactors") %>'></asp:Label>
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

