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

public partial class Candidates_ElectionCandidates : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            GetProvince();
            GetDistrict();
            GetNA();
            GetPA();
            GetParties();
            GetCandidates();
            FillGridView();
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
    protected void GetPA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlPA.DataSource = objCommonFunctionsGetNA.GetPA(ddlNA.SelectedValue);

        ddlPA.DataTextField = "Name";
        ddlPA.DataValueField = "PAId";
        ddlPA.DataBind();
    }
    protected void GetParties()
    {
        CommonFunctions objCommonFunctionsGetParties = new CommonFunctions();
        ddlParty.DataSource = objCommonFunctionsGetParties.GetParties();

        ddlParty.DataTextField = "PartyName";
        ddlParty.DataValueField = "PartyId";
        ddlParty.DataBind();

    }
    protected void GetCandidates()
    {
        CommonFunctions objCommonFunctionsGetCandidate = new CommonFunctions();
        ddlCandidate.DataSource = objCommonFunctionsGetCandidate.GetPartyCatdidate(ddlParty.SelectedValue);

        ddlCandidate.DataTextField = "Name";
        ddlCandidate.DataValueField = "candidateid";
        ddlCandidate.DataBind();

    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            string paId = "0";
            if(!string.IsNullOrEmpty(ddlPA.SelectedValue))
            {
                paId = ddlPA.SelectedValue;
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionCandidates", con);

            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@Electionid", Request.QueryString["ElecnId"]);
            cmd.Parameters.AddWithValue("@Provinceid", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@Districtid", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@PartyId", ddlParty.SelectedValue);
            cmd.Parameters.AddWithValue("@NAId", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@PAId", paId);
            cmd.Parameters.AddWithValue("@CandidateId", ddlCandidate.SelectedValue);
            cmd.Parameters.AddWithValue("@CandidateType", rdoType.SelectedValue);

            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            FillGridView();
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
       
    }
  
    protected void deleteRecord(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        SqlConnection con = new SqlConnection(_str);
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_deleteElectionCandidates", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", btn.CommandArgument);
        cmd.Parameters.AddWithValue("@Type", btn.CommandName);
        cmd.ExecuteNonQuery();
        con.Close();
        FillGridView();        
        lblMsg.Text = "Deleted Successfully!";
        lblMsg.ForeColor = System.Drawing.Color.Green;
    }
 
    private void FillGridView()
    {
        string paId = "0";
        if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
        {
            paId = ddlPA.SelectedValue;
        }
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",Request.QueryString["ElecnId"].ToString()),
                new SqlParameter("@NAId",ddlNA.SelectedValue),
                new SqlParameter("@PAId",paId),
                new SqlParameter("@Type",rdoType.SelectedValue)
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_ElectionCandidates", parm);
        GridView1.DataBind();
    }


    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        FillGridView();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        FillGridView();
    }

    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates();
    }

    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
          //  trPA.Style.Add(HtmlTextWriterStyle.Display, "none");
            FillGridView();
        }
        else
        {
            GetPA();
           // trPA.Style.Add(HtmlTextWriterStyle.Display, "table-row");
            FillGridView();
        }
    }
}  