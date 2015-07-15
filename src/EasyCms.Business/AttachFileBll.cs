using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Business
{
  public class AttachFileBll
    {
        AttachFileDal Dal = new AttachFileDal();
        public int Save(AttachFile af)
        {
       
            return Dal.Save(  af);

        }


        public int deleteFile(string id)
        {
            return Dal.deleteFile(id);
        }

        public List<SimpalFile> GetFiles(string refid)
        {
            return Dal.GetFiles(refid);
        }
    }
}
