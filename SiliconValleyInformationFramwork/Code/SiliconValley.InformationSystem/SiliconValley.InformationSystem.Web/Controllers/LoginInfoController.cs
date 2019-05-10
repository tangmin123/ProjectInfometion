using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiliconValley.InformationSystem.Util;
using SiliconValley.InformationSystem.Entity.Base_SysManage;
using SiliconValley.InformationSystem.Business;
using SiliconValley.InformationSystem.Business.UserManeger;
using SiliconValley.InformationSystem.Business.Common;

namespace SiliconValley.InformationSystem.Web.Controllers
{
    public class LoginInfoController : Controller
    {
        // GET: LoginInfo/LoginFunction
        //登陆界面
        UserInfoManeger userinfo = new UserInfoManeger();
        public ActionResult Login()
        {
            return View();
        }

        //登陆方法
        public ActionResult LoginFunction(Base_User u)
        {
            ErrorResult err = new ErrorResult();
            try
            {
                string pwd = Util.Extention.ToMD5String(u.Password);
                Base_User findu = userinfo.GetList().Where(find => find.UserName == u.UserName && find.Password == pwd).FirstOrDefault();
                if (findu != null)
                {
                    err.Success = true;
                    err.Msg = "登陆成功!";
                    err.Data = " /Main/Index";
                    return Json(err, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    err.Msg = "用户名或密码错误";
                }
            }
            catch (Exception ex)
            {
                BusHelper.WriteSysLog(ex.Message, EnumType.LogType.系统异常);
            }
            return Json(err, JsonRequestBehavior.AllowGet);
        }
    }
}