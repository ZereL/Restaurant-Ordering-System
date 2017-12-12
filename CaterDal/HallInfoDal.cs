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
    public class HallInfoDal
    {
        /// <summary>
        /// GetList
        /// </summary>
        /// <returns></returns>
        public List<HallInfo> GetList()
        {
            string sql = "select * from hallinfo where hisdelete = 0";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<HallInfo> list = new List<HallInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HallInfo()
                {
                    HId = Convert.ToInt32(row["hid"]),
                    HTitle = row["htitle"].ToString()
                });
            }
            return list;

        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="hi"></param>
        /// <returns></returns>
        public int Insert(HallInfo hi)
        {
            string sql = "insert into HallInfo (htitle,hisdelete) values (@title,0)";
            SQLiteParameter p = new SQLiteParameter("@title, hi.HTitle");
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="hi"></param>
        /// <returns></returns>

        public int Update (HallInfo hi)
        {
            string sql = "update HallInfo htitle=@title set where hid=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("Title", hi.HTitle),
                new SQLiteParameter("@id", hi.HId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "update hallinfo set hisdelete = 1 where hid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
