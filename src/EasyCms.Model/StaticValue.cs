using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    public class StaticValue
    {
        /// <summary>
        /// 旅游分类ID
        /// </summary>
        public const string TravelCategoryID = "";

        public static string GeneratoRandom()
        {
            Random r = new Random();
            string temMsg = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                temMsg += r.Next(0, 9);
            }
            return temMsg;
        }
    }


    public enum StationMode
    {
        首页Bar轮询,
        推荐商品,
        热卖商品,
        特价商品,
        最新商品,
        畅销精品,
        分类首页推荐
    }
}