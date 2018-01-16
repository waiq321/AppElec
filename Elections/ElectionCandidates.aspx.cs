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

public partial class Candidates_ElectionCandidates : System.Web.UI.Page
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
    protected void GetYears()
    {
        CommonFunctions objCommonFunctionsElectionYear = new CommonFunctions();
        ddlElectionYear.DataSource = objCommonFunctionsElectionYear.GetelectionYear();

        ddlElectionYear.DataTextField = "ElectionYear";
        ddlElectionYear.DataValueField = "Electionid";
        ddlElectionYear.DataBind();

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
            cmd.Parameters.AddWithValue("@Candidateid", ddlCandidate.SelectedValue);
            cmd.Parameters.AddWithValue("@CandidateType", txtCandidateType.Text.Trim());
            
            cmd.ExecuteNonQuery();
            con.Close();
            LblMeg.Text = "Save Successfully";
            FillGridView();
            txtCandidateType.Text = "";
        }
        catch (Exception ex)
        {

        }
       
    }
    protected void lnkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnkBTN = sender as LinkButton;
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();
            btn_save.Visible = false;
            btnUpdate.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from ElectionCandidates where Id=" + lnkBTN.CommandName + "", con);
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    ddlElectionYear.SelectedItem.Value = rdr["Electionid"].ToString();
                    ddlProvince.SelectedItem.Value = rdr["Provinceid"].ToString();
                    ddlDistrict.SelectedItem.Value = rdr["Districtid"].ToString();
                    ddlParty.SelectedItem.Value = rdr["PAid"].ToString();
                    ddlCandidate.SelectedItem.Value = rdr["Candidateid"].ToString();
                    txtCandidateType.Text = rdr["CandidateType"].ToString();

                    hdID.Value = lnkBTN.CommandName;
                }
            }

        }
        catch (Exception ex)
        {


        }

    }
    protected void deleteRecord(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        SqlConnection con = new SqlConnection(_str);
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_deleteElectionCandidates", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", btn.CommandName);
        cmd.ExecuteNonQuery();
        FillGridView();
        con.Close();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_UpdateElectionCandidates", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Electionid", ddlElectionYear.SelectedValue);
        cmd.Parameters.AddWithValue("@Provinceid", ddlProvince.SelectedValue);
        cmd.Parameters.AddWithValue("@Districtid", ddlDistrict.SelectedValue);
        cmd.Parameters.AddWithValue("@PAid", ddlParty.SelectedValue);
        cmd.Parameters.AddWithValue("@Candidateid", ddlCandidate.SelectedValue);
        cmd.Parameters.AddWithValue("@CandidateType", txtCandidateType.Text.Trim());


        cmd.Parameters.AddWithValue("@Id", hdID.Value);


        cmd.ExecuteNonQuery();
        btn_save.Visible = true;
        btnUpdate.Visible = false;
        FillGridView();

        con.Close();
    }
    private void FillGridView()
    {
        using (SqlConnection connection = new SqlConnection(_str))
        {
            SqlCommand command = new SqlCommand("Select_ElectionCandidates", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }


    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
    }

    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates();
    }
}  