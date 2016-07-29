using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Service;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace FoodTrace.WebAPI.Controllers
{
    public class ProductTraceController : ApiController
    {
        private readonly IProcessProductService productService;

        public ProductTraceController()
        {
            productService = new ProcessProductService();
        }

        /// <summary>
        /// 根据芯片码或者二维码显示
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public HttpResponseMessage GetProductInfo(string Epc, string OrCode)
        {
            string result = "1";

            if (!string.IsNullOrEmpty(Epc))
            {
              // IProcessProductService productService = new ProcessProductService();
                var data = productService.GetProductByEpcOrCode(Epc, OrCode);
                if (data != null)
                {
                    result = JsonConvert.SerializeObject(data);
                }
            }
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(result)
            };

            return resp;

        }

        /// <summary>
        /// 返回溯源结构数据
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public HttpResponseMessage GetProductTraceInfo(string Epc, string OrCode)
        {
            string result = "1";

            if (!string.IsNullOrEmpty(Epc))
            {
                var data = productService.GetProductTrace(Epc, OrCode);
                if (data.Any())
                {
                    result = JsonConvert.SerializeObject(data);
                }
            }
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(result)
            };

            return resp;
        }

        /// <summary>
        /// 获取溯源结构中单个数据
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public HttpResponseMessage GetProductTraceDetail(string Epc, string OrCode, int code, int type)
        {
            string result = "1";

            if (!string.IsNullOrEmpty(Epc))
            {
                var data = productService.GetProductTraceDetailById(Epc, OrCode,code,type);
                if (!string.IsNullOrEmpty(data))
                {
                    result = data;
                }
            }
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(result)
            };

            return resp;
        }
    }
}
