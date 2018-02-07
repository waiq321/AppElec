using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;

public partial class Reports_NAStatisticsReport : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            GetProvince();
            GetDistrict();
            GetNA();
            
        }
    }
    
    protected void GetProvince()
    {
            CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
            ddlProvince.DataSource = objCommonFunctionsProvince.GetProvince();

            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceId";
            ddlProvince.DataBind();
    }
    protected void GetDistrict()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlDistrict.DataSource = objCommonFunctionsGetDistrict.GetDistrict(ddlProvince.SelectedValue);

        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "DistrictId";
        ddlDistrict.DataBind();

    }
    
    protected void GetNA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlNA.DataSource = objCommonFunctionsGetNA.GetNA(ddlDistrict.SelectedValue);

        ddlNA.DataTextField = "Name";
        ddlNA.DataValueField = "NAId";
        ddlNA.DataBind();
    }
    
   
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();        
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();        
    }
    private void ShowReport()
    {
        try
        {
            DBManager dbMgr = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                
                new SqlParameter("@NAId",ddlNA.SelectedValue)
                
            };
            DataSet ds = dbMgr.ExecuteDataSet("Report_GetNAStatistics", parm);


            ReportViewer1.LocalReport.ReportPath = Server.MapPath("NAStatisticsReport.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource repDs = new ReportDataSource();
         
            //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("Report_GetNAStatistics", ds.Tables[0]));

            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetFigure", ds.Tables[0]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetVoters", ds.Tables[1]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", ds.Tables[2]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", ds.Tables[3]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetInflueienceFigure", ds.Tables[4]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", ds.Tables[5]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetVotesObtained", ds.Tables[6]));

            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(subReports);

           // ReportViewer1.LocalReport.DataSources.Add(repDs);

            ReportViewer1.LocalReport.Refresh();

            //if (Request.Browser.Browser == "Chrome")
            //{
            //    Byte[] bytes = ReportViewer1.LocalReport.Render("PDF");
            //    Response.AddHeader("Content-Disposition", "inline; filename=MyReport.pdf");
            //    Response.ContentType = "application/pdf";
            //    Response.BinaryWrite(bytes);
            //    Response.End();
            //}

            //else
            //    ReportViewer1.Visible = true;

        }
        catch (Exception ex)
        {

        }
    }
    public void subReports(object sender, SubreportProcessingEventArgs e)
    {

        try
        {

            DBManager dbMgr = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {

                new SqlParameter("@NAId",ddlNA.SelectedValue)

            };
            DataTable dt = dbMgr.ExecuteDataTable("Report_GetNAStatistics_Voters", parm);

            e.DataSources.Clear();            
            e.DataSources.Add(new ReportDataSource("ReportAllVoters", dt));            
        }
        catch (Exception)
        {

        }


    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        ShowReport();
    }
}  