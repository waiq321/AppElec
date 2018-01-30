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

public partial class Election_GeneralElectionAssesment : System.Web.UI.Page
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
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_GeneralElectionAssesment", parm);
        GridView1.DataBind();
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        FillGridView();
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