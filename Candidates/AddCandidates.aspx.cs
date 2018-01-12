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
        byte b = new byte();
        try
        {

            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@CandidateId",""),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@NIC",txtNic.Text),
            new SqlParameter("@Education",txtEducation.Text),
            new SqlParameter("@PresentAddress",txtPresentAdd.Text),
            new SqlParameter("@PermanentAddress",txtPermanentAddress.Text),
            new SqlParameter("@PartyId",ddlParty.SelectedValue),
            new SqlParameter("@RelationWithJudiciary",txtRWJ.Text),
            new SqlParameter("@RelationWithMilitary",txtRWM.Text),
            new SqlParameter("@RelationWithPolitics",txtRWP.Text),
            new SqlParameter("@RelationWithBureaucracy",txtRWB.Text),
            new SqlParameter("@ImpotantAppoinments",txtImpApp.Text),
            new SqlParameter("@InvolvedScandals",txtScandles.Text),
            new SqlParameter("@ViewsAboutEstablishment",txtVAE.Text),
            new SqlParameter("@MoralCharacteristics",txtMC.Text),
            new SqlParameter("@FinancialCharacteristics",txtFC.Text),
            new SqlParameter("@OtherObservations",txtObservations.Text),
            new SqlParameter("@Picture",b)
        };
            ObjDBManager.ExecuteNonQuery("AddCandidate", parm);
            lblMsg.Text = "Saved successfully!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "success");
        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
            throw;
        }
    }
}