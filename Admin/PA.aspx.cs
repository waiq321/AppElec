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

public partial class Admin_PA : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetProvince();
            GetDistrict();
            GetNA();
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
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        FillGridView();
    }

 
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionPA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PAId", hdID.Value);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@Name", txtNAName.Text.Trim());
            cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text.Trim());
            cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text.Trim());
            cmd.Parameters.AddWithValue("@FamousPlace", txtFamousPlace.Text.Trim());
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            
            cmd.ExecuteNonQuery();
            con.Close();
            FillGridView();

            LblMeg.Text = "Save Successfully";
            //FillGridView();
            txtNAName.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtFamousPlace.Text = "";
            


        }


        catch (Exception ex)
        {


        }
        finally
        {
            con.Close();
        }
    }
    private void FillGridView()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",ddlNA.SelectedValue),                
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_PA", parm);
        GridView1.DataBind();
       
    }
    protected void lnkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnkBTN = sender as LinkButton;
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();                        
            SqlCommand cmd = new SqlCommand("select * from PA where PaId=" + lnkBTN.CommandName + "", con);
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                  while (rdr.Read())
                {
                    ddlNA.SelectedItem.Value = rdr["NAid"].ToString();
                    txtNAName.Text = rdr["Name"].ToString();
                    ddlProvince.SelectedValue= rdr["ProvinceId"].ToString();
                    ddlDistrict.SelectedValue = rdr["DistrictId"].ToString();
                    ddlCategory.SelectedItem.Value = rdr["Category"].ToString();
                    txtLatitude.Text = rdr["Latitude"].ToString();
                    txtLongitude.Text = rdr["Longitude"].ToString();
                    txtFamousPlace.Text = rdr["FamousPlace"].ToString();
                    txtCreatedDate.Text = rdr["CreatedDate"].ToString();


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

        SqlCommand cmd = new SqlCommand("usp_deletePARecord", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAid", btn.CommandName);
        cmd.ExecuteNonQuery();
        FillGridView();
        con.Close();
    }
  
    void ClearField()
    {

        txtNAName.Text = string.Empty;
        txtLatitude.Text = string.Empty;
        txtLongitude.Text = string.Empty;
        txtFamousPlace.Text = string.Empty;
        
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGridView();
    }

    protected void ddlDistrict_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GetNA();
        FillGridView();
    }
}