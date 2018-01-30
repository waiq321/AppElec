using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Elections_ElectionsSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblId.Text = Request.QueryString["Title"];
            DBManager ObjDBManager = new DBManager();
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Request.QueryString["Id"]),
                new SqlParameter("@PAId",Request.QueryString["Id"]),
                new SqlParameter("@Type",Request.QueryString["Type"])
            };
                DataTable dt = ObjDBManager.ExecuteDataTable("GetLastFiveElectionResults", parm);
                grdWinningCandidates.DataSource = dt;
                grdWinningCandidates.DataBind();
            }
            catch
            {
            }
        }
    }
    protected void grdWinningCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Image Winner1Picture = (Image)e.Row.FindControl("Winner1Pic");
        //    DataRowView rowView = (DataRowView)e.Row.DataItem;
        //    byte[] b = (byte[])rowView["Winner1Picture"];
        //    string base64 = Convert.ToBase64String(b);
        //    Winner1Picture  .ImageUrl = "data:Image/png;base64," + base64;
        //}
    }
    
}
        