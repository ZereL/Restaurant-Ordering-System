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
    public class MemberTypeInfoDal
    {
        //GetList
        public List<MemberTypeInfo> GetList()
        {
            string sql = "select * from membertypeinfo where mIsDelete= 0";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberTypeInfo() {
                    MId = Convert.ToInt32(row["mid"]),
                    MTitle = row["mtitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["mdiscount"])
                });
            }
            return list;
        }
        //Insert
        public int Insert(MemberTypeInfo mti)
        {
            string sql = "insert into MemberTypeInfo (mtitle, mdiscount, misdelete) values (@title,@discount,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",mti.MTitle),
                new SQLiteParameter("@discount",mti.MDiscount)
            };

            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        //update
        public int update(MemberTypeInfo mti)
        {
            string sql = "update membertypeinfo set mtitle =@title, mdiscount=@discount where mid=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title", mti.MTitle),
                new SQLiteParameter("@discount", mti.MDiscount),
                new SQLiteParameter("@id", mti.MId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        //Delete
        public int Delete(int id)
        {
            string sql = "update membertypeinfo set misdelete = 1 where mid=@id";
            SQLiteParameter sp = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
    }
}
