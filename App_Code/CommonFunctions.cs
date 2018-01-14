using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
/// <summary>
/// Summary description for CommonFunctions
/// </summary>
public class CommonFunctions
{
    public CommonFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public DataTable GetParties()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>{};
        return ObjDBManager.ExecuteDataTable("GetParties", parm);
    }
    public DataTable GetProvince()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetProvince", parm);
    }

    public DataTable GetDistrict()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetDistrict", parm);
    }

    public DataTable GetNA()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetNa", parm);
    }

    public DataTable GetCatdidate()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetElectionCandidate", parm);
    }
    public DataTable GetelectionYear()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetElectionYear", parm);
    }
}