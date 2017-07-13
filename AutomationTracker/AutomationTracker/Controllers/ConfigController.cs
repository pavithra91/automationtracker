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
        OfficeAutomationdbEntities en = new OfficeAutomationdbEntities();
        // GET: Config
        public ActionResult Index()
        {
            AssetModel objModel = new AssetModel();

            List<UnitType> lst = en.UnitTypes.ToList();

            objModel.unitType = lst;

            return View(objModel);
        }

        public ActionResult ManageModels(int? id)
        {
            if (id == 0)
            {

            }
            else
            {

            }
            AssetModel objModel = new AssetModel();

            List<UnitType> lst = en.UnitTypes.ToList();



            return View(objModel);
        }
    }
}