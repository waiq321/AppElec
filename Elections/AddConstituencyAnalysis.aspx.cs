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

public partial class Election_AddConstituencyAnalysis : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetProvince();
            GetDistrict();
            GetNA();
            GetPA();
            
           
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            
        }
    }
    protected void GetYears()
    {
        CommonFunctions objCommonFunctions = new CommonFunctions();
        ddlYear.DataSource = objCommonFunctions.GetelectionYear();

        ddlYear.DataTextField = "electionyear";
        ddlYear.DataValueField = "electionid";
        ddlYear.DataBind();
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
    
    protected void GetPA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlPA.DataSource = objCommonFunctionsGetNA.GetPA(ddlNA.SelectedValue);

        ddlPA.DataTextField = "Name";
        ddlPA.DataValueField = "PAId";
        ddlPA.DataBind();
    }
    
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            string paId = "0";
            if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
            {
                paId = ddlPA.SelectedValue;
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertConstituencyAnalysis", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@PAid", paId);
            cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@Analysis", txtConstituencyAnalysis.Text.Trim());
            cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            txtConstituencyAnalysis.Text = "";




        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }
    

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
       
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetPA();
        
    }
    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
            
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "none");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            GetPA();
            
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "contents");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "contents");
        }
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
        
    }
}  