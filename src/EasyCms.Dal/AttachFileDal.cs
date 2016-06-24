using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

namespace EasyCms.Dal
{
    public class AttachFileDal : Sharp.Data.BaseManager
    {
        public int Save(Model.AttachFile af)
        {
            int count = Dal.Count<AttachFile>(AttachFile._.RefID == af.RefID, AttachFile._.ID, false);
            if (count == 0)
            {
                af.OrderNo = 0;
            }
            else
            {
                //如果有数据了，则判断当前的最小编号是否是0，如果不是，则将当前设为0，否则加1；
                int minNo = (int)Dal.Min<AttachFile>(AttachFile._.RefID == af.RefID, AttachFile._.OrderNo);
                if (minNo == 0)
                {
                    af.OrderNo = 0;
                }
                else
                {
                    af.OrderNo = count;
                }
            }


            
            return Dal.Submit(af);
        }

        public int deleteFile(string id)
        {
            //判断当前顺序号是否是0，如果是0 则顺序减1
            AttachFile af = Dal.Find<AttachFile>(id);
            int result = 0;
            if (af != null)
            {

                result = Dal.Delete<AttachFile>(id);
                AttachFile updateNo = new AttachFile() { RecordStatus = StatusType.update, Where = AttachFile._.RefID == af.RefID && AttachFile._.OrderNo > af.OrderNo };
                ExpressionClip JF = new ExpressionClip("OrderNo-1");
                updateNo.SetModifiedProperty(AttachFile._.OrderNo, JF);
                Dal.Submit(updateNo);

            }
            
            return result;
        }

        public List<SimpalFile> GetFiles(string refid, string host)
        {
            return Dal.From<AttachFile>().Where(AttachFile._.RefID == refid)
                .Select(AttachFile._.ID, AttachFile._.RefID, AttachFile.GetThumbnaifilePath(host))
                .ToDataTable().ToList<SimpalFile>();
        }

        public List<SimpalFile> GetFiles(string host, List<string> refidList)
        {
            return Dal.From<AttachFile>().Where(AttachFile._.RefID.In(refidList) && AttachFile._.OrderNo == 0)
               .Select(AttachFile._.ID, AttachFile._.RefID, AttachFile.GetThumbnaifilePath(host))
               .ToDataTable().ToList<SimpalFile>();
        }
    }
}
