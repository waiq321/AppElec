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
        if (!Page.IsPostBack)
        {
            CommonFunctions objCommonFunctions = new CommonFunctions();
            ddlParty.DataSource = objCommonFunctions.GetParties();

            ddlParty.DataTextField = "PartyName";
            ddlParty.DataValueField = "Partyid";
            ddlParty.DataBind();


            string candId = Request.QueryString["CandId"];
            if (!string.IsNullOrEmpty(candId))
            {
                GetCandidateInfo(candId);
            }
        }
    }
    protected void GetCandidateInfo(string candId)
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandidateId",candId)                
            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetCandidateInfo", parm);            
            if(dt.Rows.Count>0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtNic.Text = dt.Rows[0]["NIC"].ToString();
                ddlParty.SelectedValue = dt.Rows[0]["PartyId"].ToString();
                txtEdu.Text = dt.Rows[0]["Education"].ToString();
                txtRWM.Text = dt.Rows[0]["RelationWithMilitary"].ToString();
                txtRWB.Text = dt.Rows[0]["RelationWithBureaucracy"].ToString();
                txtRWJ.Text = dt.Rows[0]["RelationWithJudiciary"].ToString();
                txtRWP.Text = dt.Rows[0]["RelationWithPolitics"].ToString();
                txtMC.Text = dt.Rows[0]["MoralCharacteristics"].ToString();
                txtFC.Text = dt.Rows[0]["FinancialCharacteristics"].ToString();
                txtVAE.Text = dt.Rows[0]["ViewsAboutEstablishment"].ToString();
                txtImpApp.Text = dt.Rows[0]["ImpotantAppoinments"].ToString();
                txtScandles.Text = dt.Rows[0]["InvolvedScandals"].ToString();
                txtPresentAdd.Text = dt.Rows[0]["PresentAddress"].ToString();
                txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                txtObservations.Text = dt.Rows[0]["OtherObservations"].ToString();
                
                hdnCandidateId.Value= candId;
            }
        }
        catch
        {
            ;      
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        byte b = new byte();
        try
        {

            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@CandidateId",hdnCandidateId.Value),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@NIC",txtNic.Text),
            new SqlParameter("@Education",txtEdu.Text),
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
            new SqlParameter("@Picture",b),
            new SqlParameter("@CreatedBy",Session["UserId"]),
            new SqlParameter("@CreatedDate",DateTime.Now)

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