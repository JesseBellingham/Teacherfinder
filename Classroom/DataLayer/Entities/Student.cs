namespace Classroom.DataLayer.Entities
{
    using Classroom.DataLayer.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int StudentId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Location Location { get; set; }
        
        public virtual ICollection<Enrolment> Enrolments { get; set; }
        public virtual ICollection<Instrument> Instruments { get; set; }
    }
}