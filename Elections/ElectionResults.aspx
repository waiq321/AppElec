<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionResults.aspx.cs" Inherits="Elections_ElectionResults" %>

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
                    <asp:DropDownList ID="ddlProvince"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                </td>
             
              
 
        </tr>
               <tr>
                    <td class="label" style="width:10%;">District:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlDistrict"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                </td>
               <td class="label" style="width:10%;">NA:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlNA" runat="server" ></asp:DropDownList>
                </td>
                    
        </tr>
             
             <tr>
                  <td class="label" style="width:10%;">NA / PA:</td>
                <td  style="width:20%;">
                 <asp:radiobuttonlist id="RB" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                     <asp:ListItem Selected="True">NA</asp:ListItem>
                     <asp:ListItem>PA</asp:ListItem>
                    </asp:radiobuttonlist>
                    </td>
                   <td class="label" style="width:10%;">Party:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlParty" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlParty_SelectedIndexChanged"></asp:DropDownList>
                </td>

                  <tr>
                  
                   <td class="label" style="width:10%;">Candidate:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlCandidate" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlCandidate_SelectedIndexChanged"></asp:DropDownList>
                </td>
               </tr>
                  <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />
                
                
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
             
             </table>
</asp:Content>


