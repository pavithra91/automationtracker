using AutomationTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace AutomationTracker.Controllers
{
    public class AssetController : Controller
    {
        OfficeAutomationdbEntities _context = new OfficeAutomationdbEntities();
        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewComputers()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            AssetList objModel = new AssetList();

            objModel.computerList = _context.Computers.ToList();

            return View(objModel);
        }

        public ActionResult ManageComputers(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            if (id > 0)
            {
                Computer computers = _context.Computers.Where(m => m.AUOTID == id).FirstOrDefault();
                if (computers != null)
                {
                    AssetModel objModel = new AssetModel();
                    AssetList objList = new AssetList();
                    objList.unittypeList = new List<UnitType>();
                    objList.unittypeList.Add(computers.UnitType1);

                    objList.modelList = new List<ModelType>();
                    objList.modelList.Add(computers.ModelType1);

                    objList.softwareList = new List<Software>();
                    objList.softwareList.Add(computers.Software);
                    objList.softwareList.Add(computers.Software1);

                    objList.companyList = new List<Company>();
                    objList.companyList.Add(computers.Company1);

                    objModel.assetList = objList;
                    objModel.computers = computers;
                    return View(objModel);
                }                
            }
            else
            {
                AssetModel objModel = new AssetModel();
                AssetList objList = new AssetList();
                objModel.computers = new Computer();
                objModel.computers.IsActive = true;

                objList.unittypeList = _context.UnitTypes.ToList();
                objList.softwareList = new List<Software>();
                objList.modelList = new List<ModelType>();
                objList.companyList = _context.Companies.ToList();

                objModel.assetList = objList;

                return View(objModel);
            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveComputers(AssetModel objModel)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            string _userName = Session["UserName"].ToString();

            if (objModel.computers.AUOTID == 0)
                {
                    Computer pc = new Computer();
                    pc.ModelType = objModel.computers.ModelType;
                    pc.UnitType = objModel.computers.UnitType;
                    pc.AssestNo = objModel.computers.AssestNo;
                    pc.SerialNo = objModel.computers.SerialNo;
                    pc.OS = objModel.computers.OS;
                    pc.OfficeVersion = objModel.computers.OfficeVersion;
                    pc.RAM = objModel.computers.RAM;
                    pc.HDDCapacity = objModel.computers.HDDCapacity;
                    pc.Remarks = objModel.computers.Remarks;
                    pc.Company = objModel.company.CompanyID;
                    pc.PurchaseDate = objModel.computers.PurchaseDate;
                    pc.DisposeDate = objModel.computers.DisposeDate;

                    pc.AddedBy = _userName;
                    pc.AddedDate = DateTime.Now;

                    _context.Computers.Add(pc);
                    _context.SaveChanges();

                    User _user = _context.Users.Where(w => w.FullName == "IT Pool" && w.Company == objModel.company.CompanyID).FirstOrDefault();
                    UnitType _unitType = _context.UnitTypes.Where(w => w.UnitTypeID == pc.UnitType).FirstOrDefault();

                    UserAsset _userAssest = new UserAsset();
                    _userAssest.Category = _unitType.Category;
                    _userAssest.ItemID = pc.AUOTID;
                    _userAssest.PANo = _user.PANo;
                    _userAssest.UserID = _user.UserID;

                    _context.UserAssets.Add(_userAssest);
                    _context.SaveChanges();
                }
                else
                {
                    Computer pc = _context.Computers.Where(m => m.AUOTID == objModel.computers.AUOTID).FirstOrDefault();
                    pc.OS = objModel.computers.OS;
                    pc.OfficeVersion = objModel.computers.OfficeVersion;
                    pc.HDDCapacity = objModel.computers.HDDCapacity;
                    pc.Remarks = objModel.computers.Remarks;
                    pc.Company = objModel.company.CompanyID;

                if(!objModel.computers.IsActive)
                {
                    pc.IsActive = objModel.computers.IsActive;
                    pc.DisposeRemark = objModel.computers.DisposeRemark;

                    DisposeList _disposePC = new DisposeList();
                    _disposePC.Category = 1;
                    _disposePC.DisposeDate = pc.DisposeDate;
                    _disposePC.IsDisposed = true;
                    _disposePC.ItemID = pc.AUOTID;
                    _disposePC.UpdateBy = _userName;
                    _disposePC.UpdateDate = DateTime.Now;

                    _context.DisposeLists.Add(_disposePC);
                    _context.SaveChanges();
                }

                    pc.UpdateBy = _userName;
                    pc.UpdateDate = DateTime.Now;

                    _context.Computers.Attach(pc);
                    _context.Entry(pc).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            return RedirectToAction("ViewComputers");
        }

        public ActionResult ViewMobilePhones()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            AssetList objModel = new AssetList();

            objModel.phonesanddongleList = _context.PhoneDongles.ToList();

            return View(objModel);
        }

        public ActionResult ManageMobilePhones(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            if (id > 0)
            {
                PhoneDongle phones = _context.PhoneDongles.Where(m => m.AUOTID == id).FirstOrDefault();
                if (phones != null)
                {
                    AssetModel objModel = new AssetModel();
                    AssetList objList = new AssetList();
                    objList.unittypeList = new List<UnitType>();
                    objList.unittypeList.Add(phones.UnitType1);

                    objList.modelList = new List<ModelType>();
                    objList.modelList.Add(phones.ModelType1);
                    objList.providerList = new List<Provider>();
                    objList.providerList.Add(phones.Provider1);

                    objList.companyList = new List<Company>();
                    objList.companyList.Add(phones.Company1);

                    objModel.assetList = objList;
                    objModel.phonesanddongles = phones;
                    return View(objModel);
                }
            }
            else
            {
                AssetModel objModel = new AssetModel();
                AssetList objList = new AssetList();
                objModel.phonesanddongles = new PhoneDongle();
                objModel.phonesanddongles.IsActive = true;

                objList.unittypeList = _context.UnitTypes.ToList();
                objList.modelList = new List<ModelType>();
                objList.providerList = _context.Providers.ToList();
                objList.companyList = _context.Companies.ToList();

                objModel.assetList = objList;

                return View(objModel);
            }
            return null;
        }

        [HttpPost]
        public ActionResult SavePhoneDevices(AssetModel objModel)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            string _userName = Session["UserName"].ToString();

            if (objModel.phonesanddongles.AUOTID == 0)
            {
                PhoneDongle mobile = new PhoneDongle();
                mobile.ModelType = objModel.phonesanddongles.ModelType;
                mobile.UnitType = objModel.phonesanddongles.UnitType;
                mobile.AssestNo = objModel.phonesanddongles.AssestNo;
                mobile.SerialNo = objModel.phonesanddongles.SerialNo;
                mobile.Provider = objModel.phonesanddongles.Provider;
                mobile.ConnectionNo = objModel.phonesanddongles.ConnectionNo;
                mobile.SimNo = objModel.phonesanddongles.SimNo;
                mobile.EMEINo1 = objModel.phonesanddongles.EMEINo1;
                mobile.EMEINo2 = objModel.phonesanddongles.EMEINo2;
                mobile.Remarks = objModel.phonesanddongles.Remarks;
                mobile.Company = objModel.company.CompanyID;
                mobile.PurchaseDate = objModel.phonesanddongles.PurchaseDate;
                mobile.DisposeDate = objModel.phonesanddongles.DisposeDate;

                mobile.AddedBy = _userName;
                mobile.AddedDate = DateTime.Now;

                _context.PhoneDongles.Add(mobile);
                _context.SaveChanges();

                User _user = _context.Users.Where(w => w.FullName == "IT Pool" && w.Company == objModel.company.CompanyID).FirstOrDefault();

                UnitType _unitType = _context.UnitTypes.Where(w => w.UnitTypeID == mobile.UnitType).FirstOrDefault();

                UserAsset _userAssest = new UserAsset();
                _userAssest.Category = _unitType.Category;
                _userAssest.ItemID = mobile.AUOTID;
                _userAssest.PANo = _user.PANo;
                _userAssest.UserID = _user.UserID;

                _context.UserAssets.Add(_userAssest);
                _context.SaveChanges();
            }
            else
            {
                PhoneDongle mobile = _context.PhoneDongles.Where(m => m.AUOTID == objModel.phonesanddongles.AUOTID).FirstOrDefault();
                mobile.ConnectionNo = objModel.phonesanddongles.ConnectionNo;
                mobile.EMEINo1 = objModel.phonesanddongles.EMEINo1;
                mobile.EMEINo2 = objModel.phonesanddongles.EMEINo2;
                mobile.SimNo = objModel.phonesanddongles.SimNo;
                mobile.Remarks = objModel.phonesanddongles.Remarks;
                mobile.Company = objModel.company.CompanyID;

                if (!objModel.phonesanddongles.IsActive)
                {
                    mobile.IsActive = objModel.computers.IsActive;
                    mobile.DisposeRemark = objModel.computers.DisposeRemark;

                    DisposeList _disposePC = new DisposeList();
                    _disposePC.Category = 2;
                    _disposePC.DisposeDate = mobile.DisposeDate;
                    _disposePC.IsDisposed = true;
                    _disposePC.ItemID = mobile.AUOTID;
                    _disposePC.UpdateBy = _userName;
                    _disposePC.UpdateDate = DateTime.Now;

                    _context.DisposeLists.Add(_disposePC);
                    _context.SaveChanges();
                }

                mobile.UpdateBy = _userName;
                mobile.UpdateDate = DateTime.Now;

                _context.PhoneDongles.Attach(mobile);
                _context.Entry(mobile).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("ViewMobilePhones");
        }

        public ActionResult ViewVOIP()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            AssetList objModel = new AssetList();

            objModel.voipList = _context.VOIPs.ToList();

            return View(objModel);
        }

        public ActionResult ManageVOIP(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            if (id > 0)
            {
                VOIP _voip = _context.VOIPs.Where(m => m.AUTOID == id).FirstOrDefault();
                if (_voip != null)
                {
                    AssetModel objModel = new AssetModel();
                    AssetList objList = new AssetList();
                    objList.unittypeList = new List<UnitType>();
                    objList.unittypeList.Add(_voip.UnitType1);

                    objList.modelList = new List<ModelType>();
                    objList.modelList.Add(_voip.ModelType1);

                    objList.companyList = new List<Company>();
                    objList.companyList.Add(_voip.Company1);

                    objModel.assetList = objList;
                    objModel.voip = _voip;
                    return View(objModel);
                }
            }
            else
            {
                AssetModel objModel = new AssetModel();
                AssetList objList = new AssetList();
                objModel.voip = new VOIP();
                objModel.voip.IsActive = true;

                objList.unittypeList = _context.UnitTypes.ToList();
                objList.modelList = new List<ModelType>();
                objList.companyList = _context.Companies.ToList();

                objModel.assetList = objList;

                return View(objModel);
            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveVOIPDevices(AssetModel objModel)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            string _userName = Session["UserName"].ToString();

            if (objModel.voip.AUTOID == 0)
            {
                VOIP _voip = new VOIP();
                _voip.ModelType = objModel.voip.ModelType;
                _voip.UnitType = objModel.voip.UnitType;
                _voip.AssestNo = objModel.voip.AssestNo;
                _voip.SerialNo = objModel.voip.SerialNo;
                _voip.ExtentionNo = objModel.voip.ExtentionNo;
                _voip.Remarks = objModel.voip.Remarks;
                _voip.Company = objModel.company.CompanyID;
                _voip.PurchaseDate = objModel.voip.PurchaseDate;
                _voip.DisposeDate = objModel.voip.DisposeDate;

                _voip.AddedBy = _userName;
                _voip.AddedDate = DateTime.Now;

                _context.VOIPs.Add(_voip);
                _context.SaveChanges();

                User _user = _context.Users.Where(w => w.FullName == "IT Pool" && w.Company == objModel.company.CompanyID).FirstOrDefault();

                UnitType _unitType = _context.UnitTypes.Where(w => w.UnitTypeID == _voip.UnitType).FirstOrDefault();

                UserAsset _userAssest = new UserAsset();
                _userAssest.Category = _unitType.Category;
                _userAssest.ItemID = _voip.AUTOID;
                _userAssest.PANo = _user.PANo;
                _userAssest.UserID = _user.UserID;

                _context.UserAssets.Add(_userAssest);
                _context.SaveChanges();
            }
            else
            {
                VOIP _voip = _context.VOIPs.Where(m => m.AUTOID == objModel.voip.AUTOID).FirstOrDefault();
                _voip.ExtentionNo = objModel.phonesanddongles.ConnectionNo;
                _voip.Remarks = objModel.phonesanddongles.Remarks;
                _voip.Company = objModel.company.CompanyID;

                if (!objModel.voip.IsActive)
                {
                    _voip.IsActive = objModel.computers.IsActive;
                    _voip.DisposeRemark = objModel.computers.DisposeRemark;

                    DisposeList _disposePC = new DisposeList();
                    _disposePC.Category = 3;
                    _disposePC.DisposeDate = _voip.DisposeDate;
                    _disposePC.IsDisposed = true;
                    _disposePC.ItemID = _voip.AUTOID;
                    _disposePC.UpdateBy = _userName;
                    _disposePC.UpdateDate = DateTime.Now;

                    _context.DisposeLists.Add(_disposePC);
                    _context.SaveChanges();
                }

                _voip.UpdateBy = _userName;
                _voip.UpdateDate = DateTime.Now;

                _context.VOIPs.Attach(_voip);
                _context.Entry(_voip).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("ViewVOIP");
        }


        [HttpPost]
        public ActionResult AssignUser(UserModel objModel)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            var item = _context.UserAssets.Where(w => w.ItemID == objModel.userAssestList.ItemID && w.Category == objModel.userAssestList.Category).FirstOrDefault();
            item.UserID = objModel.user.UserID;
            item.ActualAssignee = objModel.user.UserID;

            _context.UserAssets.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("ViewUsers", "Account");
        }
        

        #region GET Request
        [HttpGet]
        public virtual JsonResult GetModels(string UnitTypeID)
        {
            try
            {
                int ID = Convert.ToInt32(UnitTypeID);

                return Json(
                    _context.ModelTypes.Where(w => w.UnitType == ID).Select(x => new
                    {
                        id = x.ModelID,
                        name = x.ModelName
                    }), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        public virtual JsonResult GetSoftwares()
        {
            try
            {
                return Json(
                    _context.Softwares.Select(x => new
                    {
                        id = x.SoftwareID,
                        name = x.SoftwareName,
                        softwaretype = x.SoftwareType
                    }), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        public virtual JsonResult GetProviders()
        {
            try
            {
                return Json(
                    _context.Providers.Select(x => new
                    {
                        id = x.AUTOID,
                        name = x.ProviderName
                    }), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        public virtual JsonResult GetCompany()
        {
            try
            {
                return Json(
                    _context.Companies.Select(x => new
                    {
                        id = x.CompanyID,
                        name = x.CompanyName
                    }), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}