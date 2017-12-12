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
    public partial class MemberInfoDal
    {
        //getlist
        public List<MemberInfo> GetList(Dictionary<string,string> dic)
        {
            string sql = "select mi.*,mti.mTitle as MTypeTitle, mti.mdiscount " +
                         "from MemberInfo as mi " +
                         "inner join MemberTypeInfo as mti " +
                         "on mi.mTypeId=mti.mid " +
                         "where mi.mIsDelete=0 ";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            //get condition sql
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    //" and mname like @mname"
                    sql += " and mi." + pair.Key + " like @" + pair.Key;
                    //@mname,'%abc%'
                    listP.Add(new SQLiteParameter("@" + pair.Key, "%" + pair.Value + "%"));
                }
            }
            DataTable dt = SqliteHelper.GetDataTable(sql, listP.ToArray());
            List<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPhone = row["mphone"].ToString(),
                    MMoney = Convert.ToDecimal(row["mmoney"]),
                    MTypeId = Convert.ToInt32(row["MTypeId"]),
                    MTypeTitle = row["MTypeTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["mDiscount"])
                });
            }
            return list;
        }
        //Insert
        public int Insert (MemberInfo mi)
        {
            string sql = "insert into memberinfo(mtypeid,mname,mphone,mmoney,misdelete) values (@tid,@name,@phone,@money,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@tid", mi.MTypeId),
                new SQLiteParameter("@name", mi.MName),
                new SQLiteParameter("@phone", mi.MPhone),
                new SQLiteParameter("@money", mi.MMoney),
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        //Update
        public int Update (MemberInfo mi)
        {

            string sql = "insert into memberinfo(mtypeid,mname,mphone,mmoney,misDelete) values(@tid,@name,@phone,@money,0)";

            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@tid", mi.MTypeId),
                new SQLiteParameter("@name", mi.MName),
                new SQLiteParameter("@phone", mi.MPhone),
                new SQLiteParameter("@money", mi.MMoney)
            };

            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
