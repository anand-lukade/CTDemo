using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace gladius.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            GetUser();
            return View();
        }
        public ActionResult Edit(int spId, string cl, string rc, string s)
        {
            try
            {
                var model = ComplaintService.GetComplaint(spId, cl, s);
                var rcas = RcaService.GetRcasForDropDown(rc);
                var rcasList = new List<SelectListItem>();
                foreach (var rca in rcas)
                {
                    rcasList.Add(new SelectListItem()
                    {
                        Text = rca.Title,
                        Value = rca.Id
                    });
                }
                ViewBag.Rcas = rcasList;
                model.SpId = spId;
                model.ClName = cl;
                model.RcaName = rc;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult ReadAllComplaints(UserInfo userInfo)
        {
            try
            {
                var complaints = ComplaintService.GetAllComplaintsData(userInfo);
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(complaints), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetUser()
        {
            try
            {
                UserInfo user= UserService.GetUserInfo();                
                return Json(new { data=user}, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}