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

public partial class Election_ElectionRecommendation : System.Web.UI.Page
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
            GetParties();
            GetCandidates("P1"); GetCandidates("P2");
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            FillGridView();
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
    protected void GetParties()
    {
        CommonFunctions objCommonFunctionsGetParties = new CommonFunctions();
        DataTable dt= objCommonFunctionsGetParties.GetParties();
        ddlLWParty.DataSource = dt;

        ddlLWParty.DataTextField = "PartyName";
        ddlLWParty.DataValueField = "PartyId";
        ddlLWParty.DataBind();

        ddlOLWParty.DataSource = dt;

        ddlOLWParty.DataTextField = "PartyName";
        ddlOLWParty.DataValueField = "PartyId";
        ddlOLWParty.DataBind();


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
            SqlCommand cmd = new SqlCommand("InsertNAPARecommendation", con);

            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@Provinceid", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@Districtid", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@CandidateType", rdoType.SelectedValue);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@PAid", paId);



            cmd.Parameters.AddWithValue("@FWParty", ddlLWParty.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@FirstWiningCandidate", ddlCandidate1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@FirstFactors", txtLWFactor.Text);
            

            cmd.Parameters.AddWithValue("@SWParty", ddlOLWParty.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@SecondWiningCandidate", ddlCandidate2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@SecondFactors", txtOLWFactor.Text);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());

            

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

        SqlCommand cmd = new SqlCommand("usp_deleteLBElectionRecommandation", con);
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
                
                new SqlParameter("@NAId",ddlNA.SelectedValue),
                new SqlParameter("@PAId",paId),
                new SqlParameter("@Type",rdoType.SelectedValue)
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_LBElectionRecommandation", parm);
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
        GetPA();
        FillGridView();
    }

    protected void ddlLWParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates("P1");
    }
    protected void ddlOLWParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates("P2");
    }

    protected void GetCandidates(string type)
    {
        CommonFunctions objCommonFunctionsGetCandidate = new CommonFunctions();

        if (type == "P1")
        {
            ddlCandidate1.DataSource = objCommonFunctionsGetCandidate.GetPartyCatdidate(ddlLWParty.SelectedValue);

            ddlCandidate1.DataTextField = "Name";
            ddlCandidate1.DataValueField = "candidateid";
            ddlCandidate1.DataBind();
        }
        else
        {
            ddlCandidate2.DataSource = objCommonFunctionsGetCandidate.GetPartyCatdidate(ddlOLWParty.SelectedValue);

            ddlCandidate2.DataTextField = "Name";
            ddlCandidate2.DataValueField = "candidateid";
            ddlCandidate2.DataBind();
        }


    }
    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
            FillGridView();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "none");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            GetPA();
            FillGridView();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "contents");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "contents");
        }
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
        FillGridView();
    }
}  