using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
}