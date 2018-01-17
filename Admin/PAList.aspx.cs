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

public partial class Admin_PAList : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            GetProvince();
            GetDistrict();
            bindGrd();
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
    protected void bindGrd()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",ddlNA.SelectedValue)                
            };
            GridView1.DataSource = ObjDBManager.ExecuteDataTable("SearchPARecord", parm);
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

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
    }

    protected void GetNA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlNA.DataSource = objCommonFunctionsGetNA.GetNA(ddlDistrict.SelectedValue);

        ddlNA.DataTextField = "Name";
        ddlNA.DataValueField = "NAId";
        ddlNA.DataBind();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
    }
}