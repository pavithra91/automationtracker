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

        public ActionResult Dashboard()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ViewUsers()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            UserModel objModel = new UserModel();
            UserList objList = new UserList();
            objList.usrList = _context.Users.ToList();

            objModel.userList = objList;

            return View(objModel);
        }

        public ActionResult ManageUsers(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

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
            if(Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            string _userName = Session["UserName"].ToString();

            if (objModel.user.UserID == 0)
            {
                User _user = new User();
                _user.Title = objModel.user.Title;
                _user.FullName = objModel.user.FullName;
                _user.Company = objModel.user.Company;
                _user.Market = objModel.user.Market;
                _user.PANo = objModel.user.PANo;
                _user.SAPNo = objModel.user.SAPNo;
                _user.NIC = objModel.user.NIC;
                _user.IsActive = true;
                _user.Remarks = objModel.user.Remarks;

                _user.AddedBy = _userName;
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
                    _newuser.IsActive = true;
                    _newuser.Remarks = objModel.user.Remarks;

                    _newuser.AddedBy = _userName;
                    _newuser.AddedDate = DateTime.Now;

                    _context.Users.Add(_newuser);
                    _context.SaveChanges();

                    _user.IsActive = true;
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

                    _user.UpdateBy = _userName;
                    _user.UpdateDate = DateTime.Now;

                    _context.Users.Attach(_user);
                    _context.Entry(_user).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ViewUsers");
        }

        public ActionResult ViewUserAssests(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            UserModel objModel = new UserModel();

            objModel.userAssestList = new UserAssest();

            var assetList = _context.UserAssets.Where(w => w.UserID == id).ToList();

            List<Computer> PCList = _context.Computers.ToList();
            List<PhoneDongle> PhoneList = _context.PhoneDongles.ToList();
            List<VOIP> VOIPList = _context.VOIPs.ToList();

            objModel.userAssestList.User = _context.Users.Where(w => w.UserID == id).FirstOrDefault();
            objModel.userAssestList.ActualAssignee = _context.Users.Where(w => w.UserID == id).FirstOrDefault();

            objModel.userAssestList.ComputerList = new List<Computer>();
            objModel.userAssestList.PhoneDongleList = new List<PhoneDongle>();
            objModel.userAssestList.VOIPList = new List<VOIP>();

            foreach (var item in assetList)
            {
                if(item.Category == 1)
                {
                    objModel.userAssestList.ComputerList.Add(PCList.Find(w=>w.AUOTID == item.ItemID));
                    continue;
                }
                else if(item.Category == 2)
                {
                    objModel.userAssestList.PhoneDongleList.Add(PhoneList.Find(w => w.AUOTID == item.ItemID));
                    continue;
                }
                else if(item.Category == 3)
                {
                    objModel.userAssestList.VOIPList.Add(VOIPList.Find(w => w.AUTOID == item.ItemID));
                    continue;
                }
            }

            return View(objModel);
        }

        public ActionResult TransferAsset(int? id, int category)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            UserModel objModel = new UserModel();
            UserList objList = new UserList();

            objModel.userAssestList = new UserAssest();

            objModel.userAssestList.ComputerList = new List<Computer>();
            objModel.userAssestList.PhoneDongleList = new List<PhoneDongle>();
            objModel.userAssestList.VOIPList = new List<VOIP>();

            objList.companyList = new List<Company>();
            objModel.userList = new UserList();
            objModel.userList.usrList = new List<AutomationTracker.User>();
            objModel.user = new AutomationTracker.User();

            if (category == 1)
            {
                var _computers = _context.Computers.Where(w => w.AUOTID == id).FirstOrDefault();
                objModel.userAssestList.ComputerList.Add(_computers);

                objList.companyList.Add(_computers.Company1);
                objModel.userList.usrList = _context.Users.Where(w => w.Company == _computers.Company1.CompanyID).ToList();
            }
            else if(category == 2)
            {
                var _phones = _context.PhoneDongles.Where(w => w.AUOTID == id).FirstOrDefault();
                objList.companyList.Add(_phones.Company1);
                objModel.userList.usrList = _context.Users.Where(w => w.Company == _phones.Company1.CompanyID).ToList();
            }
            else if(category == 3)
            {
                var _voip = _context.VOIPs.Where(w => w.AUTOID == id).FirstOrDefault();
                objList.companyList.Add(_voip.Company1);
                objModel.userList.usrList = _context.Users.Where(w => w.Company == _voip.Company1.CompanyID).ToList();
            }
            return View(objModel);
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel objModel)
        {
            if (ModelState.IsValid)
            {
                    var obj = _context.SystemUsers.Where(a => a.UserName.Equals(objModel.Username) && a.Password.Equals(objModel.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.AUTOID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        Session["FullName"] = obj.FullName.ToString();

                    return RedirectToAction("Dashboard");
                    }
                    else
                {
                    //Invalid User
                }
            }
            else
            {
                //Invalid User
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }
    }
}