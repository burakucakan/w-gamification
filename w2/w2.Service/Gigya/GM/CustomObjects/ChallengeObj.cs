using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.GM.CustomObjects
{
    public class ChallengeObj
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointsValue { get; set; }
        public int DailyCap  { get; set; }
        public int MinimalInterval { get; set; }
        public bool Status { get; set; }
    }

    public class ActionAttributesObj
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointsValue { get; set; }
        public int DailyCap { get; set; }
        public int MinimalInterval { get; set; }
        public bool Status { get; set; }
    }
}
