﻿using ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [WebApiActionDebugFilter]
    public class MerchantCityController : ApiController
    {
        private ytf_dbEntities db = new ytf_dbEntities();
        JsonModel model = new JsonModel();
        public ResponseMessageResult Getaa_merchant_city()
        {
            var temp = from a in db.aa_merchant_city
                       select new
                       {
                           a.id,
                           a.code,
                           a.name,
                       };
            model.data = temp.ToList();

            if (model.data.Count > 0)
            {
                model.message = "查询成功";
                model.status_code = 200;
            }
            else
            {
                model.message = "暂无数据";
                model.status_code = 200;
            }
            return new ResponseMessageResult(Request.CreateResponse((HttpStatusCode)model.status_code, model));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
