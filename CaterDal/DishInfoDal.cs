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
    public partial class DishInfoDal
    {
        /// <summary>
        /// GetList
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<DishInfo> GetList (Dictionary<string,string> dic)
        {
            string sql = @"select di.*,dti.dtitle as dTypeTitle 
                from dishinfo as di
                inner join dishtypeinfo as dti
                on di.dtypeid=dti.did
                where di.dIsDelete=0 and dti.dIsDelete=0";

            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            //接收筛选条件
            if (dic.Count > 0)
            {
                //sql += " and di.属性 like '%值%'";
                foreach (var pair in dic)
                {
                    //sql += " and di.dtitle like @dtitle";

                    sql += " and di." + pair.Key + " like @" + pair.Key;
                    listP.Add(new SQLiteParameter("@" + pair.Key, "%" + pair.Value + "%"));//@dtitle,%abc%
                }
            }

            DataTable dt = SqliteHelper.GetDataTable(sql, listP.ToArray());
            List<DishInfo> list = new List<DishInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["did"]),
                    DTitle = row["dtitle"].ToString(),
                    DTypeTitle = row["dtypeTitle"].ToString(),
                    DChar = row["dchar"].ToString(),
                    DPrice = Convert.ToDecimal(row["dprice"])
                });
            }

            return list;

        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public int Insert(DishInfo di)
        {
            string sql = "insert into dishinfo(dtitle,dtypeid,dprice,dchar,dIsDelete) values(@title,@tid,@price,@dchar,0)";
            SQLiteParameter[] p =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@tid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@dchar",di.DChar)
            };

            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public int Update(DishInfo di)
        {
            string sql = "update dishinfo set dtitle=@title,dtypeid=@tid,dprice=@price,dchar=@dchar where did=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@tid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@dchar",di.DChar),
                new SQLiteParameter("@id",di.DId)
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
            string sql = "update dishinfo set dIsDelete=1 where did=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);

            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
