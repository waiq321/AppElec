using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Candidates_AddCandidates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions objCommonFunctions = new CommonFunctions();
        ddlParty.DataSource = objCommonFunctions.GetParties();
        
        ddlParty.DataTextField = "PartyName";
        ddlParty.DataValueField = "Partyid";
        ddlParty.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
        {
            new SqlParameter("","")
        };
    }
}