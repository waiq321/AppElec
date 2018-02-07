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

public partial class NAInfulense : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    CommonFunctions objCommonFunctions = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetProvince();
            GetDistrict();
            GetNA();
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            FillGridView();
        }
        lblMsg.Text = "";
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
    protected void btn_SaveINF_Click(object sender, EventArgs e)
    {
        Insertinflu();
        FillGridView();
    }

    private void Insertinflu()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("NA_ID",Convert.ToString( Request.QueryString["NA"])),
            new SqlParameter("ElectionId",Convert.ToString( Request.QueryString["EID"])),
            new SqlParameter("Year",Convert.ToString( Request.QueryString["Year"])),
            new SqlParameter("Name", txt_In_Name.Text),
            new SqlParameter("TYPE",txt_Type_inf.Text),
            new SqlParameter("Political_leaning",txt_political_leaning.Text),
            new SqlParameter("Profession",txt_political_leaning.Text),
            
            new SqlParameter("Rel_poli",txt_poli_Relation.Text),
            new SqlParameter("Rel_Beau",txtbureaucratic.Text),
            new SqlParameter("Rel_Mili",txtMilitary.Text),
           

        };
        ObjDBManager.ExecuteNonQuery("InsertNAInfluencial", parm);
    }
    private void InsertSpoiler()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("NA_ID",Convert.ToString( Request.QueryString["NA"])),
            new SqlParameter("ElectionId",Convert.ToString( Request.QueryString["EID"])),
            new SqlParameter("Spoiler",Convert.ToString( Request.QueryString["Year"])),
            new SqlParameter("Factor", txt_In_Name.Text)
        };
        ObjDBManager.ExecuteNonQuery("InsertNASpoiler", parm);
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        FillGridView();
    }
  
    protected void Update_Record(string Result,string id,String type)
    {
        
        SqlConnection con = new SqlConnection(_str);
        con.Open();

        SqlCommand cmd = new SqlCommand("UpdateElectionResult", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Parameters.AddWithValue("@Result", Result);
   
        cmd.ExecuteNonQuery();
        con.Close();
        FillGridView();        
        lblMsg.Text = "Result Saved Successfully!";
        lblMsg.ForeColor = System.Drawing.Color.Green;
    }
 
    private void FillGridView()
    {       
        DBManager ObjDBManager = new DBManager();   
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("Na_ID",ddlNA.SelectedValue),
                new SqlParameter("Year", ddlYear.SelectedValue)

            };
        DataTable dt= ObjDBManager.ExecuteDataTable("NAInfSearch", parm);
        GridViewInf.DataSource = dt;
        GridViewInf.DataBind();
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGridView();
    }



    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (GridViewInf.Rows.Count > 0)
            {
                TextBox result = new TextBox();
              
                CheckBox Ck = new CheckBox();
                foreach (GridViewRow row in GridViewInf.Rows)
                {

                    result = (TextBox)row.FindControl("txt_result");
                  


                }
                lblMsg.Text = "Saved successfully!";
                lblMsg.Attributes.Remove("class");
                lblMsg.Attributes.Add("class", "success");
            }
        }
        catch
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
    }

    private void Update_Record(string Result, string ID, string Pro_ID, string Dis_ID, string PA_ID, string P_ID, string El_ID, string C_ID ,string NA_ID)
    {
        //SqlConnection con = new SqlConnection(_str);
        //con.Open();

        //SqlCommand cmd = new SqlCommand("InsertElectionResult", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@Id", ID);
        //cmd.Parameters.AddWithValue("@Result", Result);
      
        //cmd.Parameters.AddWithValue("@Pro_ID", Pro_ID);
        //cmd.Parameters.AddWithValue("@C_ID", C_ID);
        //cmd.Parameters.AddWithValue("@Dis_ID", Dis_ID);
        //cmd.Parameters.AddWithValue("@NA_ID", NA_ID);
        //cmd.Parameters.AddWithValue("@PA_ID", PA_ID);
        //cmd.Parameters.AddWithValue("@P_ID", P_ID);
        //cmd.Parameters.AddWithValue("@El_ID", El_ID);
    
        //cmd.ExecuteNonQuery();
        //con.Close();
        //FillGridView();
        //lblMsg.Text = "Result Saved Successfully!";
        //lblMsg.ForeColor = System.Drawing.Color.Green;
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
    
    protected void Btn_Save_Spo_Click(object sender, EventArgs e)
    {

    }
}  