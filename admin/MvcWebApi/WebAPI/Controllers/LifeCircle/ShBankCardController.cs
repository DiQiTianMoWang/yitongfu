﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ModelDb;
using System.Collections;
using System.Web;
using WebAPI.Models;
using System.Web.Http.Results;
using Com;
using WebAPI;

namespace WebAPI.Controllers.LifeCircle
{
    public class ShBankCardController : ApiController
    {
        private ytf_dbEntities db = new ytf_dbEntities();

        JsonModel model = new JsonModel();
        // GET: api/Admin 用户列表
        public ResponseMessageResult Getsh_business_bank_card(int page, int pagesize, string code)
        {
            JwtModel jwtmodel = JwtHelper.getToken(HttpContext.Current.Request.Headers.GetValues("Authorization").First().ToString());
            if (jwtmodel.isadmin)
            {
                var temp = from a in db.sh_business_bank_card
                           join b in db.sh_business_appinfo on a.sh_businessid equals b.id
                           where (a.name.Contains(code) || string.IsNullOrEmpty(code))
                           select new
                           {
                               a.id,
                               a.province,
                               a.city,
                               a.bankaddress,
                               a.bankCode,
                               a.bankEightCode,
                               a.sh_businessid,
                               a.name,
                               a.bankaccountNo,
                               a.certCode,
                               a.certNo,
                               a.defaultAcc,
                               a.addtime,
                               a.adduser,
                               a.updatetime,
                               a.updateuser,
                               a.mobileNo,
                               a.isaudit,
                               a.bankName,
                               b.sh_businessname
                           };
                model.total = temp.Count();
                model.data = temp.OrderByDescending(s => s.id).Skip((page - 1) * pagesize).Take(pagesize).ToList();

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
            }
            else
            {
                model.message = "用户权限不足";
                model.status_code = 401;
            }
            return new ResponseMessageResult(Request.CreateResponse((HttpStatusCode)model.status_code, model));
        }
        // PUT: api/Admin/5
        [ResponseType(typeof(sh_business_bank_card))]
        public ResponseMessageResult Putsh_business_bank_card(sh_business_bank_card sh_business_bank_card)
        {
            JwtModel jwtmodel = JwtHelper.getToken(HttpContext.Current.Request.Headers.GetValues("Authorization").First().ToString());
            if (jwtmodel.isadmin)
            {
                var a_bank_item = db.aa_bank_code.Where(o => o.code == sh_business_bank_card.bankCode).First();
                sh_business_bank_card.bankEightCode = a_bank_item.eightcode;
                sh_business_bank_card.bankName = a_bank_item.explain;
                db.Entry(sh_business_bank_card).State = EntityState.Modified;
                try
                {
                    model.message = "修改成功";
                    model.status_code = 200;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    model.message = ex.Message;
                    model.status_code = 401;
                }
            }
            else
            {
                model.message = "用户权限不足";
                model.status_code = 401;
            }
            return new ResponseMessageResult(Request.CreateResponse((HttpStatusCode)model.status_code, model));
        }

        // POST: api/sh_business_bank_card
        [ResponseType(typeof(sh_business_bank_card))]
        public ResponseMessageResult Postsh_business_bank_card(sh_business_bank_card sh_business_bank_card)
        {
            JwtModel jwtmodel = JwtHelper.getToken(HttpContext.Current.Request.Headers.GetValues("Authorization").First().ToString());
            if (jwtmodel.isadmin)
            {
                var a_bank_item = db.aa_bank_code.Where(o => o.code == sh_business_bank_card.bankCode).First();
                sh_business_bank_card.bankEightCode = a_bank_item.eightcode;
                sh_business_bank_card.bankName = a_bank_item.explain;
                sh_business_bank_card.addtime = DateTime.Now;
                sh_business_bank_card.adduser = jwtmodel.username;
                db.sh_business_bank_card.Add(sh_business_bank_card);
                try
                {
                    db.SaveChanges();
                    model.message = "新增成功";
                    model.status_code = 200;
                }
                catch (Exception ex)
                {
                    model.message = ex.Message;
                    model.status_code = 401;
                }
            }
            else
            {
                model.message = "用户权限不足";
                model.status_code = 401;
            }
            return new ResponseMessageResult(Request.CreateResponse((HttpStatusCode)model.status_code, model));
        }

        // DELETE: api/Router/5
        [ResponseType(typeof(sh_business_bank_card))]
        public ResponseMessageResult Deletesh_business_bank_card(int id)
        {

            sh_business_bank_card sh_business_bank_card = db.sh_business_bank_card.Find(id);
            if (sh_business_bank_card == null)
            {
                model.message = "删除失败";
                model.status_code = 401;
            }

            db.sh_business_bank_card.Remove(sh_business_bank_card);
            db.SaveChanges();
            model.message = "删除成功";
            model.status_code = 200;
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