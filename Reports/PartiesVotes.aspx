<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="PartiesVotes.aspx.cs" Inherits="Reports_PartiesVotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Parties Votes
      <span style="padding-left: 100px">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </span>
    </h1>
    <table class="table-form">

        <tr>
            <td class="label" style="width: 10%;">Year:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlYear"  runat="server"></asp:DropDownList>
            </td>
               <td  style="text-align: left;">                
                <input type="button" value="Search" class="btn" onclick="getPartiesVotes()" />
            </td>
        </tr>
       
        <tr>
            <td align="center" colspan="3">
                <div style="padding-top: 10px;">
              <div id="PartiesVotes" style="width: 50%;"></div>
                </div>
            </td>
        </tr>
    </table>
    <script src="../Scripts/highcharts.js"></script>
      <script language="JavaScript" type="text/javascript">
          function getPartiesVotes() {
              
              var obj = {};
              obj.electionId = $("[id$='ddlYear']").val();
            
              $.ajax({
                  type: "POST",
                  url: "PartiesVotes.aspx/GetData",
                  data: JSON.stringify(obj),
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {                      
                      var result = response.d;
                      var chartData = result.split('- ');
                      var arrComponent = JSON.parse(chartData[0]);
                      var arrData = JSON.parse(chartData[1]);


                      Highcharts.chart('PartiesVotes', {
                          chart: {
                              type: 'column'
                          },
                          title: {
                              text: 'Parties Total Votes Obtained'
                          },
                          xAxis: {
                              categories: arrComponent,
                              title: {
                                  text: null
                              }
                          },
                          yAxis: {
                              min: 0,
                              labels: {
                                  formatter: function () {
                                      return this.value
                                  }, style: {
                                      color: '#008d4c',
                                      'font-weight': 'bold',
                                  }
                              },
                              title: {
                                  text: 'Votes Obtained', style: {
                                      color: '#008d4c',
                                      'font-weight': 'bold',
                                  }
                              }
                          },
                          tooltip: {
                              valueSuffix: ' millions'
                          },
                          plotOptions: {
                              bar: {
                                  dataLabels: {
                                      enabled: true
                                  }
                              }
                          },
                          legend: {
                              layout: 'vertical',
                              align: 'right',                              
                              verticalAlign: 'top',
                              x: -40,
                              y: 80,
                              floating: true,
                              borderWidth: 1,
                              backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                              shadow: true
                          },
                          credits: {
                              enabled: false
                          },
                          series: [{
                              name: $("[id$='ddlYear'] :selected").text(),
                              data: arrData
                          }]
                      });

                  }
              });

          }
    </script>
</asp:Content>

