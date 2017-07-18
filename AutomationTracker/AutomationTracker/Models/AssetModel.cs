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
        public Computer computers { get; set; }
        public PhoneDongle phonesanddongles { get; set; }
        public VOIP voip { get; set; }
   
        public AssetList assetList { get; set; }
    }

    public class AssetList
    {
        public List<ModelType> modelList { get; set; }
        public List<UnitType> unittypeList { get; set; }
        public List<Computer> computerList { get; set; }
        public List<PhoneDongle> phonesanddongleList { get; set; }
        public List<VOIP> voipList { get; set; }
        public List<Software> softwareList { get; set; }
        public List<Provider> providerList { get; set; }
    }
}