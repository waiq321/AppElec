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

public partial class Figures_AddFigureCastSectrain : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetProvince();
            GetDistrict();
            GetPA();
            GetCast();
            GetSectain();
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
    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
    }
    protected void GetCast()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlCast.DataSource = objCommonFunctionsGetDistrict.GetCast();

        ddlCast.DataTextField = "CastName";
        ddlCast.DataValueField = "Castid";
        ddlCast.DataBind();
    }
    protected void GetSectain()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlSectrain.DataSource = objCommonFunctionsGetDistrict.GetSectrain();

        ddlSectrain.DataTextField = "sectrainName";
        ddlSectrain.DataValueField = "sectrainID";
        ddlSectrain.DataBind();
    }

    
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        GetPA();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetPA();
    }
    protected void btnSaveVoters_Click(object sender, EventArgs e)
    {
         SqlConnection con = new SqlConnection(_str);
        try
        {            
            con.Open();
            SqlCommand cmd = new SqlCommand("uspAddFigures", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", hdnFigureId.Value);
            cmd.Parameters.AddWithValue("@PAId",ddlPA.SelectedValue);
            cmd.Parameters.AddWithValue("@NAId", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@ElectionId", ddlYear.SelectedValue);

            cmd.Parameters.AddWithValue("@Tehsil", txtboxTehcile.Text);
            cmd.Parameters.AddWithValue("@UCS", txtboxUcs.Text);
            cmd.Parameters.AddWithValue("@mcs", txtboxMCS.Text);

            cmd.Parameters.AddWithValue("@UcsRemarks", txtboxUcsRemarks.Text);
            cmd.Parameters.AddWithValue("@McsRemarks", txtboxMcsRemarks.Text);
            cmd.Parameters.AddWithValue("@TehcileRemarks", txtboxTehcileRemarks.Text);

            cmd.Parameters.AddWithValue("@PSMale", txtMalePStation.Text);
            cmd.Parameters.AddWithValue("@PSFemale", txtFeMalePStation.Text);

            cmd.Parameters.AddWithValue("@MaleVoters", txtMaleVoters.Text);
            cmd.Parameters.AddWithValue("@FemaleVoters", txtFemaleVoters.Text);


            cmd.Parameters.AddWithValue("@CreatedBy", Session["UserId"]);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                                                		    
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            //FillGridView();            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
       
    }
    protected void btnSaveCast_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        try
        {            
            con.Open();
            SqlCommand cmd = new SqlCommand("uspAddCast", con);
            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@PAId",ddlPA.SelectedValue);
            cmd.Parameters.AddWithValue("@NAId", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@CastId", ddlCast.SelectedValue);
            cmd.Parameters.AddWithValue("@Percentage", txtboxCastPercentage.Text);
            cmd.Parameters.AddWithValue("@ElectionId", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@CreatedBy", Session["UserId"]);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
           
            
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            getCasts();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }        			 
    }
    protected void btnSaveSectrain_Click(object sender, EventArgs e)
    {
        

             SqlConnection con = new SqlConnection(_str);
        try
        {            
            con.Open();
            SqlCommand cmd = new SqlCommand("upsAddSectrain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SectrainID", ddlSectrain.SelectedValue);
            cmd.Parameters.AddWithValue("@PAID", ddlPA.SelectedValue);
            cmd.Parameters.AddWithValue("@NAID", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@Percentage", txtboxSectainPercentage.Text);
            cmd.Parameters.AddWithValue("@ElectionID", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@Createdby", Session["UserId"]);
            cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
           
            
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            getSectarian();         
        }
        catch (Exception ex)
        {
            con.Close();
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }      
    }

    private void getFigures()
    {
        
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),                
                new SqlParameter("@PAId",ddlPA.SelectedValue)                
            };
        DataTable dt= ObjDBManager.ExecuteDataTable("GetPAFigures", parm);
        if(dt.Rows.Count>0)
        {
            txtboxTehcile.Text = dt.Rows[0]["Tehsil"].ToString();
            txtboxTehcileRemarks.Text = dt.Rows[0]["TehcileRemarks"].ToString();
            txtboxUcs.Text = dt.Rows[0]["UCS"].ToString();
            txtboxUcsRemarks.Text = dt.Rows[0]["UcsRemarks"].ToString();
            txtboxMCS.Text = dt.Rows[0]["Mcs"].ToString();
            txtboxMcsRemarks.Text = dt.Rows[0]["McsRemarks"].ToString();
            txtMalePStation.Text = dt.Rows[0]["PSMale"].ToString();
            txtFeMalePStation.Text = dt.Rows[0]["PSFemale"].ToString();
            txtMaleVoters.Text = dt.Rows[0]["VotersMale"].ToString();
            txtFemaleVoters.Text = dt.Rows[0]["VotersFemale"].ToString();
            hdnFigureId.Value = dt.Rows[0]["Id"].ToString();
        }
        else
        {
            txtboxTehcile.Text = "";
            txtboxTehcileRemarks.Text = "";
            txtboxUcs.Text = "";
            txtboxUcsRemarks.Text = "";
            txtboxMCS.Text = "";
            txtboxMcsRemarks.Text = "";
            txtMalePStation.Text = "";
            txtFeMalePStation.Text = "";
            txtMaleVoters.Text = "";
            txtFemaleVoters.Text = "";
            hdnFigureId.Value = "0";
        }
    }

    private void getCasts()
    {

        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),
                new SqlParameter("@PAId",ddlPA.SelectedValue)
            };
        grdCasts.DataSource= ObjDBManager.ExecuteDataTable("GetPACasts", parm);
        grdCasts.DataBind();

    }
    private void getSectarian()
    {

        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),
                new SqlParameter("@PAId",ddlPA.SelectedValue)
            };
        grdSectarian.DataSource = ObjDBManager.ExecuteDataTable("GetPASectarian", parm);
        grdSectarian.DataBind();

    }
    private void ClearForms() { 
    
    }


    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                HiddenField hdnPAId = (HiddenField)row.FindControl("hdnPAId");
                HiddenField hdnSectrainID = (HiddenField)row.FindControl("hdnSectrainID");
                HiddenField hdnElectionId = (HiddenField)row.FindControl("hdnElectionId");
                DBManager ObjDBManager = new DBManager();
                List<SqlParameter> parm = new List<SqlParameter>
                {
                    new SqlParameter("@PAId",hdnPAId.Value),
                    new SqlParameter("@SectrainID",hdnSectrainID.Value),
                    new SqlParameter("@ElectionId",hdnElectionId.Value)
                };
                ObjDBManager.ExecuteNonQuery("DeletePASectarian", parm);
                getSectarian();
            }
        }
        catch
        {
            ;
        }
    }
    protected void lnkdeleteCasts_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                HiddenField hdnPAId = (HiddenField)row.FindControl("hdnPAId");
                HiddenField hdnCastId = (HiddenField)row.FindControl("hdnCastId");
                HiddenField hdnElectionId = (HiddenField)row.FindControl("hdnElectionId");
                DBManager ObjDBManager = new DBManager();
                List<SqlParameter> parm = new List<SqlParameter>
                {
                    new SqlParameter("@PAId",hdnPAId.Value),
                    new SqlParameter("@castid",hdnCastId.Value),
                    new SqlParameter("@ElectionId",hdnElectionId.Value)
                };
                ObjDBManager.ExecuteNonQuery("DeletePACasts", parm);
                getCasts();
            }
        }
        catch
        {
            ;
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        getFigures();
        getCasts();
        getSectarian();
    }
}  