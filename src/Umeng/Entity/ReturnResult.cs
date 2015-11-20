using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umeng.Entity
{
    public class ReturnResult
    {
        public string ret { get; set; }

    }

    public class ReturnSuccessData
    {
        public string msg_id { get; set; }

        public string task_id { get; set; }

        public string error_code { get; set; }
        public string thirdparty_id { get; set; }

    }


    public enum HTTPStatus
    {
        请求成功 = 200,
        创建成功 = 201,
        更新成功 = 202,
        请求的地址不存在或者包含不支持的参数 = 400,
        未授权 = 401,
        被禁止访问 = 403,
        请求的资源不存在 = 404,
        内部错误 = 500
    }
    
}
