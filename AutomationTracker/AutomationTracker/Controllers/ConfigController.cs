using AutomationTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomationTracker.Controllers
{
    public class ConfigController : Controller
    {
        OfficeAutomationdbEntities _context = new OfficeAutomationdbEntities();
        // GET: Config
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            AssetModel objModel = new AssetModel();
            AssetList objList = new AssetList();

            objList.modelList = _context.ModelTypes.ToList();
            objModel.assetList = objList;

            return View(objModel);
        }

        public ActionResult ManageModels(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            AssetList objList = new AssetList();
            objList.unittypeList = _context.UnitTypes.ToList();

            if (id==0)
            {
                AssetModel objModel = new AssetModel();               
                objList.modelList = _context.ModelTypes.ToList();                
                objModel.assetList = objList;

                return View(objModel);
            }
            else
            {
                ModelType model = _context.ModelTypes.Where(m => m.ModelID == id).FirstOrDefault();
                if(model !=null)
                {
                    AssetModel objModel = new AssetModel();
                    objModel.Modeltype = model;
                    objModel.assetList = objList;

                    return View(objModel);
                }

            }
            return null;
        }

        public ActionResult ViewModels()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            AssetModel objModel = new AssetModel();
            AssetList objList = new AssetList();

            objList.modelList = _context.ModelTypes.ToList();
            objModel.assetList = objList;

            return View(objModel);
        }

        public ActionResult ViewUnitTypes()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            AssetModel objModel = new AssetModel();
            AssetList objList = new AssetList();

            objList.unittypeList = _context.UnitTypes.ToList();
            objModel.assetList = objList;

            return View(objModel);
        }

        public ActionResult ManageUnitTypes(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            if (id == 0)
            {
                AssetModel objModel = new AssetModel();
                AssetList objList = new AssetList();

                objList.unittypeList = _context.UnitTypes.ToList();
                objList.categoryList = _context.Categories.ToList();
                objModel.assetList = objList;

                return View(objModel);
            }
            else
            {
                UnitType unitType = _context.UnitTypes.Where(m => m.UnitTypeID == id).FirstOrDefault();
                if (unitType != null)
                {
                    AssetModel objModel = new AssetModel();
                    AssetList objList = new AssetList();

                    objList.unittypeList = _context.UnitTypes.ToList();
                    objList.categoryList = _context.Categories.ToList();
                    objModel.assetList = objList;
                    return View(objModel);
                }

            }
            return null;
        }


        #region API Calls
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveModels(AssetModel asset)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            string _userName = Session["UserName"].ToString();

            if (asset.Modeltype.ModelID > 0)
            {
                ModelType objModel = _context.ModelTypes.Where(w => w.ModelID == asset.Modeltype.ModelID).FirstOrDefault();
                objModel.ModelName = asset.Modeltype.ModelName;
                objModel.UnitType = asset.Modeltype.UnitType;
                objModel.UpdateBy = _userName;
                objModel.UpdateDate = DateTime.Now;

                _context.ModelTypes.Attach(objModel);
                _context.Entry(objModel).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                ModelType objModel = new ModelType();
                objModel.ModelName = asset.Modeltype.ModelName;
                objModel.UnitType = asset.Modeltype.UnitType;
                objModel.AddedBy = _userName;
                objModel.AddedDate = DateTime.Now;

                _context.ModelTypes.Add(objModel);
                _context.SaveChanges();
            }

            return RedirectToAction("ViewModels", "Config");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveUnitTypes(AssetModel asset)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            string _userName = Session["UserName"].ToString();

            asset.Unittype.AddedBy = _userName;
            asset.Unittype.AddedDate = DateTime.Now;
            _context.UnitTypes.Add(asset.Unittype);
            _context.SaveChanges();

            return null;
        }
        #endregion
    }
}