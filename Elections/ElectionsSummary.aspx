<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionsSummary.aspx.cs" Inherits="Elections_ElectionsSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <h1 style="color:blue;float: left;width: 100%;">
        <div style="width:20%;float:left;">
        <asp:HyperLink ID="HPNAName" runat="server" Target="_blank">
        <asp:Label ID="lblId" runat="server"></asp:Label> Winning Candidates
            </asp:HyperLink> 
            </div>
        <div style="width:20%;float:left;">
        <asp:DataList ID="ddlList" runat="server" RepeatDirection="Horizontal">
            <ItemTemplate>
                (
                <asp:HyperLink ID="HPPAName" Target="_blank" runat="server"  NavigateUrl='<%# Eval("PAId","~/Reports/PAStatisticsReport.aspx?PAID={0}") %>'>
                <asp:Label ID="lblPaName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </asp:HyperLink>
                )
            </ItemTemplate>
        </asp:DataList>
            </div>
    </h1>
    

  <div style="margin-top:50px;">
      <asp:GridView ID="grdWinningCandidates" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%" OnRowDataBound="grdWinningCandidates_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Year">
                <ItemTemplate>
                    <asp:Label ID="lblYear" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Winner 1">
                <ItemTemplate>
                    <div>
                        <div style="text-align:center; padding-top:2px;">
                        <asp:HyperLink runat="server"  Target="_blank" NavigateUrl='<%# Eval("Winner1Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'  >
                            <asp:Image runat="server" ID="Winner1Pic" ImageUrl="~/images/dumy.png" CssClass="picture" Width="100" Height="100" />
                        </asp:HyperLink>                
                            </div>     
                        <div style="padding-left:10px;">
                    <div>
                        <span class="cand-title">Name:</span>
                        <asp:Label ID="lblWinner1Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner1") %>'></asp:Label>
                    </div>
                    <div>
                        <span class="cand-title">Votes: </span>
                        <asp:Label ID="lblWinner1Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner1Votes") %>'></asp:Label>
                    </div>
                        <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty1" CssClass="cand-text" runat="server" Text='<%#Bind("Winner1Party") %>'></asp:Label>
                    </div>
                            </div>
                    <asp:HiddenField ID="hdnWinner1Id" runat="server" Value='<%#Bind("Winner1Id") %>'></asp:HiddenField>
                        </div>
                </ItemTemplate>
                <ItemStyle Width="19%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Winner 2">
                <ItemTemplate>

                    <div>
                        <div style="text-align:center; padding-top:2px;">
                        <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# Eval("Winner2Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'  >
                            <asp:Image runat="server" ID="Winner2Pic" ImageUrl="~/images/dumy.png" CssClass="picture" Width="100" Height="100" />
                        </asp:HyperLink> 
                            </div> 
                        <div style="padding-left:10px;">

                    <div>
                        <span class="cand-title">Name:</span>
                        <asp:Label ID="lblWinner2Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner2") %>'></asp:Label>
                    </div>
                    <div>
                        <span class="cand-title">Votes: </span>
                        <asp:Label ID="lblWinner2Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner2Votes") %>'></asp:Label>
                    </div>
                        <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty2" CssClass="cand-text" runat="server" Text='<%#Bind("Winner2Party") %>'></asp:Label>
                    </div>
                            </div>
                    <asp:HiddenField ID="hdnWinner2Id" runat="server" Value='<%#Bind("Winner2Id") %>'></asp:HiddenField>
                        </div>
                </ItemTemplate>
                <ItemStyle Width="19%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Winner 3">
                <ItemTemplate>
                    <div>
                    <div style="text-align:center; padding-top:2px;">                    
                        <asp:HyperLink runat="server"  Target="_blank" NavigateUrl='<%# Eval("Winner3Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'  >
                            <asp:Image runat="server" ID="Winner3Pic" ImageUrl="~/images/dumy.png" CssClass="picture" Width="100" Height="100" />
                        </asp:HyperLink> 
                        </div>
                        <div style="padding-left:10px;">
                    <div>
                        <span class="cand-title">Name:</span>
                        <asp:Label ID="lblWinner3Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner3") %>'></asp:Label>
                    </div>
                    <div>
                        <span class="cand-title">Votes: </span>
                        <asp:Label ID="lblWinner3Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner3Votes") %>'></asp:Label>
                    </div>
                        <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty3" CssClass="cand-text" runat="server" Text='<%#Bind("Winner3Party") %>'></asp:Label>
                    </div>
                            </div>
                    <asp:HiddenField ID="hdnWinner3Id" runat="server" Value='<%#Bind("Winner3Id") %>'></asp:HiddenField>
                        </div>
                </ItemTemplate>
                <ItemStyle Width="19%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Winner 4">
                <ItemTemplate>
                    <div>
                    <div style="text-align:center; padding-top:2px;">                    
                        <asp:HyperLink runat="server"  Target="_blank" NavigateUrl='<%# Eval("Winner4Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'  >
                            <asp:Image runat="server" ID="Winner4Pic" ImageUrl="~/images/dumy.png" CssClass="picture" Width="100" Height="100" />
                        </asp:HyperLink> 
                        </div>
                        <div style="padding-left:10px;">
                    <div>
                        <span class="cand-title">Name:</span>
                        <asp:Label ID="lblWinner4Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner4") %>'></asp:Label>
                    </div>
                    <div>
                        <span class="cand-title">Votes: </span>
                        <asp:Label ID="lblWinner4Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner4Votes") %>'></asp:Label>
                    </div>
                        <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty4" CssClass="cand-text" runat="server" Text='<%#Bind("Winner4Party") %>'></asp:Label>
                    </div>
                            </div>
                    <asp:HiddenField ID="hdnWinner4Id" runat="server" Value='<%#Bind("Winner4Id") %>'></asp:HiddenField>
                        </div>
                </ItemTemplate>
                <ItemStyle Width="19%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Winner 5">
                <ItemTemplate>
                    <div>
                    <div style="text-align:center; padding-top:2px;">                    
                        <asp:HyperLink runat="server"  Target="_blank" NavigateUrl='<%# Eval("Winner5Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'  >
                            <asp:Image runat="server" ID="Winner5Pic" ImageUrl="~/images/dumy.png" CssClass="picture" Width="100" Height="100" />
                        </asp:HyperLink> 
                        </div>
                        <div style="padding-left:10px;">
                    <div>
                        <span class="cand-title">Name:</span>
                        <asp:Label ID="lblWinner5Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner5") %>'></asp:Label>
                    </div>
                    <div>
                        <span class="cand-title">Votes: </span>
                        <asp:Label ID="lblWinner5Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner5Votes") %>'></asp:Label>
                    </div>
                        <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty5" CssClass="cand-text" runat="server" Text='<%#Bind("Winner5Party") %>'></asp:Label>
                    </div>
                            </div>
                    <asp:HiddenField ID="hdnWinner5Id" runat="server" Value='<%#Bind("Winner5Id") %>'></asp:HiddenField>
                        </div>
                </ItemTemplate>
                <ItemStyle Width="19%" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
      </div>

    <div>

    </div>
</asp:Content>

