using EasyCms.Model;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Dal
{
    public class WebSiteSetDal : Sharp.Data.BaseManager
    {
      

        public int Save(WebSiteSet item)
        {
             
            return Dal.Submit(item);

        }





        public WebSiteSet GetEntity()
        {

            WebSiteSet asp = Dal.From<WebSiteSet>().Join<AttachFile>(WebSiteSet._.Logo==AttachFile._.RefID,JoinType.leftJoin)
                .Select(WebSiteSet._.ID.All,AttachFile.GetFilePath("","LogoUrl"))
              .ToFirst<WebSiteSet>();
            if (asp == null)
            {
                asp = new WebSiteSet() { ID = Guid.NewGuid().ToString() };
            }
            if (!string.IsNullOrWhiteSpace(asp.WeiXinImg))
            {
                asp.WeiXinImgUrl= Dal.From<AttachFile>().Where(AttachFile._.RefID == asp.WeiXinImg).Select(AttachFile.GetFilePath("", "WeiXinImgUrl")).ToScalar() as string;

            }
            if (!string.IsNullOrWhiteSpace(asp.AndroidImg))
            {
                asp.AndroidImgUrl = Dal.From<AttachFile>().Where(AttachFile._.RefID == asp.AndroidImg).Select(AttachFile.GetFilePath("", "AndroidImgUrl")).ToScalar() as string;
            }
            if (!string.IsNullOrWhiteSpace(asp.IosImg))
            {
                asp.IosImgUrl = Dal.From<AttachFile>().Where(AttachFile._.RefID == asp.IosImg).Select(AttachFile.GetFilePath("", "IosImgUrl")).ToScalar() as string;
            }
            return asp;

        }




    }


}
