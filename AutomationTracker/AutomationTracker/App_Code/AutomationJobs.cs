using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomationTracker.App_Code
{
    public class AutomationJobs : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            OfficeAutomationdbEntities _context = new OfficeAutomationdbEntities();

            var disposeList = _context.PhoneDongles.SqlQuery("Select * FROM dbo.PhoneDongles where DisposeDate<=DATEADD(m, 3, GETDATE()) and IsEmailSend = 0");

            if(disposeList.ToList().Count > 0)
            {
                foreach (var item in disposeList)
                {
                    DisposeList _disposeObj = new DisposeList();
                    _disposeObj.Category = 2;
                    _disposeObj.ItemID = item.AUOTID;
                    _disposeObj.DisposeDate = item.DisposeDate;

                    _context.DisposeLists.Add(_disposeObj);


                    //item.IsEmailSend = true;
                    //_context.PhoneDongles.Attach(item);
                }

                _context.SaveChanges();
            }
        }
    }
}