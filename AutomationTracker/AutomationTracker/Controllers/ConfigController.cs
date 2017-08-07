using AutomationTracker.Models;
using System;
using System.Collections.Generic;
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


        #region
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveModels(AssetModel asset)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            string _userName = Session["UserName"].ToString();

            if (asset.assetList.modelList.FirstOrDefault().ModelID == 0)
            {
                asset.assetList.modelList.FirstOrDefault().AddedBy = _userName;
                asset.assetList.modelList.FirstOrDefault().AddedDate = DateTime.Now;
                _context.ModelTypes.Add(asset.assetList.modelList.FirstOrDefault());
                _context.SaveChanges();
            }
            else
            {

            }

            return null;
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