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
                objModel.computers = new Computer();

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
    }
}