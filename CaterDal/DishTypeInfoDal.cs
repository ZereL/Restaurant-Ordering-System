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
    public partial class DishTypeInfoDal
    {
        /// <summary>
        /// GetList
        /// </summary>
        /// <returns></returns>
        public List<DishTypeInfo> GetList ()
        {
            string sql = "select * from DishTypeInfo where dIsDelete=0";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<DishTypeInfo> list = new List<DishTypeInfo>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(row["did"]),
                    DTitle = row["dtitle"].ToString()
                });
            }
            return list;
        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="dti"></param>
        /// <returns></returns>
        public int Insert(DishTypeInfo dti)
        {
            string sql = "insert into dishinfotype(dtitle,disdelete) values(@title,0)";
            SQLiteParameter p = new SQLiteParameter("title", dti.DTitle);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dti"></param>
        /// <returns></returns>
        public int Update(DishTypeInfo dti)
        {
            string sql = "update dishtypeinfo set dtitle = @title where did=@id";
            SQLiteParameter[] ps = new SQLiteParameter[]
            {
                new SQLiteParameter("@title",dti.DTitle),
                new SQLiteParameter("@id",dti.DId)
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
            string sql = "update dishtypeinfo set disdelete = 1 where did=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
