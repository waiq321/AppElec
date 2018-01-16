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

    public DataTable GetDistrict(string provinceid)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@ProvinceId",provinceid)
        };
        return ObjDBManager.ExecuteDataTable("GetDistrict", parm);
    }

    public DataTable GetNA(string DistrictId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@DistrictId",DistrictId)
        };
        return ObjDBManager.ExecuteDataTable("GetNa", parm);
    }

    public DataTable GetPartyCatdidate(string partyId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@PartyId",partyId)
        };
        return ObjDBManager.ExecuteDataTable("GetPartyCandidate", parm);
    }
    public DataTable GetelectionYear()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetElectionYear", parm);
    }
    
}