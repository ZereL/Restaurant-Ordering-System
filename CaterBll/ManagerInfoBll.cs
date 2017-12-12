using CaterCommon;
using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class ManagerInfoBll
    {
        ManagerInfoDal miDal = new ManagerInfoDal();
        public List<ManagerInfo> GetList()
        {
            return miDal.GetList();
        }
        public bool Add(ManagerInfo mi)
        {
            return miDal.Insert(mi)>0;
        }
        public bool Edit(ManagerInfo mi)
        {
            return miDal.Update(mi) > 0;
        }
        public bool Remove(int id)
        {
            return miDal.Delete(id) > 0;
        }
        public LoginState Login(string name, string pwd, out int type)
        {
            type = -1;
            ManagerInfo mi = miDal.GetByName(name);
            if(mi==null)
            {
                return LoginState.NameError;
            }
            else
            {
                if (mi.MPwd.Equals(Md5Helper.EncryptString(pwd)))
                {
                    type = mi.MType;
                    return LoginState.ok;
                }
                else
                {
                    return LoginState.PwdError;
                }
            }
        }
    }
}
