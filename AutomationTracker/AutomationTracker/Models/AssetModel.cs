using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomationTracker.Models
{
    public class AssetModel
    {
        public Model model { get; set; }
        public IEnumerable<UnitType> unitType { get; set; }
    }

    public class Model
    {
        public string ModelName { get; set; }
        public UnitType UnitType { get; set; }        
        public string Description { get; set; }
    }

    //public class UnitType
    //{
    //    public string UnitName { get; set; }
    //}
}