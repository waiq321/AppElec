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


public partial class Admin_Parties : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillGridView();
        }

    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionParties", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyName", txtPartyName.Text.Trim());
            cmd.Parameters.AddWithValue("@Chairmain", TxtChairman.Text.Trim());
            cmd.Parameters.AddWithValue("@RegistrationDate", txtRegistrationDate.Text.Trim());
            cmd.Parameters.AddWithValue("@PartyNo", txtRegNo.Text.Trim());
            cmd.Parameters.AddWithValue("@PartyOff", Partyoff.Text.Trim());

            if (picUpload.HasFile)
            {
                cmd.Parameters.AddWithValue("@file", picUpload.FileBytes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@file", DBNull.Value);
            }

            
            cmd.ExecuteNonQuery();
            con.Close();

            LblMeg.Text = "Save Successfully";
            FillGridView();
            txtPartyName.Text = "";
            TxtChairman.Text = "";
            txtRegistrationDate.Text = "";
            txtRegNo.Text = "";
            Partyoff.Text = "";
            

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
            SqlCommand command = new SqlCommand("Select_Parties", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}