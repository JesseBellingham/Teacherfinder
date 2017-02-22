using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teacherfinder.Models.View
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public bool IsTeacher { get; set; }
    }
}