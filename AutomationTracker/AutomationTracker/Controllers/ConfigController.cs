﻿using AutomationTracker.Models;
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
            AssetModel objModel = new AssetModel();
            AssetList objList = new AssetList();

            objList.modelList = _context.ModelTypes.ToList();
            objModel.assetList = objList;

            return View(objModel);
        }

        public ActionResult ManageModels(int id)
        {
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
            AssetModel objModel = new AssetModel();
            AssetList objList = new AssetList();

            objList.modelList = _context.ModelTypes.ToList();
            objModel.assetList = objList;

            return View(objModel);
        }

        public ActionResult ViewUnitTypes()
        {
            AssetModel objModel = new AssetModel();
            AssetList objList = new AssetList();

            objList.unittypeList = _context.UnitTypes.ToList();
            objModel.assetList = objList;

            return View(objModel);
        }

        public ActionResult ManageUnitTypes(int id)
        {
            if (id == 0)
            {
                AssetModel objModel = new AssetModel();
                AssetList objList = new AssetList();

                objList.unittypeList = _context.UnitTypes.ToList();
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
                    objModel.assetList = objList;
                    return View(objModel);
                }

            }
            return null;
        }


        #region
        [HttpPost]
        public ActionResult SaveModels(AssetModel asset)
        {
            if (asset.assetList.modelList.FirstOrDefault().ModelID == 0)
            {
                _context.ModelTypes.Add(asset.assetList.modelList.FirstOrDefault());
                _context.SaveChanges();
            }
            else
            {

            }

            return null;
        }

        [HttpPost]
        public ActionResult SaveUnitTypes(AssetModel asset)
        {
            if (asset.assetList.unittypeList.FirstOrDefault().UnitTypeID == 0)
            {
                _context.UnitTypes.Add(asset.assetList.unittypeList.FirstOrDefault());
                _context.SaveChanges();
            }
            else
            {

            }

            return null;
        }
        #endregion
    }
}