using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomationTracker.Models
{
    public class AssetModel
    {
        public ModelType Modeltype { get; set; }
        public UnitType Unittype { get; set; }
        public List<ModelType> model { get; set; }
        public List<UnitType> unittype { get; set; }
        //public IEnumerable<UnitType> unitType { get; set; }


    }

    //public class ModelTypes
    //{
    //    public string ModelName { get; set; }
    //    public UnitType UnitType { get; set; }        
    //    public string Description { get; set; }
    //}

    //public class UnitType
    //{
    //    public string UnitName { get; set; }
    //}
}