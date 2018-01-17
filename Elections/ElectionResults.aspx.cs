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

public partial class Candidates_ElectionResults : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    CommonFunctions objCommonFunctions = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            GetProvince();
            GetDistrict();
            GetNA();
            GetPA();
    
        }
    }
    protected void GetProvince()
    {
    
            ddlProvince.DataSource = objCommonFunctions.GetProvince();

            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceId";
            ddlProvince.DataBind();
    }
    protected void GetDistrict()
    {
        
        ddlDistrict.DataSource = objCommonFunctions.GetDistrict(ddlProvince.SelectedValue);

        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "DistrictId";
        ddlDistrict.DataBind();

    }
    
    protected void GetNA()
    {
        
        ddlNA.DataSource = objCommonFunctions.GetNA(ddlDistrict.SelectedValue);

        ddlNA.DataTextField = "Name";
        ddlNA.DataValueField = "NAId";
        ddlNA.DataBind();
    }
    protected void GetPA()
    {
        
        ddlPA.DataSource = objCommonFunctions.GetPA(ddlNA.SelectedValue);

        ddlPA.DataTextField = "Name";
        ddlPA.DataValueField = "PAId";
        ddlPA.DataBind();
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
        cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
        cmd.ExecuteNonQuery();
        con.Close();
        FillGridView();        
        lblMsg.Text = "Result Saved Successfully!";
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
                new SqlParameter("@ElectionId",ddlNA.SelectedValue),
                new SqlParameter("@NAId",ddlNA.SelectedValue),
                new SqlParameter("@PAId",paId),
                new SqlParameter("@Type",rdoType.SelectedValue)
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_ElectionCandidates", parm);
        GridView1.DataBind();
        if (GridView1.Rows.Count>0)
        {
            Btn_Save.Visible = true;

        }
        else
        {
            Btn_Save.Visible = false;
        }
    }


    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        FillGridView();
    }

    
    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
            trPA.Style.Add(HtmlTextWriterStyle.Display, "none");
    
        }
        else
        {
            GetPA();
            trPA.Style.Add(HtmlTextWriterStyle.Display, "table-row");
    
        }
    }

    //protected void Update_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox Ck = (CheckBox)sender;
    //    GridViewRow row = (GridViewRow)Ck.NamingContainer;
    //    TextBox result = (TextBox)row.FindControl("");
    //    HiddenField ID = (HiddenField)row.FindControl("");
    //    Update_Record()
    //}

    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count>0)
        {
            TextBox result = new TextBox();
            HiddenField ID = new HiddenField();
            CheckBox Ck = new CheckBox();
            int count = 0;
            foreach(GridViewRow row in GridView1.Rows)
            {
                Ck = (CheckBox)row.FindControl("Update");

                if (Ck.Checked)
                {
                    count = count + 1;
                    result = (TextBox)row.FindControl("txt_result");
                    ID = (HiddenField)row.FindControl("hfd_E_ID");
                    Update_Record(result.Text, ID.Value, "");
                }
                if (count>0)
                {
                    lblMsg.Text = "Record Saved ...";
                    lblMsg.Visible = true;
                }
                
            }


        }
    }
}  