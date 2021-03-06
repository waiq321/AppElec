﻿using System;
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

            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetFigure", ds.Tables[0]));

            if (ds.Tables[1].Rows.Count == 0)
            {
                DataTable dtCast = new DataTable();
                dtCast.Clear();
                dtCast.Columns.Add("CastName");
                dtCast.Columns.Add("Percentage");
                DataRow _ravi = dtCast.NewRow();
                _ravi["CastName"] = "";
                _ravi["Percentage"] = "";
                dtCast.Rows.Add(_ravi);
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", dtCast));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", ds.Tables[1]));
            }

            if (ds.Tables[2].Rows.Count == 0)
            {
                DataTable dtSectarian = new DataTable();
                dtSectarian.Clear();
                dtSectarian.Columns.Add("SectrainName");
                dtSectarian.Columns.Add("Percentage");
                DataRow _ravi = dtSectarian.NewRow();
                _ravi["SectrainName"] = "";
                _ravi["Percentage"] = "";
                dtSectarian.Rows.Add(_ravi);
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", dtSectarian));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", ds.Tables[2]));
            }

            if (ds.Tables[3].Rows.Count == 0)
            {
                DataTable dtInf = new DataTable();
                dtInf.Clear();
                dtInf.Columns.Add("Name");
                dtInf.Columns.Add("TYPE_Inf");
                dtInf.Columns.Add("Political_leaning");
                dtInf.Columns.Add("Profession");
                dtInf.Columns.Add("Rel_poli");
                dtInf.Columns.Add("Rel_Beau");
                dtInf.Columns.Add("Rel_Mili");
                DataRow _ravi = dtInf.NewRow();
                _ravi["Name"] = "";
                _ravi["TYPE_Inf"] = "";
                _ravi["Political_leaning"] = "";
                _ravi["Profession"] = "";
                _ravi["Rel_poli"] = "";
                _ravi["Rel_Beau"] = "";
                _ravi["Rel_Mili"] = "";
                dtInf.Rows.Add(_ravi);


                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetInflueienceFigure", dtInf));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetInflueienceFigure", ds.Tables[3]));
            }

            if (ds.Tables[4].Rows.Count==0)
            {
            DataTable dtSpoilers = new DataTable();
                dtSpoilers.Clear();
                dtSpoilers.Columns.Add("Individulas");
                dtSpoilers.Columns.Add("Factors");
            DataRow _ravi = dtSpoilers.NewRow();
            _ravi["Individulas"] = "";
            _ravi["Factors"] = "";
                dtSpoilers.Rows.Add(_ravi);
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", dtSpoilers));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSpoilers", ds.Tables[4]));
            }
            
             
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetVotesObtained", ds.Tables[5]));
            
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