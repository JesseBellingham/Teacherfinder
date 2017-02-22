namespace Teacherfinder.DataLayer.Entities
{
    using Teacherfinder.DataLayer.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public int StudentId { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        
        public virtual ICollection<Enrolment> Enrolments { get; set; }
        public virtual ICollection<Instrument> Instruments { get; set; }
    }
}