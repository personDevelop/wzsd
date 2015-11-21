using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umeng.Entity
{
    public class UmEntity
    {
        /// <summary>
        /// 应用唯一标识 必填 应用唯一标识
        /// </summary>
        public string appkey { get; set; }

        /// <summary>
        /// 必填 时间戳，10位或者13位均可，时间戳有效期为10分钟
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 必填 消息发送类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 可选 设备唯一表示  当type=unicast时,必填, 表示指定的单个设备
        ///                        当type=listcast时,必填,要求不超过500个,
        ///                        多个device_token以英文逗号间隔
        /// 友盟消息推送服务对设备的唯一标识。Android的device_token是44位字符串, iOS的device-token是64位
        /// </summary>
        public string device_token { get; set; }

        /// <summary>
        /// 可选 当type=customizedcast时，必填，alias的类型, 
        ///                         alias_type可由开发者自定义,开发者在SDK中
        ///                         调用setAlias(alias, alias_type)时所设置的alias_type
        /// </summary>
        public string alias_type { get; set; } 
       
        /// <summary>
        /// 开发者自有账号, 
        /// 可选 当type=customizedcast时, 开发者填写自己的alias。
        /// 要求不超过50个alias,多个alias以英文逗号间隔。                    
        /// 在SDK中调用setAlias(alias, alias_type)时所设置的alias
        /// 开发者可以在SDK中调用setAlias(alias, alias_type)接口将alias+alias_type与device_token做绑定, 之后开发者就可以根据自有业务逻辑筛选出alias进行消息推送
        /// </summary>
        public string alias { get; set; }


      
        /// <summary>
        /// 可选 当type=filecast时，file内容为多条device_token,  device_token以回车符分隔   当type=customizedcast时，file内容为多条alias，  alias以回车符分隔，注意同一个文件内的alias所对应  的alias_type必须和接口参数alias_type一致。  注意，使用文件播前需要先调用文件上传接口获取file_id, 
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// 可选 终端用户筛选条件,如用户标签、地域、应用版本以及渠道等,
        /// </summary>
        public string  filter { get; set; }
        /// <summary>
        /// 必填 消息内容(Android最大为1840B)
        /// </summary>
        public IContent payload { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IOSSendPolicy policy { get; set; }
        /// <summary>
        /// "true/false" // 可选 正式/测试模式。测试模式下，只会将消息发给测试设备。
        ///                              测试设备需要到web上添加。
        ///                               Android: 测试设备属于正式设备的一个子集。
        /// </summary>
        public string production_mode { get; set; }
        /// <summary>
        ///  可选 发送消息描述，建议填写。
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 可选 开发者自定义消息标识ID, 开发者可以为同一批发送的多条消息
        ///                          提供同一个thirdparty_id, 便于友盟后台后期合并统计数据。 
        /// </summary>
        public string thirdparty_id { get; set; }
       

    }
}
