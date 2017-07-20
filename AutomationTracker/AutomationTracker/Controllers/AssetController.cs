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
            AssetList objModel = new AssetList();

            objModel.computerList = _context.Computers.ToList();

            return View(objModel);
        }

        public ActionResult ManageComputers(int? id)
        {
            if (id == 0)
            {
                AssetModel objModel = new AssetModel();
                AssetList objList = new AssetList();
                objModel.computers = new Computer();

                objList.unittypeList = _context.UnitTypes.ToList();
                objList.softwareList = new List<Software>();
                objList.modelList = new List<ModelType>();
                objList.companyList = _context.Companies.ToList();

                objModel.assetList = objList;

                return View(objModel);
            }
            else
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

                    objModel.assetList = objList;
                    objModel.computers = computers;
                    return View(objModel);
                }

            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveComputers(AssetModel objModel)
        {
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

                    pc.AddedBy = "";
                    pc.AddedDate = DateTime.Now;

                    _context.Computers.Add(pc);
                    _context.SaveChanges();

                    User _user = _context.Users.Where(w => w.FullName == "IT Pool" && w.Company == objModel.company.CompanyID).FirstOrDefault();

                    UserAsset _userAssest = new UserAsset();
                    _userAssest.Category = "Computers";
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

                    pc.UpdateBy = "";
                    pc.UpdateDate = DateTime.Now;

                    _context.Computers.Attach(pc);
                    _context.Entry(pc).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            return RedirectToAction("ViewComputers");
        }

        public ActionResult ViewMobilePhones()
        {
            AssetList objModel = new AssetList();

            objModel.phonesanddongleList = _context.PhoneDongles.ToList();

            return View(objModel);
        }

        public ActionResult ManageMobilePhones(int? id)
        {
            if (id == 0)
            {
                AssetModel objModel = new AssetModel();
                AssetList objList = new AssetList();
                objModel.phonesanddongles = new PhoneDongle();

                objList.unittypeList = _context.UnitTypes.ToList();
                objList.modelList = new List<ModelType>();
                objList.providerList = _context.Providers.ToList();
                objList.companyList = _context.Companies.ToList();

                objModel.assetList = objList;

                return View(objModel);
            }
            else
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

                    objModel.assetList = objList;
                    objModel.phonesanddongles = phones;
                    return View(objModel);
                }

            }
            return null;
        }

        [HttpPost]
        public ActionResult SavePhoneDevices(AssetModel objModel)
        {
            if (objModel.phonesanddongles.AUOTID == 0)
            {
                PhoneDongle mobile = new PhoneDongle();
                mobile.ModelType = objModel.computers.ModelType;
                mobile.UnitType = objModel.computers.UnitType;
                mobile.AssestNo = objModel.computers.AssestNo;
                mobile.SerialNo = objModel.computers.SerialNo;
                mobile.Provider1 = objModel.phonesanddongles.Provider1;
                mobile.ConnectionNo = objModel.phonesanddongles.ConnectionNo;
                mobile.SimNo = objModel.phonesanddongles.SimNo;
                mobile.EMEINo1 = objModel.phonesanddongles.EMEINo1;
                mobile.EMEINo2 = objModel.phonesanddongles.EMEINo2;
                mobile.Remarks = objModel.computers.Remarks;
                mobile.Company = objModel.company.CompanyID;

                mobile.AddedBy = "";
                mobile.AddedDate = DateTime.Now;

                _context.PhoneDongles.Add(mobile);
                _context.SaveChanges();

                User _user = _context.Users.Where(w => w.FullName == "IT Pool" && w.Company == objModel.company.CompanyID).FirstOrDefault();

                UserAsset _userAssest = new UserAsset();
                _userAssest.Category = "Computers";
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

                mobile.UpdateBy = "";
                mobile.UpdateDate = DateTime.Now;

                _context.PhoneDongles.Attach(mobile);
                _context.Entry(mobile).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("ViewMobilePhones");
        }

        












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
    }
}