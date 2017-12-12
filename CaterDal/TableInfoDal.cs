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
    public partial class TableInfoDal
    {
        public List<TableInfo> GetList(Dictionary<string, string> dic)
        {
            string sql = "select ti.*,hi.hTitle from tableinfo as ti " +
                         "inner join hallinfo as hi " +
                         "on ti.tHallId=hi.hid " +
                         "where ti.tisDelete=0 and hi.hIsDelete=0";


            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sql += " and " + pair.Key + "=@" + pair.Key;
                    listP.Add(new SQLiteParameter("@" + pair.Key, pair.Value));
                }
            }

            DataTable dt = SqliteHelper.GetDataTable(sql, listP.ToArray());

            List<TableInfo> list = new List<TableInfo>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TableInfo()
                {
                    TId = Convert.ToInt32(row["tid"]),
                    TTitle = row["ttitle"].ToString(),
                    HallTitle = row["htitle"].ToString(),
                    THallId = Convert.ToInt32(row["thallId"]),
                    TIsFree = Convert.ToBoolean(row["tisFree"])
                });
            }

            return list;
        }

        public int Insert(TableInfo ti)
        {
            string sql = "insert into tableinfo(ttitle,thallid,tisFree,tisDelete) values(@title,@hid,@isfree,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title", ti.TTitle),
                new SQLiteParameter("@hid", ti.THallId),
                new SQLiteParameter("@isfree", ti.TIsFree)
            };

            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update(TableInfo ti)
        {
            string sql = "update tableinfo set ttitle=@title,thallid=@hid,tisfree=@isfree where tid=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title", ti.TTitle),
                new SQLiteParameter("@hid", ti.THallId),
                new SQLiteParameter("@isfree", ti.TIsFree),
                new SQLiteParameter("@id", ti.TId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            string sql = "update tableinfo set tisDelete=1 where tid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);

            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        //public int SetState(int tableId, bool isFree)
        //{
        //    string sql = "update tableinfo set tIsFree=@isfree where tid=@tid";
        //    SQLiteParameter[] ps =
        //    {
        //        new SQLiteParameter("@tid", tableId),
        //        new SQLiteParameter("@isfree", isFree ? 1 : 0),
        //    };
        //    return SqliteHelper.ExecuteNonQuery(sql, ps);
        //}
    }
}
