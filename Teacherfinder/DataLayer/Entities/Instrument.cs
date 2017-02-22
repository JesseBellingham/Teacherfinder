using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teacherfinder.DataLayer.Entities
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public InstrumentType InstrumentType { get; set; }
    }
}