using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLT.Components
{
    /// <summary>
    /// 统一接口Json返回结果格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AccessTokenEntity
    {

        public string access_token { get; set; }


        public string expires_in { get; set; }

    }
}