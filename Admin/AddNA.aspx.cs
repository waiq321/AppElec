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

public partial class Admin_AddNA : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
        GetProvince();
        GetDistrict();
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
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionNA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", txtNAName.Text.Trim());
            cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
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
        using (SqlConnection connection = new SqlConnection(_str))
        {
            SqlCommand command = new SqlCommand("Select_NA", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
            SqlCommand cmd = new SqlCommand("select * from NA where NAId=" + lnkBTN.CommandName + "", con);
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    txtNAName.Text = rdr["Name"].ToString();
                    ddlProvince.SelectedItem.Value = rdr["ProvinceId"].ToString();
                    ddlDistrict.SelectedItem.Value = rdr["DistrictId"].ToString();
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

        SqlCommand cmd = new SqlCommand("usp_deleteNARecord", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@NAid", btn.CommandName);
        cmd.ExecuteNonQuery();
        FillGridView();
        con.Close();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_UpdateNA", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Name", txtNAName.Text.Trim());
        cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
        cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
        cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedIndex);
        cmd.Parameters.AddWithValue("@Latitude", txtLatitude.Text);

        cmd.Parameters.AddWithValue("@Longitude", txtLongitude.Text);
        cmd.Parameters.AddWithValue("@FamousPlace", txtFamousPlace.Text);
        cmd.Parameters.AddWithValue("@CreatedDate", txtCreatedDate.Text);

        cmd.Parameters.AddWithValue("@NAId", hdID.Value);


        cmd.ExecuteNonQuery();
        btn_save.Visible = true;
        btnUpdate.Visible = false;
        FillGridView();
        ClearField();
        con.Close();

    }
    void ClearField()
    {

        txtNAName.Text = string.Empty;
        txtLatitude.Text = string.Empty;
        txtLongitude.Text = string.Empty;
        txtFamousPlace.Text = string.Empty;
        
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
    }
}