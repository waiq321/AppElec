﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="NAInfulense.aspx.cs" Inherits="NAInfulense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>
        Na Influential / Spoilers :
     
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
            <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA" runat="server" ></asp:DropDownList>
            </td>
            <td colspan="2" style="text-align: center;">
                <asp:Button ID="btnSearch" Text="Save" CssClass="btn" runat="server" OnClick="btnSearch_Click" />

            </td>    
        </tr>
        
     
    </table>
    <div style="margin-top:20px;">
        <h1>Influential Person</h1>
    <table class="table-form">
     <tr>
        <td class="label" >Name :</td>
        <td >
            <asp:textbox id ="txt_In_Name" runat ="server"></asp:textbox>
        </td>
        <td class="label" >Type of Infulence :</td>
        <td >
            <asp:textbox id ="txt_Type_inf" runat ="server"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td class="label" >Political Leaning :</td>
        <td >
            <asp:textbox id ="txt_political_leaning" runat ="server"></asp:textbox>
        </td>
        <td class="label">Profession :</td>
        <td>
            <asp:textbox id ="txt_profrssion" runat ="server"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center;" class ="label">-:: Relationship ::-</td>
    </tr>
        <tr>
            <td colspan ="2" class="label">
                Political :
            </td>
            <td>
                 <asp:textbox id ="txt_poli_Relation" runat ="server"></asp:textbox>
        </td>
        </tr>
        <tr>
            <td colspan ="2" class="label">
                Bueurocracy :
            </td>
            <td>
                 <asp:textbox id ="txtbureaucratic" runat ="server"></asp:textbox>

            </td>
        </tr>
        <tr>
            <td colspan ="2" class="label">
                Military :
            </td>
            <td>
                 <asp:textbox id ="txtMilitary" runat ="server"></asp:textbox>

            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_Save_INF" Text="Save" CssClass="btn" runat="server" OnClick="btn_SaveINF_Click" />

            </td>
        </tr>

        <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridViewInf" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Ser">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Infulence Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblTYPE_Inf" runat="server" Text='<%#Bind("TYPE_Inf") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Political Leaning">
                                <ItemTemplate>
                                    <asp:Label ID="lblPolitical_leaning" runat="server" Text='<%#Bind("Political_leaning") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Profession">
                                <ItemTemplate>
                                    <asp:Label ID="lblProfession" runat="server" Text='<%#Bind("Profession") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Relation police">
                                <ItemTemplate>
                                    <asp:Label ID="lblRel_poli" runat="server" Text='<%#Bind("Rel_poli") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Relation Beauricracy">
                                <ItemTemplate>
                                    <asp:Label ID="lblRel_Beau" runat="server" Text='<%#Bind("Rel_Beau") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Relation Millitary">
                                <ItemTemplate>
                                    <asp:Label ID="lblRel_Mili" runat="server" Text='<%#Bind("Rel_Mili") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>

                </div>
            </td>
        </tr>
    </table>
        <h1>Spoilers</h1>
    <table  class="table-form">
        <tr>
            <td class ="label">Individuals :</td>
            <td> 
                 <asp:textbox id ="txt_Ind" runat ="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class ="label">Factors :</td>
            <td> 
                 <asp:textbox id ="TxtFactor" runat ="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            
                <td colspan ="2" style ="text-align: center;">
                    <asp:Button ID="Btn_Save_Spo" Text="Save" CssClass="btn" runat="server" OnClick="Btn_Save_Spo_Click"  />
                </td>
            
        </tr>
        <tr>            
                <td colspan ="2" style ="text-align: center;">
                    <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr #">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lbl" runat="server" Text='<%#Bind("") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                </td>            
        </tr>
    </table>
</asp:Content>

