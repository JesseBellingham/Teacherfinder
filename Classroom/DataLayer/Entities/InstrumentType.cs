using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classroom.DataLayer.Entities
{
    public class InstrumentType
    {
        public int InstrumentTypeId { get; set; }
        public string InstrumentTypeCode { get; set; }
        public string InstrumentTypeDescription { get; set; }
    }
}