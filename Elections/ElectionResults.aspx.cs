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

public partial class Elections_ElectionResults : System.Web.UI.Page
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
            GetParties();
            GetCandidates();
            
        }

    }
    protected void GetYears()
    {
        CommonFunctions objCommonFunctionsElectionYear = new CommonFunctions();
        ddlElectionYear.DataSource = objCommonFunctionsElectionYear.GetelectionYear();

        ddlElectionYear.DataTextField = "ElectionYear";
        ddlElectionYear.DataValueField = "Electionid";
        ddlElectionYear.DataBind();

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
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
    }
    protected void ddlCandidate_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates();
    }
    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetParties();
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionCandidates", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Electionid", ddlElectionYear.SelectedValue);
            cmd.Parameters.AddWithValue("@Provinceid", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@Districtid", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@PAid", ddlParty.SelectedValue);
            //cmd.Parameters.AddWithValue("@Candidateid", ddlCandidate.SelectedValue);
            //cmd.Parameters.AddWithValue("@CandidateType", txtCandidateType.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            LblMeg.Text = "Save Successfully";
            //FillGridView();
            //txtCandidateType.Text = "";
        }
        catch (Exception ex)
        {

        }

    }


}