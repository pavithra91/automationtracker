using AutomationTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomationTracker.Controllers
{
    public class AccountController : Controller
    {
        OfficeAutomationdbEntities _context = new OfficeAutomationdbEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewUsers()
        {
            UserModel objModel = new UserModel();
            UserList objList = new UserList();
            objList.usrList = _context.Users.ToList();

            objModel.userList = objList;

            return View(objModel);
        }

        public ActionResult ManageUsers(int? id)
        {
            if (id == 0)
            {
                UserModel objModel = new UserModel();
                UserList objList = new UserList();
                UserTitle titles = new UserTitle();
                objModel.userList = new UserList();

                objList.companyList = _context.Companies.ToList();
                objList.marketList = _context.Markets.ToList();
                objList.titlelist = titles.GetAllTitles();

                objModel.userList = objList;

                return View(objModel);
            }
            else
            {
                User users = _context.Users.Where(m => m.UserID == id).FirstOrDefault();
                if (users != null)
                {
                    UserModel objModel = new UserModel();
                    UserList objList = new UserList();
                    UserTitle titles = new UserTitle();

                    objList.companyList = new List<Company>();
                    objList.companyList.Add(users.Company1);

                    objList.marketList = new List<Market>();
                    objList.marketList.Add(users.Market1);
                    objList.titlelist = titles.GetAllTitles();

                    objModel.userList = objList;
                    objModel.user = users;
                    return View(objModel);
                }

            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveUser(UserModel objModel)
        {
            if (objModel.user.UserID == 0)
            {
                User _user = new User();
                _user.Title = objModel.user.Title;
                _user.FullName = objModel.user.FullName;
                _user.Company1 = objModel.user.Company1;
                _user.Market1 = objModel.user.Market1;
                _user.PANo = objModel.user.PANo;
                _user.SAPNo = objModel.user.SAPNo;
                _user.NIC = objModel.user.NIC;
                _user.UserStatus = "1";
                _user.Remarks = objModel.user.Remarks;

                _user.AddedBy = "";
                _user.AddedDate = DateTime.Now;

                _context.Users.Add(_user);
                _context.SaveChanges();
            }
            else
            {
                User _user = _context.Users.Where(m => m.UserID == objModel.user.UserID).FirstOrDefault();
                if(_user.PANo!=objModel.user.PANo)
                {
                    User _newuser = new User();
                    _newuser.Title = objModel.user.Title;
                    _newuser.FullName = objModel.user.FullName;
                    _newuser.Company1 = objModel.user.Company1;
                    _newuser.Market1 = objModel.user.Market1;
                    _newuser.PANo = objModel.user.PANo;
                    _newuser.SAPNo = objModel.user.SAPNo;
                    _newuser.NIC = objModel.user.NIC;
                    _newuser.UserStatus = "1";
                    _newuser.Remarks = objModel.user.Remarks;

                    _newuser.AddedBy = "";
                    _newuser.AddedDate = DateTime.Now;

                    _context.Users.Add(_newuser);
                    _context.SaveChanges();

                    _user.UserStatus = "0";
                    _context.Users.Attach(_user);
                    _context.Entry(_user).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    _user.Title = objModel.user.Title;
                    _user.FullName = objModel.user.FullName;
                    _user.Company1 = objModel.user.Company1;
                    _user.Market1 = objModel.user.Market1;
                    _user.PANo = objModel.user.PANo;
                    _user.SAPNo = objModel.user.SAPNo;
                    _user.NIC = objModel.user.NIC;
                    //_user.UserStatus = objModel.user.UserStatus;
                    _user.Remarks = objModel.user.Remarks;

                    _user.UpdateBy = "";
                    _user.UpdateDate = DateTime.Now;

                    _context.Users.Attach(_user);
                    _context.Entry(_user).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ViewUsers");
        }
    }
}