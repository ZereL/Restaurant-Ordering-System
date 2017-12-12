using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class MemberInfoBll
    {
        MemberInfoDal miDal = new MemberInfoDal();
        public List<MemberInfo> Getlist(Dictionary<string, string> dic)
        {
            return miDal.GetList(dic);
        }

        public bool add(MemberInfo mi)
        {
            return miDal.Insert(mi) > 0;
        }

        public bool Edit(MemberInfo mi)
        {
            return miDal.Update(mi) > 0;
        }
    }
}
