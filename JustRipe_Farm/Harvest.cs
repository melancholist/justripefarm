using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe_Farm
{
    public class Harvest
    {
        private string cropsType;
        private DateTime harvestTime;
        private string harvestMethod;

        public string CropsType { get => cropsType; set => cropsType = value; }
        public DateTime HarvestTime { get => harvestTime; set => harvestTime = value; }
        public string HarvestMethod { get => harvestMethod; set => harvestMethod = value; }
    }
}
