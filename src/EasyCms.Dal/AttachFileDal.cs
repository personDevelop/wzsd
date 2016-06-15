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
            af.OrderNo = Dal.Count<AttachFile>(AttachFile._.RefID == af.RefID, AttachFile._.ID, false) + 1;
            return Dal.Submit(af);
        }

        public int deleteFile(string id)
        {
            return Dal.Delete<AttachFile>(id);
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
