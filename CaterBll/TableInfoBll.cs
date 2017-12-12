using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class TableInfoBll
    {
        private TableInfoDal tiDal = new TableInfoDal();
        /// <summary>
        /// Getlist
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<TableInfo> GetList(Dictionary<string, string> dic)
        {
            return tiDal.GetList(dic);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="ti"></param>
        /// <returns></returns>
        public bool Add(TableInfo ti)
        {
            return tiDal.Insert(ti) > 0;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="ti"></param>
        /// <returns></returns>
        public bool Edit(TableInfo ti)
        {
            return tiDal.Update(ti) > 0;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            return tiDal.Delete(id) > 0;
        }
    }
}
