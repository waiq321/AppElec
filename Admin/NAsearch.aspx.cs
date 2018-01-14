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

public partial class Admin_NAsearch : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!Page.IsPostBack)
        {

        
        //-----------------------------------------
        //GetProvince
        //-----------------------------------------

        CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
        ddlProvince.DataSource = objCommonFunctionsProvince.GetProvince();

        ddlProvince.DataTextField = "ProvinceName";
        ddlProvince.DataValueField = "ProvinceId";
        ddlProvince.DataBind();


        //-----------------------------------------
        //GetDistrict
        //-----------------------------------------

        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlDistrict.DataSource = objCommonFunctionsGetDistrict.GetDistrict();

        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "DistrictId";
        ddlDistrict.DataBind();
        }


        bindGrd();

    }
    protected void bindGrd()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@Provinceid",ddlProvince.SelectedValue),
                new SqlParameter("@Districtid",ddlDistrict.SelectedValue)
            };
            GridView1.DataSource = ObjDBManager.ExecuteDataTable("SearchNaRecord", parm);
            GridView1.DataBind();
        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
            throw;
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bindGrd();

    }
}