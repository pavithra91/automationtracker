using AutomationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

                objModel.assetList = objList;

                return View(objModel);
            }
            else
            {
                Computer computers = _context.Computers.Where(m => m.AUOTID == id).FirstOrDefault();
                if (computers != null)
                {
                    AssetModel objModel = new AssetModel();
                    
                    objModel.computers = computers;
                    return View(objModel);
                }

            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveComputers(AssetModel objModel)
        {
            if(objModel.computers.AUOTID == 0)
            {
                Computer pc = new Computer();
                pc.ModelType = objModel.computers.ModelType1.ModelID;
                pc.UnitType = objModel.computers.UnitType1.UnitTypeID;
                pc.AssestNo = objModel.computers.AssestNo;
                pc.SerialNo = objModel.computers.SerialNo;
                pc.OS = objModel.computers.OS;
                //pc.OfficeVersion = objModel.computers.OfficeVersion;
                pc.HDDCapacity = objModel.computers.HDDCapacity;
                pc.Remarks = objModel.computers.Remarks;

                pc.AddedBy = "";
                pc.AddedDate = DateTime.Now;

                _context.Computers.Add(pc);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewComputers");
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
    }
}