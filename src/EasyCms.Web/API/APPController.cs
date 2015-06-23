using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Sharp.Common;
using System.Data;
using EasyCms.Business;
using System.Text;

namespace EasyCms.Web.API
{
    public class APPController : ApiController
    {
        public HttpResponseMessage GetNews(int count = 10)
        {
            if (count <= 0)
            {
                count = 10;
            }
            DataTable dt= new NewsInfoBll().GetNews();
            List<NewsInfo> list = new List<NewsInfo>();
            for (int i = 0; i < count; i++)
            {


                NewsInfo item = new NewsInfo();
               
                item.ID = Guid.NewGuid().ToString();
                item.NewsTitle = "新闻" + i;
                item.AllowPl = true;
                item.SubTitle = "副标题" + i;
                item.Summary = "简介" + i;
                item.Description = @"中新网6月21日电 今天清晨，加拿大女足世界杯1/8决赛开战，中国女足凭借王珊珊的进球1-0力克喀麦隆，挺进世界杯8强，下轮将迎战美国与哥伦比亚之间的胜者。
　　小组赛阶段，中国女足在先输一场的情况下，战胜荷兰、打平新西兰，以1胜1平1负的战绩获得小组第二晋级。另外一个小组，喀麦隆2胜1负，共打进9球，颇有黑马风范。另外，由于小组赛最后一场，中国队主帅郝伟被主裁判罚上看台，今天他无法在替补席指挥比赛，只能坐上看台。
　　开场后，喀麦隆充分发挥身体优势，连连发动进攻。第1分钟，喀麦隆前场抢断，马德琳禁区内抽射打高。第3分钟，祖佳远射偏出。第9分钟，恩加纳莫打门被挡，随后再射稍稍偏出。
　　反观中国队，尽管控球不占优势，但一直努力打出反击。第12分钟，吴海燕突破制造角球，王丽思把球开到后点，恩加纳莫冒顶，李冬娜停球冷静横敲，王珊珊推射远角破门，1-0。

　　第23分钟，恩加纳莫任意球射门被人墙挡出，翁圭内补射击中边网。1分钟后，韩鹏反击吊远角偏出。
　　第38分钟，喀麦隆队任意球，特彻诺打近角被王飞封出。第39分钟，小将王霜上场换下唐佳丽。上半场结束，中国队射门数3-12落后，但比分却领先。喀麦隆并没创造出太好的机会。
　　第49分钟，王珊珊反击传中，后点的王丽思推射打偏。第61分钟，中国队长传造成单刀，王珊珊面对门将推射打偏。2分钟后，恩加纳莫头球顶偏。又过了2分钟，喀麦隆换上主力攻击手尼卡特，随后恩加纳莫接传中头球吊射，皮球击中横梁弹出底线。
　　落后的喀麦隆全力进攻，尼卡特接传中后点右脚垫射，王飞将球扑住。第73分钟，中国队反越位成功，王珊珊插上射门被对手门将出击封堵。喀麦隆连续做出两次换人调整，力求殊死一搏。
　　第78分钟，娄佳惠反击吊门被对方门将奋力托出底线。2分钟后，替补出场的阿卡巴传中，恩加纳莫头球攻门偏出。第85分钟，娄佳惠赢得前场任意球，王霜左脚边路直接射门被门将扑出。1分钟后，王珊珊接后场传球再次形成单刀，面对机会她有些犹豫，被回追的后卫解围，随后喀麦隆反击，阿卡巴头球攻门偏出。
最后时刻，中国女足撤下王珊珊，换上古雅莎。一次拼抢中，韩鹏头部与对方球员冲撞，现场鲜血直流。经过90分钟的浴血奋战，中国女足1球小胜喀麦隆，挺进世界杯八强。
　　双方首发 　中国队：(4-2-3-1)12-王飞；2-刘杉杉、6-李冬娜、14-赵容、5-吴海燕； 19-谭茹殷、23-任桂辛；18-韩鹏、21-王丽思、13-唐佳丽、9-王珊珊
　　喀麦隆队：(4-3-3)1-恩多姆；4-路科、11-埃沃娜、2-马涅、12-特彻诺；8-费伍德吉奥、10-扬戈、6-祖佳；17-恩加纳莫、7-翁圭内、9-马德琳";
                list.Add(item);
                dt.AddRow(item);
            }
            string result = JsonConvert.Convert2Json(dt);
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp; 

        }
    }
}
