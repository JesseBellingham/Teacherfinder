using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classroom.DataLayer.DomainModels
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
    }
}