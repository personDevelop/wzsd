using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model.ViewModel
{
  public   class RecomandModel
    {
        public string Title { get; set; }
        public List<ListProduct> DataList { get; set; }
    }

    public class ListProduct
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public decimal SalePrice { get; set; }
    }
}
