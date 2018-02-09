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

            ShowReport();

        }
    }

    private void ShowReport()
    {
        try
        {
            DBManager dbMgr = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {

                new SqlParameter("@NAId",Request.QueryString["NAID"])

            };
            DataSet ds = dbMgr.ExecuteDataSet("Report_GetNAStatistics", parm);


            ReportViewer1.LocalReport.ReportPath = Server.MapPath("NAStatisticsReport.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource repDs = new ReportDataSource();

            //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("Report_GetNAStatistics", ds.Tables[0]));

            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetFigure", ds.Tables[0]));
            //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", ds.Tables[1]));
            //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", ds.Tables[2]));
            //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetInflueienceFigure", ds.Tables[3]));
            //ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", ds.Tables[4]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetVotesObtained", ds.Tables[5]));

            if (ds.Tables[2].Rows.Count == 0)
            {
                DataTable dt4 = new DataTable();
                dt4.Clear();
                dt4.Columns.Add("SectrainName");
                dt4.Columns.Add("Percentage");
                DataRow _ravi = dt4.NewRow();
                _ravi["SectrainName"] = "";
                _ravi["Percentage"] = "";
                dt4.Rows.Add(_ravi);
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", dt4));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", ds.Tables[2]));
            }

            if (ds.Tables[1].Rows.Count == 0)
            {
                DataTable dt3 = new DataTable();
                dt3.Clear();
                dt3.Columns.Add("CastName");
                dt3.Columns.Add("Percentage");
                DataRow _ravi = dt3.NewRow();
                _ravi["CastName"] = "";
                _ravi["Percentage"] = "";
                dt3.Rows.Add(_ravi);
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", dt3));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", ds.Tables[1]));
            }

            if (ds.Tables[4].Rows.Count==0)
            {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Individulas");
            dt.Columns.Add("Factors");
            DataRow _ravi = dt.NewRow();
            _ravi["Individulas"] = "";
            _ravi["Factors"] = "";
            dt.Rows.Add(_ravi);
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", dt));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", ds.Tables[4]));
            }
            if (ds.Tables[3].Rows.Count == 0)
            {
                DataTable dt1 = new DataTable();
                dt1.Clear();
                dt1.Columns.Add("Name");
                dt1.Columns.Add("TYPE_Inf");
                dt1.Columns.Add("Political_leaning");
                dt1.Columns.Add("Profession");
                dt1.Columns.Add("Rel_poli");
                dt1.Columns.Add("Rel_Beau");
                dt1.Columns.Add("Rel_Mili");
                DataRow _ravi = dt1.NewRow();
                _ravi["Name"] = "";
                _ravi["TYPE_Inf"] = "";
                _ravi["Political_leaning"] = "";
                _ravi["Profession"] = "";
                _ravi["Rel_poli"] = "";
                _ravi["Rel_Beau"] = "";
                _ravi["Rel_Mili"] = "";
                dt1.Rows.Add(_ravi);

               
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetInflueienceFigure", dt1));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetInflueienceFigure", ds.Tables[3]));
            }
             if (ds.Tables[4].Rows.Count==0)
            {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Individulas");
            dt.Columns.Add("Factors");
            DataRow _ravi = dt.NewRow();
            _ravi["Individulas"] = "";
            _ravi["Factors"] = "";
            dt.Rows.Add(_ravi);
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", dt));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", ds.Tables[4]));
            }
            //ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(subReports);

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
    //public void subReports(object sender, SubreportProcessingEventArgs e)
    //{

    //    try
    //    {

    //        DBManager dbMgr = new DBManager();
    //        List<SqlParameter> parm = new List<SqlParameter>
    //        {

    //            new SqlParameter("@NAId",ddlNA.SelectedValue)

    //        };
    //        DataTable dt = dbMgr.ExecuteDataTable("Report_GetNAStatistics_Voters", parm);

    //        e.DataSources.Clear();
    //        e.DataSources.Add(new ReportDataSource("ReportAllVoters", dt));
    //    }
    //    catch (Exception)
    //    {

    //    }


    //}
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        ShowReport();
    }
}