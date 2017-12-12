using CaterCommon;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
    public class ManagerInfoDal
    {
        //GetList
        public List<ManagerInfo> GetList()
        {
            string sql = "select * from ManagerInfo";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<ManagerInfo> list = new List<ManagerInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    Mid = Convert.ToInt32(row["Mid"]),
                    MName = (row["MName"]).ToString(),
                    MPwd = (row["MPwd"]).ToString(),
                    MType = Convert.ToInt32(row["MType"]),
                });
            }
            return list;
        }
        //Insert
        public int Insert(ManagerInfo mi)
        {
            string sql = "insert into ManagerInfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@name", mi.MName),
                new SQLiteParameter("@pwd",mi.MPwd),
                new SQLiteParameter("@type", mi.MType)
            };
            return SqliteHelper.ExecuteNonQuery(sql,ps);
        }
        //Update
        public int Update(ManagerInfo mi)
        {
            List<SQLiteParameter> listPs = new List<SQLiteParameter>();
            string sql = "update ManagerInfo set mname=@name";
            listPs.Add(new SQLiteParameter("@name", mi.MName));
            if (!mi.MPwd.Equals("这是原来的密码"))
            {
                sql += ",mpwd=@pwd";
                listPs.Add(new SQLiteParameter("pwd", Md5Helper.EncryptString(mi.MPwd)));
            }
            sql += ",mtype=@type where mid = @id";
            listPs.Add(new SQLiteParameter("@type", mi.MType));
            listPs.Add(new SQLiteParameter("@id", mi.Mid));

            return SqliteHelper.ExecuteNonQuery(sql, listPs.ToArray());
        }
        //Delete
        public int Delete(int id)
        {
            string sql = "delete from ManagerInfo where mid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        //Get managerInfo by name
        public ManagerInfo GetByName(string name)
        {
            ManagerInfo mi = null;
            string sql = "select * from managerInfo where mname=@name";
            SQLiteParameter p = new SQLiteParameter("@name", name);
            DataTable dt = SqliteHelper.GetDataTable(sql, p);
            if (dt.Rows.Count > 0)
            {
                mi = new ManagerInfo()
                {
                    Mid = Convert.ToInt32(dt.Rows[0][0]),
                    MName = name,
                    MPwd = dt.Rows[0][2].ToString(),
                    MType = Convert.ToInt32(dt.Rows[0][3])
                };
            }
            else
            {

            }
            return mi;
        }
    }
}
